using System;
using System.Text.Json.Serialization;


namespace ArtSofte_Test.Models.Employee
{
    public class ViewEmployee : BaseEmployee
    {
        [JsonPropertyName("employeeRefId")]
        public Guid EmployeeId { get; set; }

        [JsonPropertyName("companyRefId")]
        public Guid CompanyRefId { get; set; }

    }
}
