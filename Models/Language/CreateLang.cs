using System;
using System.Text.Json.Serialization;

namespace ArtSofte_Test.Models.Language
{
    public class CreateLang : BaseLanguage
    {
        [JsonPropertyName("langRefId")]
        public Guid LangId { get; set; }
    }
}