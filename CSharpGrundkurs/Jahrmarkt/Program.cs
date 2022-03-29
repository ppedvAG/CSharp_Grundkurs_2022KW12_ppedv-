using System;

namespace Jahrmarkt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Achterbahn achterbahn = new Achterbahn();
            
            IFSK18Check achterbahnWithFSKCheck = (IFSK18Check)achterbahn;
            if (achterbahnWithFSKCheck.AgeCheck(20))
            {
                Console.WriteLine("Teilnehmer darf mit der Achterbahn fahren");
            }


            IFSK18Check achterbahnWithCheck = new Achterbahn();
            achterbahnWithCheck.AgeCheck(20);

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

    public class Jahrmarktstand : IDisposable, ICloneable
    {
        public string Bezeichnung { get; set; }
        public int AnzahlMitarbeiter { get; set; }


        //Gibt eine flache Kopie des Ojektes zurück 
        public object Clone()
        {
            Jahrmarktstand jahrmarktstand = new Jahrmarktstand();
            jahrmarktstand.Bezeichnung = Bezeichnung;
            jahrmarktstand.AnzahlMitarbeiter = AnzahlMitarbeiter;

            return jahrmarktstand;
        }

        public void Dispose()
        {
            Bezeichnung = null;
            AnzahlMitarbeiter = 0;
        }

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



    #region Interfaces kann man vererben und kombinieren
    //Interfaces können auch vererbt werden
    public interface IBaseInterface
    {
        public void MakeBaseMethode();
    }

    public interface IDeliverInterface : IBaseInterface, ICloneable, IInterfaceWithDoubleMethod
    {
        public void MakeOther();
    }

    public class MyClass : IDeliverInterface
    {
        object ICloneable.Clone()
        {
            throw new NotImplementedException();
        }

        object IInterfaceWithDoubleMethod.Clone()
        {
            throw new NotImplementedException();
        }

        void IBaseInterface.MakeBaseMethode()
        {
            throw new NotImplementedException();
        }

        void IDeliverInterface.MakeOther()
        {
            throw new NotImplementedException();
        }
    }
    #endregion

    public interface IInterfaceWithDoubleMethod
    {
        public object Clone();
    }
}
