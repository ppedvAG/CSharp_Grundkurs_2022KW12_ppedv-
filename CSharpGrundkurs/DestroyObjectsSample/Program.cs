using System;

namespace DestroyObjectsSample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Third t = new Third();
            t = null;

            Console.ReadLine();
        }
    }

    class First
    {
        ~First()
        {
            System.Diagnostics.Debug.WriteLine("First's finalizer is called.");
        }
    }

    class Second : First
    {
        ~Second()
        {
            System.Diagnostics.Debug.WriteLine("Second's finalizer is called.");
        }
    }

    class Third : Second
    {
        ~Third()
        {
            System.Diagnostics.Debug.WriteLine("Third's finalizer is called.");
        }
    }

    /* 
    Test with code like the following:
        Third t = new Third();
        t = null;

    When objects are finalized, the output would be:
    Third's finalizer is called.
    Second's finalizer is called.
    First's finalizer is called.
    */
}
