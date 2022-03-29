using System;
using System.Diagnostics;
using System.Text;

namespace StringBuilderBenchmarkDemo
{
    class Program
    {
        static void Main(string[] args)
        {

           
            string aufbauenderString = string.Empty;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < 100000; i++)
            {
                //int i = 8 (wir befinden uns im 8ten Interval)

                //1234567

                //Aktuell im Speicher -> aufbauenderString [1][2][3][4][5][6][7] - string hat eine Länge von 7

                //Was passiert bei += 
                //1.) Ich reserviere einen neuen Speicherbereich mit der Länge von 8 
                //2.) AufbauenderString(Neue Speicherplatz) ist zuerst leer
                //3.) kopiere [1][2][3][4][5][6][7][]von alten Speicherbereich in den neuen Speicherbereich 
                //4.) nehme den 8ten Wert und hänge es am Ende [1][2][3][4][5][6][7][8]
                aufbauenderString += i.ToString(); //Performance - Killer! 
            }
            stopwatch.Stop();
            long testErgebnis1 = stopwatch.ElapsedMilliseconds;


            Console.WriteLine("Taste drücken......");
            Console.ReadKey();
            
            //using System.Text;
            StringBuilder sb = new StringBuilder(); //intern wird eine art Liste verwenden 

            Stopwatch stopwatch1 = new Stopwatch();
            stopwatch1.Start();

            for (int i = 0; i < 100000; i++)
            {
                sb.Append(i); //Eintrag in Liste
            }
            string output = sb.ToString(); //kompletter String wird ausgelifert 
            stopwatch1.Stop();

            long testErgebnis2 = stopwatch1.ElapsedMilliseconds;

            Console.WriteLine("Benchmark Endergebnis");
            Console.WriteLine($"Ergebnis aus einfachen addieren - Zeit: {testErgebnis1}");
            Console.WriteLine($"Testergebnis - StringBuilder - Zeit: {testErgebnis2}");
            Console.ReadLine();
        }
    }
}
