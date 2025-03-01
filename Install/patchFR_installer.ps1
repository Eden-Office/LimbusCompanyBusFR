$OutputEncoding = [System.Text.Encoding]::UTF8   
$version = "Alpha-1"

$steamDirectory = Get-ItemPropertyValue -Path HKCU:\SOFTWARE\Valve\Steam -Name "SteamPath"
$limbusDirectory = Join-Path -Path $steamDirectory -ChildPath 'steamapps\common\Limbus Company'
$limbusExecutable = Join-Path -Path $limbusDirectory -ChildPath 'LimbusCompany.exe'
$bepInExDirectory = Join-Path -Path $limbusDirectory -ChildPath 'BepInEx'
$pluginsDirectory = Join-Path $bepInExDirectory -ChildPath "plugins"
$patchDirectory = Join-Path $pluginsDirectory -ChildPath "TraductionFRLimbus"

$bepInExUri = "https://builds.bepinex.dev/projects/bepinex_be/674/BepInEx-Unity.IL2CPP-win-x64-6.0.0-be.674%2B82077ec.zip"
$patchUri = "https://github.com/Eden-Office/LimbusCompanyBusFR/releases/latest/download/LimbusCompanyFR.zip"
# $dotNetSDKUri = "https://download.visualstudio.microsoft.com/download/pr/8d1443fd-a5e1-438d-8cb8-6ccb9849a54a/4f89f2b74a9c272789dfac8658a87673/dotnet-sdk-6.0.413-win-x64.exe"
# $dotNetSDKsha = "d3e8273d451b3bc15cd8f656ffdaaff4d1b0d17059ada578967063f4b9882b74926af61c6e0919f66b5bdeddd66e5047743544ac4768026b60de7a7591e1fab5"

$banner = @"
******************************************************
Installation automatisée du patch FR de Limbus Company
Auteur : @Azuro pour @EdenOffice
Version : $version
******************************************************
"@

# Setting a temp directory as the working directory.
function setWorkingDir {
  Push-Location -LiteralPath $env:TEMP
  try
  { return (New-Item -Type Directory -Name "LimbusCompanyFR$(Get-Date -UFormat '%Y-%m-%d_%H-%M-%S')" | Convert-Path | Set-Location -PassThru).Path }
  catch 
  {
    Write-Host $_
    exit
  }
}

# Downloader
function downloadRessource{
  param ( $source, $destination )
  try { Start-BitsTransfer -Source $source -Destination "$destination" }
  catch { (New-Object Net.WebClient).DownloadFile($source,$destination) }
}

# Installers
function installDotNetSDK {
  Write-Host 'Il est possible que des droits supplémentaires vous soient demandés durant cette opération.'
  winget install Microsoft.DotNet.SDK.6 --silent
  if ($LASTEXITCODE -ne 0) { throw 'Installation de Microsoft .NET SDK 6.0, échouée, abandon.' }
  else { Write-Host "Microsoft .NET SDK 6.0 installé, poursuite de l'installation." }
}

function installBepInExFramework {
  Write-Host 'Installation du framework BepInEx en cours.'
  $bepInExZip = Join-Path -Path $tempWorkingDir -ChildPath 'BepInEx.zip'
  downloadRessource $bepInExUri $bepInExZip  
  Expand-Archive -Force -LiteralPath "$bepInExZip" -DestinationPath $limbusDirectory
  Remove-Item -LiteralPath "$bepInExZip" -Force

  Write-Host "Framework BepInEx installé pour la première fois, poursuite."
  Write-Host "Démarrage de Limbus Company pour finaliser l'installation du framework, veuillez patienter et attendre son arrêt."
  Start-Process -FilePath $limbusExecutable

  $startTime = [datetime]::UtcNow.AddSeconds(180)
  while (($TimeRemaining = ($startTime - [datetime]::UtcNow)) -gt 0) {
    Write-Progress -Activity 'Attente (3 min)...' -PercentComplete ([int](1-($TimeRemaining.TotalSeconds/180))*100) -SecondsRemaining $TimeRemaining.TotalSeconds
    Start-Sleep 1
  }

  Write-Host "Arrêt de Limbus Company."
  Stop-Process -Name LimbusCompany -ErrorAction SilentlyContinue
}

function installPatchFR {
  if (Test-Path -LiteralPath $patchDirectory) {  Remove-Item -LiteralPath "$patchDirectory\*" -Recurse -Force  } # Emptying the patch directory to install the new version
  elseif ((Read-Host -Prompt "Le dossier de traduction n'a pas été trouvé. Les éventuels mods présents dans $pluginsDirectory vont être supprimés afin de procéder à son installation. Voulez-vous continuer ? (O/N)") -ne 'o') { throw "L'utilisateur a interrompu l'installation." }
  else {
    Remove-Item -LiteralPath "$pluginsDirectory\*" -Recurse -Force
    New-Item -Path $patchDirectory -ItemType:Directory -Force | Write-Verbose
  }

  $patchZip = Join-Path -Path $tempWorkingDir -ChildPath 'LimbusCompanyFR.zip'
  downloadRessource $patchUri $patchZip
  Write-Host "Ressources du patch FR téléchargées, déploiement."

  Expand-Archive -Force -LiteralPath "$patchZip" -DestinationPath $patchDirectory
  New-Item -Path (Join-Path $patchDirectory -ChildPath "\Localize\Readme\Sprites\Story") -ItemType:Directory -Force | Write-Verbose

  Remove-Item -LiteralPath "$patchZip" -Force
}

# ----

$tempWorkingDir = setWorkingDir

try{
  if ((Read-Host -Prompt 'Microsoft .NET SDK 6.0 et BepInEx sont nécessaires pour installer le patch. Le script les installera automatiquement si nécessaire. Voulez-vous continuer ? (O/N)') -ne 'o') { throw "L'utilisateur a choisi d'interrompre le script." }

  if ($null -eq (dotnet --list-sdks | findstr 6.0)) { installDotNetSDK }
  else { Write-Host "Microsoft .NET SDK 6.0 détecté, poursuite de l'installation." }
  Write-Host

  if (-not (Test-Path -LiteralPath $limbusDirectory)) { throw "Limbus Company n'a pas été trouvé dans $limbusDirectory, abandon. Veuillez vous assurer que le jeu Limbus Company soit installé via Steam." }
  elseif (-not (Test-Path -LiteralPath $bepInExDirectory)) { installBepInExFramework }
  else { Write-Host "Framework BepInEx détecté, poursuite." }
  Write-Host

  installPatchFR

  Write-Host "Installation terminée."
}
catch
{
  Write-Host
  Write-Host $_.Exception.Message -ForegroundColor Red
}
finally
{
  Pop-Location
  Write-Host 'Suppression des dossiers temporaires...'
  Remove-Item -LiteralPath $tempWorkingDir -Recurse
  Write-Host 'Appuyez sur une touche pour quitter...'
  Read-Host
}