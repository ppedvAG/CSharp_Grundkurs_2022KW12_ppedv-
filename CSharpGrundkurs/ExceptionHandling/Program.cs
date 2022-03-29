using System;

namespace ExceptionHandling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //tryp block repräsentiert Code, indem ein Fehler potentiell vorkommen kann
            
            try
            {
                Console.Write("Gebe Sie bitte eine Zahl ein: ");
                string eingabe = Console.ReadLine();

                int zahl = int.Parse(eingabe);//Achtung hier können Fehler beim parsen auftreten.
            }
            catch (FormatException formatException)
            {
                
                Console.WriteLine("Die Eingabe muss eine Zahl sein " + formatException.Message);
                LogWithExcpetion("Logen einen Fehler");
            }
            catch (OverflowException overflowException)
            {
                Console.WriteLine("Der Eingabewert muss sich innerhalb eines Integers-Zahlenraum befinden" + overflowException.Message);
            }
            //Allgemeine Catch-Block fangen jede Excpetion ab (es gilt der Polymorphismus)
            catch (Exception ex) //Exception muss ganz unten stehen
            {
                Console.WriteLine("Unerwarteteder Fehler" + ex.Message);
            }
            finally //wird immer augerufen
            {
                Console.WriteLine("finally wird immer ausgefürt");
            }

        }

        public static  void LogWithExcpetion (string msg)
        {
            throw new Exception(msg);
        }
    }
}
