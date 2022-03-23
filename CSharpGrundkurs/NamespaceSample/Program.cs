using NamespaceSample.ErstesNamespace;
using Second = NamespaceSample.ZweitesNamespace;
using Third = NamespaceSample.DrittesNamespace;
using System;

namespace NamespaceSample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Impliziete Definition -> Klasse wird anhand der using aufgelöst
            MeineKlasse1 meineKlasse1 = new MeineKlasse1();

            //Explizietes ansprechen einer Klasse mithilfe des Namespaces und Klassenname
            NamespaceSample.ErstesNamespace.MeineKlasse1 meineKlasse1AusErstesNamespace = new NamespaceSample.ErstesNamespace.MeineKlasse1();
            NamespaceSample.ZweitesNamespace.MeineKlasse1 meineKlasse1AusZweitenNamespace = new NamespaceSample.ZweitesNamespace.MeineKlasse1();


            Second.MeineKlasse1 myClass1 = new Second.MeineKlasse1();
            Third.MeineKlasse1 myClass2 = new Third.MeineKlasse1();
        }
    }
}


namespace AppName.DataAccess
{
    // Klassendefinitionen -> Repository Pattern / UnitOfWork Pattern
}

namespace AppName.DataAccess.Entites
{
    //Entities oder POCO Objects
}
