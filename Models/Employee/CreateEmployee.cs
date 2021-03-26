using System;
using System.Text.Json.Serialization;


namespace ArtSofte_Test.Models.Employee
{
    public class CreateEmployee :  BaseEmployee
    {
        [JsonPropertyName("companyRefId")]
        public Guid CompanyRefId { get; set; }

    }
}