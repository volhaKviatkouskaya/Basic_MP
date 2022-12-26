using System.Text.Json.Serialization;

namespace Json
{
    public class Employee
    {
        [JsonInclude]
        [JsonPropertyName("Employee Name")]
        public string EmployeeName;
    }
}
