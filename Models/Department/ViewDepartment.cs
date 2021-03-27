using System;
using System.Text.Json.Serialization;

namespace ArtSofte_Test.Models.Department
{
    public class ViewDepartment : BaseDepartment
    {
        [JsonPropertyName("depRefId")]
        public Guid DepRefId { get; set; }
    }
}