using System.Collections.Generic;
using System.Text;

namespace Json
{
    public class Department
    {
        public string DepartmentName;
        public List<Employee> Employees;

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
