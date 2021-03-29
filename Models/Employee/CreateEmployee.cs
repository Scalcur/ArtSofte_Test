using System;
using System.Text.Json.Serialization;


namespace ArtSofte_Test.Models.Employee
{
    public class CreateEmployee :  BaseEmployee
    {
        [JsonPropertyName("depRefId")]
        public int DepRefId { get; set; }
        
        [JsonPropertyName("langIdForCreate")]
        public int LangIdForCreate { get; set; }
    }
}