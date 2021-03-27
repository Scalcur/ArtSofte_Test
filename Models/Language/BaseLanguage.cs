using System.Text.Json.Serialization;

namespace ArtSofte_Test.Models
{
    public class BaseLanguage
    {   
        [JsonPropertyName("langName")]     
        public string LangName { get; set; }

    }
}