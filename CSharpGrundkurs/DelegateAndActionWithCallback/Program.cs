using System;

namespace DelegateAndActionWithCallback
{

    public delegate void PercentChangeDelegate(int percent);

    public delegate void ShowResultDelegate(string msg);
    internal class Program
    {
        static void Main(string[] args)
        {


            MyApp myApp = new MyApp();


            PercentChangeDelegate percentChangeDelegate = new PercentChangeDelegate(myApp.ShowPercent);
            ShowResultDelegate showResultDelegate = new ShowResultDelegate(myApp.ShowResult);
            Process(percentChangeDelegate, showResultDelegate);


            Console.ReadLine();
        }

        public static void Process(PercentChangeDelegate percentChangeDelegate, ShowResultDelegate showResultDelegate)
        {
            for(int i = 0; i < 100; i++)
            {
                //For-Schleife soll eine Bearbeitung simulieren
                percentChangeDelegate(i); //Hier rufe ich die Methode ShowPercentValue auf

                //ShowPercentValue(i);
            }


            //Am Ende wollen wir mitteilen, dass wir fertig sind 
            showResultDelegate("Sind fertig");
        }

        public static void ShowPercentValue(int percentValue)
            => Console.WriteLine(percentValue);
            
    }

    public class MyApp
    {
        public void ShowPercent(int percent)
            => Console.WriteLine(percent);


        public void ShowResult(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
