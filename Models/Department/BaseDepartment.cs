using System.Text.Json.Serialization;

namespace ArtSofte_Test.Models
{
    public class BaseDepartment
    {
        [JsonPropertyName("depName")] 
        public string DepName { get; set; } 

        //[JsonPropertyName("depFloor")]
        [JsonIgnore] 
        public short DepFloor { get; set; }

    }
}