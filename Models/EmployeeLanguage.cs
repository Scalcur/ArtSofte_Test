using ArtSofte_Test.Models.Employee;
using ArtSofte_Test.Models.Language;
using System;

namespace ArtSofte_Test.Models
{
    public class EmployeeLanguage
    {
        public int EmployeeId { get; set; }
        public ViewEmployee Employee { get; set; }

        public int LangId { get; set; }
        public ViewLang Lang { get; set; }

    }
}