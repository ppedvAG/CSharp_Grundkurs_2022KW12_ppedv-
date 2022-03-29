using System;
using System.Text;


namespace StringBuilderDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string meinLangsamerString = "Hallo "; //hier wird feste länge des String im Arbeitsspeicher festgeleft (Zeichen) 

            //1.) reserviert neuen Arbeitsspeicher mit neuer größe (Hallo Welt) ->9 Zeichen
            //2.) kopiere ich aus dem alten Speicherbereich 'Hallo ' rüber in den neuen Speicherreich 
            //3.) Fügt den neuen String hinzu
            meinLangsamerString += "Welt";


            //StringBuilder ist schneller als der + Operator in Verbinung mit Strings
            StringBuilder builder =new StringBuilder();
            for (int i = 0; i < 10; i++)
            {
                builder.Append(i.ToString());
            }

            Console.WriteLine(builder.ToString()); //Verknüpfter String wird komplett ausgegeben 
        }
    }
}
