using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Json
{
    public class Department
    {
        [JsonRequired]
        [JsonPropertyName("Department Name")]
        public string DepartmentName { get; set; }

        [JsonRequired]
        public List<Employee> Employees { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Department name: {DepartmentName}");

            foreach (var employee in Employees)
            {
                sb.AppendLine($"Employee name: {employee.EmployeeName}");
            }

            return sb.ToString();
        }
    }
}
