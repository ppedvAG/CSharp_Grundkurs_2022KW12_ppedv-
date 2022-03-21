using System;

namespace VariablesDataTypesSample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Einstieg -> Was ist eine Deklaration / Initialisierung etc.
            //Ausgabe eines Textes
            Console.WriteLine("Hello World!");

            //Deklaration einer Varible
            int alter; //Im Arveitsspeicher wird der Variablen-Bereich reserviert 

            //Wert wird zugewiesen -> Initialisierung
            alter = 38;

            Console.WriteLine(alter); //Ausgabe einer Variable


            //tring ist eine Zeichenkette
            string stadt = "Frankfurt am Main";
            //shortcut zu WriteLine -> cw + tab + tab 
            Console.WriteLine(stadt);

            int doppelteAlter = alter * 2; //66 
            Console.WriteLine("Doppeltes Alter: " + doppelteAlter);
            #endregion


            #region Zeichen und Text
            //Beispiel Char-Variablen

            char myLetter = 'A'; //wichtige einfaches Hochkomma -> Ascii-Wert ist Basis (65) 

            string satz = "Ich bin " + alter + " und wohne in " + stadt;
            Console.WriteLine(satz);

            //Stringausgaben Varianten:

            Console.WriteLine("Ich bin " + alter + " und wohne in " + stadt);
            
            //Performantere Variabte
            Console.WriteLine("Ich bin {0} und wohne in {1}", alter, stadt);
            Console.WriteLine($"Ich bin {alter} und wohne in {stadt}");
            #endregion

            #region Ausgabe und Berechnung 

            int a = 45;
            int b = 12;
            Console.WriteLine($"{a} + {b} = {a+b}"); // 45 + 12 = 57

            #endregion


            #region Escape-Zeichen
            //Was ist ein Escape-Zeichen
            Console.WriteLine("Hallo liebe Teilnehmer, \nich hoffe der Kurs wird Euch allen gefallen \t :-)");

            string pfad = "C:\\Windows\\Temp"; //doppelte Backslashes stellen ein einfaches Backslash ab. 
            string pfad1 = @"C:\Windows\Temp"; //mit einem @-Zeichen kann man die Escape-Zeichen deaktivieren (Verbatim String) 

            string pfad2 = $@"{pfad1}\SubFolder"; //C:\Windows\Temp\SubFolder
            #endregion



            #region Eingabe eines Strings

            Console.WriteLine("Bitte geben Sie Ihren Namen ein: ");
            //Eingabe eines Namens
            string eingabe = Console.ReadLine(); //Lese komplette Eingabe ein.  (bis zum Ende der Zeile) 
            Console.WriteLine($"Dein Name ist {eingabe}" ); //Ausgabe der Eingabe 
            #endregion

            #region Eingabe eines Integers
            Console.WriteLine("Bitte gebe eine Lieblingszahl ein: ");
            string zahlsAlsString = Console.ReadLine(); //Eingabe wird als String interpretiert 


            //Wandle einen Text in eine Zahl um
            int zahl1 = int.Parse(zahlsAlsString);

           

            //ältere Variant
            int zahl2 = Convert.ToInt32(zahlsAlsString); //ältere Variante 

            int zahl3 = zahl1 + zahl2;
            Console.WriteLine(zahl3); //44 




            int formattedZahl;
            if (int.TryParse(zahlsAlsString, out formattedZahl))
            {
                //Wenn ich hier her komme, weiß ich , dass das formatieren/parsen geklappt hat
                Console.WriteLine(formattedZahl);
            }

            #endregion


            #region Umwandlung von Zahlenwerten
            int zahl4 = Convert.ToInt32(78.45); // 
            Console.WriteLine(zahl4);

            double kommazahl = 71.54; 
            zahl4 = Convert.ToInt32(kommazahl);
            Console.WriteLine(zahl4);

            double kommazahl2 = zahl4; //Ganzzahl wird einer Kommazahl übergeben 
            Console.WriteLine(kommazahl2);
            #endregion
        }
    }
}
