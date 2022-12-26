using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace Json
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var employee = new Employee { EmployeeName = "Volha Kviatkouskaya" };
            var employee1 = new Employee { EmployeeName = "Unknown Employee" };
            var department = new Department
            {
                DepartmentName = "DotNet",
                Employees = new List<Employee> { employee, employee1 }
            };
            Console.WriteLine($"Before serialization:\n{department}");

            var options = new JsonSerializerOptions
            {
                ReadCommentHandling = JsonCommentHandling.Skip,
                AllowTrailingCommas = true,
                WriteIndented = true
            };
            var jsonString = JsonSerializer.Serialize(department, options);
            Console.WriteLine($"Serialized department:\n{jsonString}\n");

            var deserializedDepartment = JsonSerializer.Deserialize<Department>(jsonString);
            Console.WriteLine($"After serialization:\n{deserializedDepartment}");
        }
    }
}
