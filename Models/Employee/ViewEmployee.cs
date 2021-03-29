using System;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using ArtSofte_Test.Models.Department;

namespace ArtSofte_Test.Models.Employee
{
    public class ViewEmployee : BaseEmployee
    {
        [JsonPropertyName("employeeId")]
        public int Id { get; set; }

        [JsonIgnore]
        public int DepRefId { get; set; }

        public ViewDepartment Department { get; set; }

        public List<EmployeeLanguage> EmployeeLanguages { get; set; }

        public ViewEmployee()
        {
            EmployeeLanguages = new List<EmployeeLanguage>();
        }

        //public int Id { get; set; }

    }
}
