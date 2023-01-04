using System;

namespace DeepCloning
{
    [Serializable]
    public class Employee
    {
        public string EmployeeName;

        public Employee DeepCopy()
        {
            var other = (Employee)MemberwiseClone();
            
            other.EmployeeName = string.Copy(EmployeeName);

            return other;
        }
    }
}
