using System;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace ArtSofte_Test.Models.Language
{
    public class ViewLang : BaseLanguage
    {
        [JsonPropertyName("langRefId")]
        public Guid LangId { get; set; }

        public int Id { get; set; }

    }
}