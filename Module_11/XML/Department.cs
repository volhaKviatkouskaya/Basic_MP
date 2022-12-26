using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace XML
{
    public class Department
    {
        [XmlElement(ElementName = "Department_Name")]
        public string DepartmentName;

        [XmlElement]
        public List<Employee> Employees;

        public override string ToString()
        {
            StringBuilder sb = new();
            sb.AppendLine($"Department name: {DepartmentName}");

            foreach (var employee in Employees)
            {
                sb.AppendLine($"Employee name: {employee.EmployeeName}");
            }

            return sb.ToString();
        }
    }
}
