using System;
using System.Collections.Generic;

namespace DeepCloning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var employee = new Employee { EmployeeName = "Volha Kviatkouskaya" };
            var employee1 = new Employee { EmployeeName = "Unknown Employee" };
            var department = new Department
            {
                DepartmentName = "DotNet",
                Employees = new List<Employee> { employee, employee1 }
            };

            Console.WriteLine("Original values of Department:");
            Console.WriteLine(department);

            var department1 = department.DeepCopy();
            Console.WriteLine("Original values of Department1(Deep clone):");
            Console.WriteLine(department1);

            var department2 = department.Clone();
            Console.WriteLine("Original values of Department2(Clone serialize/deserialize):");
            Console.WriteLine(department2);

            department.DepartmentName = "New department name";
            department.Employees[0].EmployeeName = "Unknown";
            department.Employees[1].EmployeeName = "Volha";
            department.Employees.Add(new Employee { EmployeeName = "Secret Employee" });

            Console.WriteLine("Original values of Department were changed:");
            Console.WriteLine(department);

            Console.WriteLine("Deep copy of Department1 has no changes:");
            Console.WriteLine(department1);

            Console.WriteLine("Deep copy of Department2 has no changes:");
            Console.WriteLine(department2);
        }
    }
}
