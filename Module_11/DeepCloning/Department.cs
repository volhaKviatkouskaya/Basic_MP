using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace DeepCloning
{
    [Serializable]
    public class Department: ICloneable
    {
        public string DepartmentName;
        public List<Employee> Employees;

        public object Clone()
        {
            using (MemoryStream stream = new MemoryStream())
            {
                if (this.GetType().IsSerializable)
                {
                    BinaryFormatter formatter = new();
                    formatter.Serialize(stream, this);
                    stream.Position = 0;
                    return formatter.Deserialize(stream);
                }
                return null;
            }
        }

        public Department DeepCopy()
        {
            var other = (Department)MemberwiseClone();

            other.DepartmentName = string.Copy(DepartmentName);
            other.Employees = new List<Employee>();

            foreach (var employee in Employees)
            {
                other.Employees.Add(employee.DeepCopy());
            }

            return other;
        }

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
