# LimbusCompanyBusFR

<div align="center">
<a href="https://github.com/Eden-Office/LimbusCompanyBusFR">
   <img src="https://raw.githubusercontent.com/Eden-Office/LimbusCompanyBusFR/refs/heads/main/Localize/Readme/EO_EdenButton.png"
      width="200"
      height="200"/>
</a>
   
# LimbusCompanyBusFR
Traduction française pour le jeu "Limbus Company"
   
[Nos Amis](https://github.com/LocalizeLimbusCompany/LocalizeLimbusCompany)
   
[![Téléchargements totaux](https://img.shields.io/github/downloads/Eden-Office/LimbusCompanyBusFR/total?label=T%C3%A9l%C3%A9chargements%20Totaux)](../../releases)
[![Discord](https://img.shields.io/discord/884713391753666630)](https://discord.gg/kcQv8CrKG8)
[![Version](https://img.shields.io/github/v/release/Eden-Office/LimbusCompanyBusFR?sort=date&label=Version)](../../releases/latest)
</div>

# Installation

## Installation automatique (Windows uniquement)

### 1. Appuyez simultanément sur '⊞ Win'+'R'
### 2. Dans la fenêtre qui s'ouvre, saisissez 'powershell' et appuyez sur 'Entrée'
### 3. Dans la nouvelle fenêtre qui s'ouvre, collez simplement le code suivant :
   - iex ((New-Object System.Net.WebClient).DownloadString('https://raw.githubusercontent.com/Eden-Office/LimbusCompanyBusFR/main/Install/patchFR_installer.ps1'))
### 4. Suivez les instructions. Les questions peuvent être répondues en saisissant 'o' ou 'n' suivi d'un appui sur 'Entrée'.


## Installation manuelle

### 0. Téléchargez et installez [.NET 6.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/sdk-6.0.413-windows-x64-installer)
### 1. Installez le framework mod
   - Téléchargez [BepInEx](https://builds.bepinex.dev/projects/bepinex_be/674/BepInEx-Unity.IL2CPP-win-x64-6.0.0-be.674%2B82077ec.zip) puis transférez le contenu de l'archive dans le dossier du jeu
### 3. Lancez le jeu jusqu'à l'écran d'accueil (l'écran avec le logo du jeu) puis fermez le jeu.
### 4. Préparez un dossier pour le mod
   -  Contrairement à MelonLoader, pour un fonctionnement correct des plug-ins dans BIE, il est nécessaire de placer tous les plug-ins dans un seul dossier. Créez un tel dossier dans le chemin ``...\Limbus Company\BepInEx\plugins``. Le nom peut être n'importe quoi
### 5. Installez les fichiers de police
   - Téléchargez le [fichier de police française](https://mega.nz/folder/jfpXCITY#lIR8cGWquj53lsC-73r7gQ/file/CS5GnaTB) pour le jeu et déplacez-le dans le dossier **créé à l'étape 4.**
   - Pensez à renommer le fichier téléchargé pour qu'il s'appelle tmpfrenchfonts
   - [(Miroir avec polices sur Yandex disc)](https://disk.yandex.ru/d/ZKi3tK4krhPrWA)
### 6. Réglez la localisation
   - Téléchargez [archive](../../releases), et copiez le dossier Localize et le fichier LimbusCompanyFR_BIE.dll du dossier dans l'archive vers le dossier **créé à l'étape 4**.

### 7. Vérification
   - Il peut arriver que malgré ces étapes, le mod ne fonctionne pas. Pour s'assurer de son fonctionnement, voici les dossiers dont vous devez vérifier la présence :
   - Dans le dossier "Localize" : un dossier "FR" et un dossier "Readme"
   - Dans ce dossier "Readme" : un dossier "Sprites", contenant lui-même un dossier "Event" et un dossier "Story"

   - Si l'un de ces dossier est absent, il vous suffit de le créer et de le laisser vide.
    
## Je n'ai pas compris, que dois-je faire ? 
   - [Confessez-vous](https://www.youtube.com/watch?v=kLaaJ_aeoyM)

# Mise à jour du mod
   - Si vous avez suivi l'installation automatique : suivez à nouveau les consignes de l'installation automatique
   - Si vous avez suivi l'installation manuelle : suivez à nouveau les consignes de l'installation manuelle depuis l'étape 6.

# Notes
- Merci aussi à <b>Knightey</b> pour son aide avec le code et les visuels !
