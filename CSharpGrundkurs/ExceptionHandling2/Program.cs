using MyLib;
using System;

namespace ExceptionHandling2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringToInt stringToInt;

            try
            {
                stringToInt = new StringToInt();

                Console.Write("Bitte geben Sie eine Zahl ein: ");
                string eingabe = Console.ReadLine();

                int convertedNumber = stringToInt.Convert(eingabe);
            }
            catch (FormatException formatException)
            {
                Console.WriteLine("In der Lib ist eine Format-Exception aufgetreten." + formatException.Message);
            }
            catch (OverflowException overflowException)
            {
                Console.WriteLine("In der Lib ist eine OverflowException aufgetreten." + overflowException.Message);
            }
            catch (MyNumberZeroExeption ex)
            {
                Console.WriteLine("Meine NumberZeroException " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("In der Lib ist eine Exception aufgetreten." + ex.Message);
            }
            finally
            {

            }
        }
    }
}
