using System;
using System.Text.Json.Serialization;

namespace ArtSofte_Test.Models.Department
{
    public class CreateDepartment : BaseDepartment
    {
        [JsonPropertyName("depRefId")]
        //public Guid DepId { get; set; }
        public int Id { get; set; }
    }
}