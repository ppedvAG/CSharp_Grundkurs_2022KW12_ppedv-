using System;

namespace GeoVirtualSample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Die Klasse object ist in .NET die oberste Basibsklasse von ALLEN 

            BenAndJerryICe benAndJerryICe = new BenAndJerryICe();
            Console.WriteLine(benAndJerryICe.ToString());

            Haribo haribo = new();
            Console.WriteLine(haribo.ToString());
            #endregion



            DerivedClass derivedClass = new DerivedClass();
            derivedClass.Name = "Harry Weinfurth";


            Circle circle = new Circle(5);
            Console.WriteLine(circle.Area());

            Sphere sphere = new Sphere(5);
            Console.WriteLine(sphere.Area());

            Cylinder cylinder = new Cylinder(5, 3);
            Console.WriteLine(cylinder.Area());
        }
    }
    #region Virtual Properties
    public class BaseClass
    {
        //private string name; -> wird beim Kompilieren reingeneriert (nur bei Auto-Properties) 

        //Virtual Auto Property -> Bedeutet: Variable wird beim kompilieren hinzugefügt
        public virtual string Name { get; set; } //Wenn wir die Base-Name Property verwenden, wird eine Variable 
    }

    public class DerivedClass : BaseClass
    {
        private string name;

        public override string Name 
        {
            get
            {
                return name;
            }
            set
            {
                if(!string.IsNullOrEmpty(value))
                {
                    name = value;
                }
            }
        }
    }
    #endregion


    #region Shape -> GeoForms
    public class Shape
    {
        public const double PI = Math.PI;


        //DEfault Konstruktor
        public Shape()
        {

        }

        public Shape(double x, double y)
        {
            X = x;
            Y = y;
        }


        public double X { get; set; }
        public double Y { get; set; }

        public virtual double Area()
        {
            return X * Y;
        }
    }

    public class Circle : Shape
    {
        public Circle(double r)
            :base(r, 0)
        {

        }

        public override double Area()
        {
            return PI * X * X;
        }
    }

    public class Sphere : Shape
    {
        public Sphere(double r) : base(r, 0)
        {
        }

        public override double Area()
        {
            return 4 * PI * X * X;
        }
    }

    public class Cylinder : Shape
    {
        public Cylinder(double r, double h) : base(r, h)
        {
        }

        public override double Area()
        {
            return 2 * PI * X * X + 2 * PI * X * Y;
        }
    }


    #endregion


    public class Haribo
    {
         
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override string ToString()
        {
            return "Haribo mach Programmierer froh";
        }

        public override int GetHashCode()
        {
            return 0;
        }
    }

    public class BenAndJerryICe
    {

    }
}
