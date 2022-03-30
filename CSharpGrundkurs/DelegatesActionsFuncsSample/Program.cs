using System;

namespace DelegatesActionsFuncsSample
{

    public delegate int ChangeNumber(int number); //Delegates arbeiten in Verbindung mit Methoden
    public delegate void MultipleDelegate();

    internal class Program
    {
        static void Main(string[] args)
        {
            #region Delegate Sample1
            ChangeNumber changeNumber = new ChangeNumber(ChangeNumberWithOffSet5); //Übergabe eines Funktionzeigers
            //Mit += können wir ein Delegate  eine weitere Methode hinzuüfgen
            changeNumber += ChangeNumberWithOffSet10;
            Console.WriteLine(changeNumber(12));
            #endregion

            #region Delegate with mulitple Methods
            MultipleDelegate multipleDelegate = new MultipleDelegate(MethodeA);
            multipleDelegate += MethodeB;
            multipleDelegate += MethodeC;
            multipleDelegate();
            #endregion

            //Action ist ein generisches Delegate
            //Kann nur mit Methoden zusammenarbeiten, die ein VOID zurückgeben.
            Action<string, string> actionDelegate = new Action<string, string>(VorUndNachname);
            actionDelegate("Peter", "Lustig");



            Func<int, int> offSetFunc = new Func<int, int>(ChangeNumberWithOffSet5);
            Console.WriteLine(offSetFunc(12)); //17
            Console.ReadLine();
        }

        public static int ChangeNumberWithOffSet5(int value)
        {
            return value += 5;
        }

        public static int ChangeNumberWithOffSet10(int value)
        {
            return value += 10;
        }


        public static void MethodeA()
        {
            Console.WriteLine("Methode A");
        }

        public static void MethodeB()
        {
            Console.WriteLine("Methode B");
        }

        public static void MethodeC()
        {
            Console.WriteLine("Methode C");
        }


        public static void VorUndNachname(string vorname, string nachname)
            => Console.WriteLine($"{vorname} {nachname}");
    }
}
