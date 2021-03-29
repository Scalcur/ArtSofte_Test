using ArtSofte_Test.Models.Employee;
using ArtSofte_Test.Models.Language;
using System.Text.Json.Serialization;

namespace ArtSofte_Test.Models
{
    public class EmployeeLanguage
    {
        [JsonIgnore]
        public int EmployeeId { get; set; }
        

        [JsonIgnore]
        public ViewEmployee Employee { get; set; }

        [JsonIgnore]
        public int LangId { get; set; }

        public ViewLang Lang { get; set; }

    }
}