using System;
using System.Data.SqlClient;
using System.IO;

namespace OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Lebewesen.ZeigeAnzahlLebewesen();

            Lebewesen lebewesen = new Lebewesen();
            lebewesen.Name = "Harry Weinfurth";
            lebewesen.Geburtsdatum = DateTime.Now;
            lebewesen.Lieblingsnahrung = "Lassange";


            Lebewesen lebewesen1 = null;

            lebewesen1 = new Lebewesen();

            lebewesen1.Name = "";




            lebewesen1 = null;
            #region Modul 06: OOP
            //Deklarierung von Person-Variablen und Instanziierung von neuen Personenobjekten per Konstruktor
            Lebewesen neuesLebewesen = new Lebewesen("Bello", "Fleisch", new DateTime(2007, 4, 23));
            Lebewesen neuesLebewesen2 = new Lebewesen("Hannes Schmidt", "Lasagne", new DateTime(1972, 12, 2));

            //Lesezugriff auf Property per Getter
            Console.WriteLine(neuesLebewesen.Name);

            //Schreibzugriff auf Property per Setter
            neuesLebewesen.Name = "Rex";
            Console.WriteLine(neuesLebewesen.Name);

            Console.WriteLine(neuesLebewesen.Geburtsdatum);
            Console.WriteLine(neuesLebewesen.AlterInJahren);

            //Aufruf einer klasseneigenen Funktion
            Lebewesen kind = neuesLebewesen.GebäreKind("Fridolin");
            #endregion


            #region Modul007
            Lebewesen lebewesen2 = new Lebewesen("Jürgen von der Lippe", "Burger", new DateTime(1955, 11, 11));

            Console.WriteLine(Lebewesen.ZeigeAnzahlLebewesen());

            //int i = 0;
            //i++;

            //Aufruf der GC und Programmpause, bis alle Destruktoren beendet wurden
            GC.Collect();
            GC.WaitForPendingFinalizers();



            Console.WriteLine(Lebewesen.ZeigeAnzahlLebewesen()); // 6


            //Macht einen Fehler ->IDisposeable fehlt
            //using (Lebewesen lebewesen5 = new Lebewesen())
            //{

            //} //Lebewesen5 wird hier expliziet abgebaut....bei Fehler oder Erfolg -> Methode Dispose 


            using (MyClassWithAbort myClass = new MyClassWithAbort())
            {

            } //Dispose und danach wird dekonsutrkor auf


            using MyClassWithAbort myClass = new MyClassWithAbort();


            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection("abc");
                conn.Open(); //Achtung hier gibt es einen Fehler -> Datenbank nicht geufnden
            }
            catch
            {
                //Fehlerbehandlung
            }
            finally
            {
                //Wird im Fehlerfall und im Erfolgsfall immer aufgerufen

                conn.Dispose();
            }
            #endregion


            int i; //Variable (ein Wert) 



            Console.ReadLine();
        } //GC -> würde 
    }

    public class Lebewesen
    {
        #region Felder und Eigentschaften
        
        private string name = "Hugo"; //Default-Wert

        public string Name
        {
            get { return name; }
            set 
            { 
                if (!string.IsNullOrEmpty(value)) //prüfen ob der String Zeichen beinhaltet
                {
                    name = value;
                }
            }
        }

        //Wird in einer Eigenschaft keine Spezifizierung angegeben, generiert das Programm das entsprechende Feld unsichtbar im Hintergrund
        //Snippet: prop + tab + tab (2x) 
        public string Lieblingsnahrung { get; set; }
        
        //Property, welche einen komplexen Datentypen abbildet -> Auto-Property
        public DateTime Geburtsdatum { get; set; }


        //Read-only Property mit Rückbezug auf andere Property
        public int AlterInJahren
        {
            get
            {
                return ((DateTime.Now - this.Geburtsdatum).Days / 365);
            }
        }
        #endregion

        #region Konstruktoren
        //Es können mehrere Konstruktoren definiert werden, welche unterschiedliche Übergabeparameter haben (Überladung). Ein Konstruktor, der keine
        //Übergabeparameter hat, wird als Basiskonstruktor bezeichnet
        public Lebewesen()
        {
            AnzahlLebewesen++;
        }

        public Lebewesen(string name, string lieblingsnahrung, DateTime geburtsdatum)
            : this()
        {
            this.Name = name;
            this.Lieblingsnahrung = lieblingsnahrung;
            this.Geburtsdatum = geburtsdatum;

        }

        

        #endregion


        #region Dekonstruktor
        ~Lebewesen()
        {
            AnzahlLebewesen--;
            Console.WriteLine($"{this.Name} ist gestorben.");
        }
        #endregion


        #region Methode
        public Lebewesen GebäreKind(string kindername)
        {
            //Lebewesen lebewesen = new Lebewesen(kindername, this.Name, DateTime.Now);
            //return lebewesen;

            //kürzer Schreibweise
            return new Lebewesen(kindername, this.Name, DateTime.Now);
        }
        #endregion

        #region Statische Member
        public static int AnzahlLebewesen { get; set; } = 0; //setter bekommt den Wert 0 (Default-Wert) 

        public static string ZeigeAnzahlLebewesen()
        {
            return $"Es gibt {AnzahlLebewesen} Lebwesen";
        }
        #endregion
    }


    public class MyClassWithAbort : IDisposable
    {
        public void Dispose()
        {
            
        }
    }
}
