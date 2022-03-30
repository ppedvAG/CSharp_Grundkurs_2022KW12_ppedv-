using System;

namespace SOLID_LizkovischesPrinzip
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }


    #region BadCode
    public class BadKirsche
    {
        public string GetColor()
            => "rot";
    }

    public class BadErdbeere : BadKirsche
    {
        public string GetColor()
            => base.GetColor();
    }
    #endregion


    public abstract class Fruits
    {
        public abstract string GetColor();
    }

    public class Kirsche : Fruits
    {
        public override string GetColor()
        {
            return "rot";
        }
    }

    public class Erdbeere : Fruits
    {
        public override string GetColor()
        {
            return "rot";
        }
    }
}
