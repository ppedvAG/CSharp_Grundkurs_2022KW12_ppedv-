using System;

namespace Modul02_LabLoesung
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Variablendeklaration 
            int entfernungInMetern, stunden, minuten, sekunden;
            double meterProSekunde, kilometerProStunde, meilenProStunde;


            Console.WriteLine("Bitte gib folgende Angabe ein: ");
            Console.Write("Entfernung (in Metern): ");

            //parsen der Eingabe in Int32 (int) 
            entfernungInMetern = int.Parse(Console.ReadLine());
            Console.Write("Stunden: ");
            
            stunden = int.Parse(Console.ReadLine());
            Console.Write("Minuten: ");

            minuten = int.Parse(Console.ReadLine());
            Console.Write("Sekunden: ");
            sekunden = int.Parse(Console.ReadLine());

            //Ausgabe einer leeren Zeile
            Console.WriteLine();

            sekunden = sekunden + (minuten * 60) + (stunden * 3600);
            meterProSekunde = entfernungInMetern / (double)sekunden;
            kilometerProStunde = meterProSekunde * 3.6;
            meilenProStunde = kilometerProStunde * 0.62137119;

            Console.WriteLine($"Meter/Sekunde:\t\t {Math.Round(meterProSekunde)}");
            Console.WriteLine($"Kilometer/Stunde:\t {Math.Round(kilometerProStunde)}");
            Console.WriteLine($"Meile/Stunde:\t\t {Math.Round(meilenProStunde)}");
        }
    }
}
