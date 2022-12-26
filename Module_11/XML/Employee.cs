using System.Xml.Serialization;

namespace XML
{
    public class Employee
    {
        [XmlElement(ElementName = "Employee_Name")]
        public string EmployeeName;
    }
}
