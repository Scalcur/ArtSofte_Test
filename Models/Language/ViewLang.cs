using System;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace ArtSofte_Test.Models.Language
{
    public class ViewLang : BaseLanguage
    {
        [JsonPropertyName("langRefId")]
        public int Id { get; set; }

        public List<EmployeeLanguage> EmployeeLanguages { get; set; }
        public ViewLang()
        {
            EmployeeLanguages = new List<EmployeeLanguage>();
        }

        //public int Id { get; set; }

    }
}