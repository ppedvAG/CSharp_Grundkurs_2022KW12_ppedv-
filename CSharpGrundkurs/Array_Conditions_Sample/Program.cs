using System;
using System.Linq;

namespace Array_Conditions_Sample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Einfaches Array
            //einfaches Array

            //Deklaration mit Initialisierung
            int[] zahlen = { 2, 4, 8, -123, -8, 0, 1111 };


            //Zugriff via Index auf Array
            Console.WriteLine(zahlen[3]); //Index 3 -> -123 

            zahlen[5] = 1234;
            Console.WriteLine(zahlen[5]);

            #endregion

            #region string-Array -> Methoden mit using System.Linq
            string[] worte = new string[8]; //Array hat 8 Felder und noch keine zugewiesenen Werte (alle sind via default-> 0 oder bei string -> string.Empty oder auch "") 


            //Verwenden die Contains-Methode mithilfe -> using System.Linq;
            Console.WriteLine(zahlen.Contains(-123));
            Console.WriteLine(zahlen.Contains(99));

            Console.WriteLine(zahlen.Length); //Anzahl der Einträge
            #endregion

            #region string/char
            //String als char-array

            string beispiel = "Hallo";
            Console.WriteLine(beispiel[2]); //l wird ausgegeben (Index = 2) 
            #endregion

            #region 
            int a = 0;

            Console.WriteLine(a++);
            a = 0;
            Console.WriteLine(++a);
            #endregion


            #region Mehrdimensionales Array

            int pos = 3;
            int[,] zweiDimArray = new int[pos, 5];

            //int[] test = new int[pos];

            //feste zuweisung
            zweiDimArray[0, 0] = 1;

            for (int i =0; i < 3; i++)
            {
                for (int j = 0; j < 5; j++)
                    zweiDimArray[i, j] = i * j;
            }

            Console.WriteLine(zweiDimArray[2, 3]);
            #endregion


            #region Conditions

            int x = 123;
            int y = 123;

            //Condition -> wird geprüft, ob x kleiner als y ist. 
            if (x < y) //Wenn ja
            {
                //Wenn ja -> wird dieser Codeblock ausgeführt
                Console.WriteLine("X ist kleiner als Y");
                //Kann hier eine weitere Zeile einfügen
            }
            else if (x > y)
                Console.WriteLine("Y ist kleiner als X");
            else if (x == y)
            {
                //Wird ausgeführt, wenn keine vorige Prüfung valide war 

                Console.WriteLine("A ist gleich B");
            }
            
            //Kurznotation:
            //(Bedinung) ? TrueAusgabe : FalseAusgabe

            string ergebnis = (x == y) ? "X ist gleich Y" : "X ist ungleich Y";


            string name1 = "Otto Walkes";
            string name2 = "OttoWalkes"; 

            if (name1 == name2)
                Console.WriteLine("gleich");
            else
                Console.WriteLine("ungleich");


            if (name1.Equals(name2))
            {
                Console.WriteLine("gleich");
            }
            else
            {
                Console.WriteLine("ungleich");
            }
            #endregion



            #region 1.Aufgabe: Schaltjahr-Rechner

            //Abfrage der Eingabe
            Console.WriteLine("Gib das Jahr ein:");
            int eingabe = int.Parse(Console.ReadLine());

            //Deklarierung/Initialisierung der bool-Variablen
            bool istSchaltjahr = false;


            if (DateTime.IsLeapYear(eingabe))
            {
                Console.WriteLine("Ist ein Schaltjahr");
            }
            else
                Console.WriteLine("Ist kein Schaltjahr");
            

            //Prüfung einer Teilbarkeit durch 4
            if (eingabe % 4 == 0)
            {
                //Setzten der Variablen auf true
                istSchaltjahr = true;

                //Prüfung einer Teilbarkeit durch 100
                if (eingabe % 100 == 0)
                {
                    //Setzten der Variablen auf false
                    istSchaltjahr = false;

                    //Prüfung einer Teilbarkeit durch 400
                    if (eingabe % 400 == 0)
                        //Setzten der Variablen auf true
                        istSchaltjahr = true;
                }
            }

            //Ausgabe
            Console.WriteLine($"{eingabe} ist Schaltjahr: {istSchaltjahr}"); //True oder False

            //Alternative (detailiertere) Ausgabe mittels Kurz-Bedingung
            string ausgabe = istSchaltjahr ? $"{eingabe} ist ein Schaltjahr." : $"{eingabe} ist kein Schaltjahr.";
            Console.WriteLine(ausgabe + "\n\n\n");

            #endregion


            #region 2. Aufgabe: Mini-Lotto

            //Deklaration & Initialisierung des Arrays der Gewinnzahlen
            int[] gewinnzahlen = { 3, 16, 45, 79, 99 };

            //int randomCountBetween0And100 = new Random().Next(1, 100);

            //int traditioneller = (new Random().Next() % 100);

            //Abfrage des User-Tipps
            Console.Write("Bitte gib deinen Tipp ab (Ganzzahl zwischen 0 und 100): ");
            int tipp = int.Parse(Console.ReadLine());

            //Prüfung des Zahlenbereiches des Tipps
            if (tipp < 0 || tipp > 100)
                Console.WriteLine("Dein Tipp ist außerhalb des Zahlenbereiches.");
            else
            {
                //Prüfung, ob Tipp eine Gewinnzahl ist und Ausgabe
                if (gewinnzahlen.Contains(tipp))
                    Console.WriteLine("Glückwunsch!! Du hast eine der fünf Gewinnzahlen getippt.");
                else
                    Console.WriteLine("Leider daneben. Viel Glück beim nächsten Mal.");
            }
            #endregion

        }
    }
}
