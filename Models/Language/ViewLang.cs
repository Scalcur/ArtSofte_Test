using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace ArtSofte_Test.Models.Language
{
    public class ViewLang : BaseLanguage
    {
        [JsonIgnore]
        public int Id { get; set; }

        [JsonIgnore]
        public List<EmployeeLanguage> EmployeeLanguages { get; set; }
        public ViewLang()
        {
            EmployeeLanguages = new List<EmployeeLanguage>();
        }

    }
}