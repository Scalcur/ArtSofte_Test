using System.Collections.Generic;
using ArtSofte_Test.Models.Employee;
using ArtSofte_Test.Models.Department;
using ArtSofte_Test.Models.Language;

namespace ArtSofte_Test.ViewModels
{
    public class ViewEmployees
    {
        public IEnumerable<ViewEmployee> Employees { get; set; }

        public IEnumerable<ViewLang> Languages { get; set; }

        public IEnumerable<ViewDepartment> Departments { get; set; }

        public int DepartmentSort { get; set; }

        public int LanguageSort { get; set; }
    }
}