using System;
using ArtSofte_Test.Models.Employee;
using ArtSofte_Test.Models.Language;

namespace ArtSofte_Test.Models
{
    public class EmployeeLanguage
    {
        public Guid EmployeeId { get; set; }
        public ViewEmployee Employee { get; set; }

        public Guid LangId { get; set; }
        public ViewLang Lang { get; set; }

        public int Id { get; set; }
    }
}