using System;

namespace MyLib
{

    public class MyNumberZeroExeption : Exception
    {
        public MyNumberZeroExeption(string msg)
            : base(msg)
        {

        }
    }

    public class StringToInt
    {
        public int Convert (string str)
        {
            int zahl;
            try
            {
                

                zahl = int.Parse(str);//Achtung hier können Fehler beim parsen auftreten.

                if (zahl == 0)
                    throw new MyNumberZeroExeption("Zahl hat den Wert 0");
            }
            catch (FormatException formatException)
            {

                Console.WriteLine("Die Eingabe muss eine Zahl sein " + formatException.Message);
                throw new FormatException(formatException.Message.ToString()); //ToString = Fehlermeldung + Stacktrace
            }
            catch (OverflowException overflowException)
            {
                Console.WriteLine("Der Eingabewert muss sich innerhalb eines Integers-Zahlenraum befinden" + overflowException.Message);

                throw new OverflowException(overflowException.Message); //Allgemeine vorgelegte Fehlermeldung 
            }
            catch (MyNumberZeroExeption numberZeroExeption)
            {
                Console.WriteLine("Wert 0 wurde eingegeben " + numberZeroExeption.StackTrace); //Stacktrace gibt den Programmfluss bekannt, in der die Exception entsteht

                throw new MyNumberZeroExeption("Der eingegebene Wert ist die Zahl 0");
            }
            //Allgemeine Catch-Block fangen jede Excpetion ab (es gilt der Polymorphismus)
            catch (Exception ex) //Exception muss ganz unten stehen
            {
                Console.WriteLine("Unerwarteteder Fehler" + ex.Message);
                throw new Exception(str);
            }
            finally //wird immer augerufen
            {
                Console.WriteLine("finally wird immer ausgefürt");
            }

            return zahl;
        }
    }
}
