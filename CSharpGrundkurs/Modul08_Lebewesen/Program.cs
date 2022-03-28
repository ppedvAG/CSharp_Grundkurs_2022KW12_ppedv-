using System;
using System.Data.SqlClient;

namespace Modul08_Lebewesen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Lebewesen basisKlasseLebewesen = new Lebewesen(10, DateTime.Now);
            basisKlasseLebewesen.Atmen();

            Mensch vererbteKlasseMensch = new Mensch("Max", "Musterfrau", "Hamburg", 77, new DateTime(1971, 2, 2));

            vererbteKlasseMensch.Nahrungsaufnahme();
            //vererbteKlasseMensch.Wohnort = "Dresden";
            //vererbteKlasseMensch.Geburtsdatum = new DateTime(1978, 1, 2);
            //vererbteKlasseMensch.Gewicht = 12;
            //vererbteKlasseMensch.Atmen();

        }
    }


    

    public class Lebewesen
    {
        public int Gewicht { get; set; }
        public DateTime Geburtsdatum { get; set; }

        public Lebewesen()
        {
            AnzahlLebewesen++;
        }

        public Lebewesen(int gewicht, DateTime geburtsDatum)
            :this()
        {
            Gewicht = gewicht;
            Geburtsdatum = geburtsDatum;
        }


        public void Atmen()
        {
            Console.WriteLine("Lebewesen atmet");
        }

        public virtual void Nahrungsaufnahme()
        {
            Console.WriteLine("Das Lebewesen nimmt Nahrung auf");
        }

        #region Statische Member

        //STATISCHE Variablen und Methoden hängen an der Klasse selbst und nicht an instanziierten Objekten. Sie existieren demnach unabhängig von der Anzahl
        ///Objekte genau einmal. Der Aufruf erfolgt über den Klassenbezeichner.
        public static int AnzahlLebewesen { get; set; } = 0;

        public static string ZeigeAnzahlLebewesen()
        {
            return $"Es gibt {AnzahlLebewesen} Lebewesen.";
        }

        #endregion
    }

    public class Mensch : Lebewesen
    {
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public string Wohnort { get; set; }


        public Mensch(string vorname, string nachname, string wohnhort, int gewicht, DateTime geburtsDatum)
            :base(gewicht, geburtsDatum)
        {
            Vorname = vorname;
            Nachname = nachname;
            Wohnort = wohnhort;
        }
        public void Sprechen()
        {
        }

        public void Lesen()
        { 
        }

        public override void Nahrungsaufnahme()
        {
            //base.Nahrungsaufnahme(); -> Man kann optional die Basis-Methode auch mitverwenden. (wenn man es braucht)
            Console.WriteLine("Der Mensch isst mit Besteckt");
        }
    }

    public class MarsMensch : Mensch
    {
        public MarsMensch(string vorname, string nachname, string wohnhort, int gewicht, DateTime geburtsDatum) 
            : base(vorname, nachname, wohnhort, gewicht, geburtsDatum)
        {
        }

        public override void Nahrungsaufnahme() // override geht auch bei weiteren abgeleiteten Klassen
        {
            Console.WriteLine("Marsmensch muss beim Essen vor Marsstaub aufpassen");
        }
    }


    #region new - Schlüsselwort
    public class Hund : Lebewesen
    {
        public Hund()
        {

        }

        //New unterbricht das anbieten eines Overrides -> bei abgeleiteten Klassen 
        public new void Nahrungsaufnahme() 
        {
            Console.WriteLine("Der Hund frisst");
        }
    }

    public class Husky : Hund
    {
        //public override void Nahrungsaufnahme()
        //{
        //    base.Nahrungsaufnahme();
        //}
    }
    #endregion

    public sealed class ThisClassCannotUsedAsBaseClass
    {
        
    }

    //public class KannIchAbleiten : ThisClassCannotUsedAsBaseClass
    //{

    //}
}
