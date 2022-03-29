using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace CollectionDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Liste - mit Strings
            List<string> städteListe = new List<string>();

            städteListe.Add("Hamburg");
            städteListe.Add("Stuttgart");
            städteListe.Add("Dresden");

            if (städteListe.Contains("Hamburg"))
            {
                Console.WriteLine("Hamburg befindet sich in der Liste");
            }

            foreach (string currentCity in städteListe)
            {
                Console.WriteLine(currentCity);
            }

            //List kann mit einem Index arbeiten 
            //Liste fängt bei Index 0

            string firstCity = städteListe[0];
            städteListe[0] = "Kassel";
            #endregion

            #region List with Complex Objects

            #region Einstieg
            List<Person> personListWithoutItems = new List<Person>();

            List<Person> personList = new List<Person>();

            personList.Add(new Person(1, "Harry", "Weinfurth", 50));
            personList.Add(new Person(2, "Steve", "Smith", 42));
            personList.Add(new Person(3, "Newton", "King", 39));
            
            personList.Add(new Person(4, "Donald", "Duck", 43));
            personList.Add(new Person(5, "Daniel", "Roth", 58));
            personList.Add(new Person(6, "Harry", "Potter", 23));
            
            personList.Add(new Person(7, "James", "Bond", 35));
            personList.Add(new Person(8, "Dagobert", "Duck", 70));
            personList.Add(new Person(9, "Max und Moritz", "Grimm", 21));


            foreach(Person currentPerson in personList)
                Console.WriteLine($"{currentPerson.Id} {currentPerson.FirstName} {currentPerson.LastName} {currentPerson.Age}");

            //auslesen via Index 
            Person personOnFirstPosition = personList[0];


            //OutOfRangeException -> wenn der Index sich ausserhalb der Liste befindet 
            #endregion

            #region Linq - Statements
            //Ältere und nicht mehr gängige Schreibweise 

            List<Person> durchschnittsalterAllerPersonenUnter40b = (from p in personList
                                                                    where p.Age < 40
                                                                    select p).ToList();
            #endregion

            #region Linq Function und Lambda-Expression
            //Linq und Lambda arbeiten mit Listen zusammen 


            //gebe mir das erste Objekt aus der List mit default

            //FirstOrDefault -> muss auf Null prüfen 
            Person firstPersonInList = personListWithoutItems.FirstOrDefault();
            Person lastPersonInList = personList.LastOrDefault();

            List<Person> personsUnder30 = personList.Where(e => e.Age < 30).ToList();

            double durchschnittsalterAllerPersonenUnter40 = personList.Where( e=>e.Age < 40)
                                                                      .Average(a=>a.Age);


            Person personWithId5 = personList.SingleOrDefault(e => e.Id == 5);

            if (personList.Any(e=>e.Age > 100))
            {
                Console.WriteLine("Es befindet sich eine oder mehrere Personen in der List, die über 100 Jahre alt sind");
            }
            else
            {
                Console.WriteLine("Keine Person über 100 Jahre gefunden");
            }

            //List.Count Property
            int count = personList.Count;  

            //Linq-Count Function 
            int count2 = personList.Count(e => e.Age > 40);


            #endregion 

            #region Pagging with Linq-Functions
            int pagingNumer = 1; //Auf welcher Index-Seite meiner Ergebnisliste befinde ich mich
            int pagingSize = 3; //Wie wieviele Datensätze werden auf der Seite angezeigt

            //Ersten drei Datensätze
            List<Person> ersteSeite = personList.Skip((pagingNumer - 1) * pagingSize).Take(pagingSize).ToList();


            pagingNumer = 2; 
            List<Person> zweiteSeite = personList.Skip((pagingNumer - 1) * pagingSize).Take(pagingSize).ToList();

            pagingNumer = 3;
            List<Person> dritteSeite = personList.Skip((pagingNumer - 1) * pagingSize).Take(pagingSize).ToList();
            #endregion


            #region Stack / Queue
            //Stack ist ein Stabel -> Bedeutet: Beim Hinzufügen: Neuster Eintrag wird oben drauf gelegt 
            //                                  Beim Auslesen: Wird der oberste Eintrag vom Stabel

            Stack<string> stack = new Stack<string>();
            stack.Push("Erste Eintrag");
            stack.Push("Zweiter Eintrag");
            stack.Push("Dritter Eintrag");

            //Dritter Eintrag ist zuletzt dazu gekommen
            string entry = stack.Pop();


            Queue<string> wartezimmer = new Queue<string>();
            wartezimmer.Enqueue("Erster Patient");
            wartezimmer.Enqueue("Zweiter Patient");
            wartezimmer.Enqueue("Dritter Patient");


            //Älteste Eintrag wird zuerst ausgelesen 
            string patient = wartezimmer.Dequeue();
            #endregion


            #region Dictionary Key/Value Liste
            
            Dictionary<int, string> dict = new Dictionary<int, string>();

            dict.Add(1, "Spanien");



            //KeyValuePair keyValuePairItem = new KeyValuePair<int, string>(2, "Portugal");

            
            //Wenn die ID 1 nicht vorhanden ist -> dann kann ich ein Datensatz mit ID-Wert 1 hinzufügen
            if(dict.ContainsKey(1) == false)
                dict.Add(1, "Frankreich");



            //Wir durchläuft ein Dictionary 

            foreach (KeyValuePair<int, string> kvp in dict)
            {
                Console.WriteLine($"{kvp.Key} {kvp.Value}" );
            }


            //Mithilfe des IDictionary kann ich mit KeyValuePair arbeiten 
            IDictionary<int, string> dict2 = new Dictionary<int, string>();
            dict2.Add(new KeyValuePair<int, string>(3, "England"));


            #endregion

            #region Hashtable
            Hashtable hashtable = new Hashtable();

            hashtable.Add(1, "Max und Moritz");
            hashtable.Add("Max und Moritz", 1);
            hashtable.Add(DateTime.Now, DateTime.Now);

            #endregion

        }
    }

    public class Person
    {
        public Person(int id, string firstName, string lastName, int age)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }    
    }
}
