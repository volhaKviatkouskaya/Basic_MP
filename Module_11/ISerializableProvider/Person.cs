using System;
using System.Runtime.Serialization;
using System.Text;

namespace ISerializableProvider
{
    [Serializable]
    public class Person : ISerializable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Person() { }

        public Person(SerializationInfo info, StreamingContext context)
        {
            FirstName = info.GetString("First name");
            LastName = info.GetString("Last name");
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("First name", FirstName);
            info.AddValue("Last name", LastName);
        }

        public override string ToString()
        {
            StringBuilder sb = new();
            sb.AppendLine("Person:");
            sb.AppendLine($"First name: {FirstName}");
            sb.AppendLine($"Last name: {LastName}");
            return sb.ToString();
        }
    }
}
