using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Binary
{
    internal class Program
    {
        private const string FileName = "Department.bin";

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

            IFormatter formatter = new BinaryFormatter();
            Stream streamWriter = new FileStream(FileName, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(streamWriter, department);
            streamWriter.Close();

            Stream streamReader = new FileStream(FileName, FileMode.Open, FileAccess.Read, FileShare.Read);
            Department deserializedDepartment = (Department)formatter.Deserialize(streamReader);
            streamReader.Close();

            Console.WriteLine($"After serialization:\n{deserializedDepartment}");
        }
    }
}
