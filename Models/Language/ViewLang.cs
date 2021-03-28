using System;
using System.Text.Json.Serialization;

namespace ArtSofte_Test.Models.Language
{
    public class ViewLang : BaseLanguage
    {
        [JsonPropertyName("langRefId")]
        public Guid LangId { get; set; }

        public int Id { get; set; }

    }
}