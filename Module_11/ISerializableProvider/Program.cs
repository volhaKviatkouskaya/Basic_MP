using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace ISerializableProvider
{
    internal class Program
    {
        private const string FileName = "Person.bin";

        static void Main(string[] args)
        {
            var person = new Person
            {
                FirstName = "Unknown",
                LastName = "Person"
            };

            Console.WriteLine($"Before serialization:\n{person}");

            IFormatter formatter = new BinaryFormatter();
            Stream streamWriter = new FileStream(FileName, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(streamWriter, person);
            streamWriter.Close();

            Stream streamReader = new FileStream(FileName, FileMode.Open, FileAccess.Read, FileShare.Read);
            Person deserializedDepartment = (Person)formatter.Deserialize(streamReader);
            streamReader.Close();

            Console.WriteLine($"After serialization:\n{deserializedDepartment}");
        }
    }
}
