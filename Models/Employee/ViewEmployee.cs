using System;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace ArtSofte_Test.Models.Employee
{
    public class ViewEmployee : BaseEmployee
    {
        [JsonPropertyName("employeeRefId")]
        public Guid EmployeeId { get; set; }

        [JsonPropertyName("depRefId")]
        public Guid DepRefId { get; set; }

        public List<EmployeeLanguage> EmployeeLanguages { get; set; }

        public ViewEmployee()
        {
            EmployeeLanguages = new List<EmployeeLanguage>();
        }

        public int Id { get; set; }

    }
}
