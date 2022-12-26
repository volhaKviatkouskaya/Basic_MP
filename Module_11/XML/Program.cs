using System;
using System.IO;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace XML
{
    internal class Program
    {
        private const string Path = @"c:\temp\Department.xml";
        static void Main(string[] args)
        {
            var employee = new Employee { EmployeeName = "Volha Kviatkouskaya" };
            var employee1 = new Employee { EmployeeName = "Unknown Employee" };
            var department = new Department
            {
                DepartmentName = "DotNet",
                Employees = new List<Employee> { employee, employee1 }
            };
            Console.WriteLine($"Before serialization:\n{department}");

            XmlSerializer xmlSerializer = new(typeof(Department));

            StreamWriter fileWriter = new(Path);
            xmlSerializer.Serialize(fileWriter, department);
            fileWriter.Close();

            StreamReader fileReader = new(Path);
            var deserializedDepartment = (Department)xmlSerializer.Deserialize(fileReader);
            fileReader.Close();

            Console.WriteLine($"After deserialization:\n{deserializedDepartment}");
        }
    }
}
