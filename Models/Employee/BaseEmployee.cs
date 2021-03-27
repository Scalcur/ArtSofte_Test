using System.Text.Json.Serialization;

namespace ArtSofte_Test.Models.Employee
{
    public class BaseEmployee
    {
        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }

        [JsonPropertyName("secondName")]
        public string SecondName { get; set; }

        [JsonPropertyName("age")]
        public short Age { get; set; }
    }
}
