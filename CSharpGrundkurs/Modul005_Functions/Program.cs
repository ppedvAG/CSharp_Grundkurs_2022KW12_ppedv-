using System;

namespace Modul005_Functions
{
    internal class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int result = Addieren(11, 22);

            //8.7
            double result1 = Addieren(3.5, 4.1, 1.1);
            Console.WriteLine(result);

            //Params Sample
            result = BildeSumme(11, 22, 33);
            result = BildeSumme(11, 22, 33, 22, 11);

            int[] array = { 1, 2, 3, 4, 5 };


            //optionale Parameter
            result = SubtraktionOptional(50, 33); //c=0 und d=0
            result = SubtraktionOptional(50, 33, 1);//d=0
            result = SubtraktionOptional(50, 33, 11, 22);




            int differenzV = 0;
            //out Variablen
            AddiereUndSubtrahiere(11, 22, differenzV); //differenzV übergibt eine Kopie von sich
            Console.WriteLine(differenzV);  //Wert 0

            int differenz = 0;
            result = AddiereUndSubtrahiere(22, 11, out differenz);

            Console.WriteLine(result);
            Console.WriteLine(differenz);


            string eingabe = Console.ReadLine();
            int convertedInteger = 0;
            
            //Wenn TryParse den Rückgbewert True zurückgibt, hat das Parsen erfolgreich funktioniert
            if (int.TryParse(eingabe, out convertedInteger)) //Das Erbnis meines Parsens, wird in der Variablen convertedInteger hinterlegt
            {
                Console.WriteLine(convertedInteger);
            }



            Console.ReadLine();
        }


        #region Funktionen und Überladungen einer Funktion
        /// <summary>
        /// Methode für das Addieren mit 2 Parameter
        /// </summary>
        /// <param name="a">Ganzahliger Integer Parameter</param>
        /// <param name="b">Ganzahliger Integer Parameter</param>
        /// <returns>Das Ergebnis der Addition</returns>


        //Jede Funktion/Methode besteht aus einem Kopf und einem Körper
        ///Der Kopf besteht aus den MODIFIERN (public static), dem RÜCKGABEWERT (int), dem NAMEN (Addiere) sowie den ÜBERGABEPARAMETERN
        static int Addieren(int a, int b)
        {
            return a + b;
        }

        //static double Addieren(double a, double b) 
        //{
        //    //Code-Block mit geschweiften Klammern kann mehrere Zeilen Code beinhaten
        //    return a + b;
        //}

        //Kürzere Schreibweise (geht nur bei einer Zeile-Code)
        static double Addieren(double a, double b)
            => a + b;



        //Funktion, welche den gleichen Bezeichner haben, nennt man ÜBERLADENE Funktionen. Diese müssen sich in Anzahl und/oder Art der 
        ///Übergabeparameter unterscheiden, damit der Aufruf eindeutig ist.
        static double Addieren(double a, double b, double c)
            => a + b + c;

        static int Subtraktion(int a, int b)
        {
            return a - b;
        }

        static double Subtraktion(int a, double b)
        {
            return a - b;
        }


        #endregion

        #region Params-Beispiel

        //Das PARAMS-Stichwort erlaubt die Übergabe einer beliebige Anzahl von gleichartigen Daten, welche innerhalb
        //der Methode als Array interpretiert werden

        static int BildeSumme(params int[] summanden)
        {
            int summe = 0;

            //for (int i = 0; i < summanden.Length; i++)
            //    summe += summanden[i];

            foreach(int currentSummand in summanden)
            {
                summe += currentSummand;
            }

            return summe;
        }

        #endregion


        #region Optionale Parameter

        //Optionale Parameter -> (Defaultwert
        public static int SubtraktionOptional(int a, int b, int c = 0, int d = 0)
        {
            return a - b - c - d;
        }

        //public static int SubtraktionOptionalA( int c = 0, int d = 0, int a, int b)
        //{
        //    return a - b - c - d;
        //}


        public static int AddiereUndSubtrahiere(int a, int b, int diff)
        {
            diff = a - b;
            return a + b;
        }
        public static int AddiereUndSubtrahiere(int a, int b, out int differenz) //out int übergibt den Speicherplatz der Variablen differenz
        {
            differenz = a - b;
            return a + b;
        }

        #endregion
    }
}
