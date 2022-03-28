using System;

namespace Jahrmarkt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public interface IFSK18Check
    {
        //Interface können auch Default-Implementierung
        public bool AgeCheck(int age)
        {
            return age >= 18 ? true : false;
        }

        
    }

    public interface IToileteAvailbabe
    {
        public int AnzahlDerToiletten { get; set; }
    }


        

    public class Jahrmarktstand
    {
        public string Bezeichnung { get; set; }
        public int AnzahlMitarbeiter { get; set; }
    }

    public class AutoScooter : Jahrmarktstand
    {
        public int AutoSooterAnzahl { get; set; }

        //....
    }


    public class HorrorCabinett : Jahrmarktstand, IFSK18Check, IToileteAvailbabe
    {
        public int AnzahlDerSchocker { get; set; }
        public int AnzahlDerToiletten { get; set; }
    }

    public class Achterbahn : Jahrmarktstand, IFSK18Check    
    {
        public int HoeheDerAchterbahn { get; set; }
    }

    public class WildWasserbahn : Jahrmarktstand, IToileteAvailbabe
    {
        public int LängerDerRutsche { get; set; }
        public int AnzahlDerToiletten { get; set; }
    }

}
