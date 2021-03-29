using System;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using ArtSofte_Test.Models.Employee;

namespace ArtSofte_Test.Models.Department
{
    public class ViewDepartment : BaseDepartment
    {
        [JsonPropertyName("depRefId")]
        //public Guid DepId { get; set; }
        public int Id { get; set; }

        //public int Id { get; set; }
    }
}