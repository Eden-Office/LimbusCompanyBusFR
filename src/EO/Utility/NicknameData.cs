using StorySystem;
using SerializableAttribute = System.SerializableAttribute;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace LimbusCompanyFR
{
    [Serializable]
    public class NicknameData : ScenarioAssetData
    {
        [JsonPropertyName("frname")]
#pragma warning disable CS8632 
        public string? frname;
#pragma warning restore CS8632 

        [JsonPropertyName("frNickName")]
#pragma warning disable CS8632 
        public string? frNickName;
#pragma warning restore CS8632 

        public NicknameData() { }

        internal static NicknameData Create(ref Utf8JsonReader reader)
        {
            var result = new NicknameData();
            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndObject)
                {
                    break;
                }
                if (reader.TokenType == JsonTokenType.PropertyName)
                {
                    string propertyName = reader.GetString();
                    reader.Read();

                    if (propertyName == "name")
                    {
                        result.name = reader.GetString();
                    }
                    else if (propertyName == "frname")
                    {
                        result.frname = reader.GetString();
                    }
                    else if (propertyName == "frNickName")
                    {
                        result.frNickName = reader.GetString();
                    }
                }
            }
            return result;
        }
    }
}