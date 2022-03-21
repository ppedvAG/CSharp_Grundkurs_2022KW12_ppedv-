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


            #region Mehrdimensionales Array

            int pos = 2;
            int[,] zweiDimArray = new int[pos, 5];

            int[] test = new int[pos];


            
            #endregion
        }
    }
}
