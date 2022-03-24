using System;

namespace ClassVsStructSample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Personen-Klasse ist ein Referenztyp 
            //PersonC hat die Adresse 0xF1F2F3 { 33, "Max" } 
            PersonC personC = new PersonC(33, "Max");


            //PersonS ist ein Struct-Typ
            //PersonS hat die Adresse 0xF1F2F3 { 33, "Max" } 
            PersonS personS = new PersonS(33, "Moritz");

            Console.WriteLine($"Aktuelles Alter (PersonC): {personC.Alter}");
            Console.WriteLine($"Aktuelles Alter (PersonS): {personS.Alter}");



            PersonCAltern(personC); //Klasse PersonC übergibt seine Speicheradresse an den Parameter
            PersonSAltern(personS);

            Console.WriteLine($"Aktuelles Alter (PersonC): {personC.Alter}"); //Da die Speicheradresse bei PersonC
            Console.WriteLine($"Aktuelles Alter (PersonS): {personS.Alter}");



        }

        public static void PersonCAltern(PersonC person) //Speicheradresse wird übergeben und PersonC person erhält die selbe Speicheradresse und dessen Werte über die Übergabe
        {
            person.Alter++;
        }

        public static void PersonSAltern(PersonS person)//Hier verwenden wir einen neue Adresse und seine Werte die Übergeben
        {
            person.Alter++;
        }
    }

    public class PersonC
    {
        public int Alter { get; set; }
        public string Name { get; set; }

        public PersonC (int alter, string name)
        {
            Alter = alter;
            Name = name;
        }
    }

    public struct PersonS
    {
        public int Alter { get; set; }
        public string Name { get; set; }

        public PersonS(int alter, string name)
        {
            Alter = alter;
            Name = name;
        }
    }
}
