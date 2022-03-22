using System;

namespace Modul004Demo
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            #region Schleifen
            int a = 0;
            int b = 10;

            //WHILE-Schleife
            ///Die WHILE-Schleife wird wiederholt, solange die Bedingung wahr ist. Ist die Bedingung von vornherein unwahr, dann wird die Schleife
            ///übersprungen
            while (a < b) //bis 9 wird gezählt
            {
                Console.WriteLine("A ist kleiner als B");
                a++; //hier wird nohmals addiert
            }
            Console.WriteLine(a); //10

            Console.WriteLine("Schleifenende");

            //DO-WHILE-Schleife
            ///Auch die DO-WHILE-Schleife wird wiederholt, solange die Bedingung wahr ist. Allerdings wird die Bedingung erst am Schleifen_
            ///ende geprüft, weshalb die Schleife mindestens einmal durchläuft.
            a = -45;
            do
            {
                Console.WriteLine(a);
                a++;
            }
            while (a < 0);



            //FOR-Schleife
            
            for (int y = 0; y < 10; y += 2) 
            { 
           


                Console.WriteLine(y);
            }


            //Man könnte eine For-Schleife als While Schleife umformen -> aber wer will das? :-) 
            int ii = 0;
            for (;ii < 10; )
                ii++;



            // For-Schleife in Verbindung mit einem Array
            int[] zahlen = { 2, 3, 4, 5, 6, };

            //Iteration über ein Array mittels For-Schleife
            for (int y = 0; y < zahlen.Length; y++)
                Console.WriteLine(y);

            //ForEach Schleifen können über Collections laufen und sprechen dabei jedes Element genau an 
            foreach (int currentNumber in zahlen)
                Console.WriteLine( currentNumber);



            //Break in Schleifen verwenden
            a = 0;
            b = 10;

            //WHILE-Schleife
            ///Die WHILE-Schleife wird wiederholt, solange die Bedingung wahr ist. Ist die Bedingung von vornherein unwahr, dann wird die Schleife
            ///übersprungen
            while (a < b) //bis 9 wird gezählt
            {
                Console.WriteLine("A ist kleiner als B");
                a++; //hier wird nohmals addiert

                if (a == 5)
                {
                    Console.WriteLine("Vorzeitiger Abbruch");
                    break; //Ich springe aus der Schleife heraus 
                }
            }
            Console.WriteLine("Ende der Schleife");



            //Continue Befehl (wollen 4er Zahlen Reihe auslesen

            for (int i = 1; i < 100; i++)
            {
                if (i % 4 != 0 )
                {
                    continue; 
                    //int c = 1; -> Direkt nach continue sind die Befehle nicht erreichbar. 
                }
                    
                Console.WriteLine(i);
            }
            Console.WriteLine("Fertig");
            #endregion


            #region Enums vs Arrays

            string[] wochentageAlsStringArray = { "Montag", "Dienstag", "Mittwoch", "Donnerstag", "Freitag", "Samstag", "Sonntag" };

            Console.Write("Wähle einen Wochentag aus (1=Mo 7=So): ");
            int wochentag = int.Parse(Console.ReadLine());

            if (wochentag == 6 || wochentag == 7)
            {
                Console.WriteLine($"{wochentageAlsStringArray[wochentag]} is am Wochenende" );
            }


            //Enum Variante
            Console.Write("Wähle einen Wochentag aus (1=Mo 7=So): ");
            Wochentag currentWeekDay = (Wochentag)int.Parse(Console.ReadLine());


            if (currentWeekDay == Wochentag.Samstag || currentWeekDay == Wochentag.Sonntag)
            {
                Console.WriteLine("Wochenende");
            }
           

            Console.ReadLine();
            #endregion


            #region Switch - Statement

            //Back To If-Statement

            if (currentWeekDay == Wochentag.Montag)
            {
            }
            else if (currentWeekDay == Wochentag.Dienstag)
            {

            }
            else if (currentWeekDay == Wochentag.Mittwoch)
            {

            }
            else if (currentWeekDay == Wochentag.Donnerstag)
            {

            }
            else if (currentWeekDay == Wochentag.Freitag)
            {

            }
            else
            {
                Console.WriteLine("Wochenende");
            }


            switch (currentWeekDay)
            {
                case Wochentag.Montag:
                    Console.WriteLine("Ist Montag");
                    break; //break ist wichtig! -> sonst... 
                case Wochentag.Dienstag:
                    Console.WriteLine("Ist Dienstag");
                    break;
                case Wochentag.Mittwoch:
                    Console.WriteLine("Ist Mittwoch");
                    break;
                case Wochentag.Donnerstag:
                    Console.WriteLine("Ist Donnerstag");
                    break;

                case Wochentag.Freitag:
                    Console.WriteLine("Ist Freitag");
                    break;
                case Wochentag.Samstag:
                    Console.WriteLine("Ist Sam");
                    break;

            }


            switch (currentWeekDay)
            {
                case Wochentag.Montag:
                case Wochentag.Dienstag:
                case Wochentag.Mittwoch:
                case Wochentag.Donnerstag:
                case Wochentag.Freitag:
                    Console.WriteLine("Arbeitstag");
                    break;

                case Wochentag.Samstag:
                case Wochentag.Sonntag:
                    Console.WriteLine("Wochenede");
                    break;
               
            }

            //Kleiner und Größer Vergelich bei Enums
            switch (currentWeekDay)
            {
                case < Wochentag.Mittwoch:
                    break;
            }


            int number = 99;

            switch(number)
            {
                case 5:
                    Console.WriteLine("a ist 5");
                    break;
                case int myNumber when myNumber > 10:
                    Console.WriteLine("number ist eine Zahl und grlößer als 10");
                    break;
                
            }


            //Mittels des WHEN-Stichworts kann auf Eigenschaften des betrachteten Objekts näher eingegangen werden
            int zahl = -45;
            switch (zahl)
            {
                case 5:
                    Console.WriteLine("a ist 5");
                    break;
                //zahl wird in z eingelegt (zu überprüfende Variable wird für Bedingungsprüfung vorbereitet)
                //und mittels when auf eine Eigenschaft geprüft
                case int z when z < 0:
                    Console.WriteLine("a < 0");
                    break;
                default:
                    break;
            }


            #endregion
        }
    }

    enum Wochentag { Montag=1, Dienstag, Mittwoch, Donnerstag, Freitag, Samstag, Sonntag }
}
