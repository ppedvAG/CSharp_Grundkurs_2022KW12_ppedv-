using System;

namespace ErweiterungsmethodenSample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person();
            person.Id = 1;
            person.Name = "Tester Muster";

            person.Speichern("C:\\Windows\\Temp\\Person.vcard");
        }
    }

    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public static class PersonenExtentions
    {
        public static void Speichern(this Person p, string path)
        {
            Console.WriteLine($"{p.Id} {p.Name} wird in {path} gespeichert. ");
        }
    }
}
