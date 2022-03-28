using System;
using System.Data.SqlClient;

namespace GeoAbstractSample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

        }
    }


    //Abstrakte Klassen sind Schablonen, die können nicht instanziiert werden (Shape kann als seperates OBjekt nicht erstellt werden)
    //alle abstrakten Methoden und Properties müssen in der abgeleiteten Klasse überschrieben
    //Abstrakte klassen haben die Aufgabe, wie die verebten Klassen aufgebaut (geschnitten sind) 
    public abstract class Shape
    {
        //Properties MÜSSEN in der abgeleiteten Klasse überschrieben werden
        public abstract double X { get; set; }
        public abstract double Y { get; set; }

        

        public Shape(double x, double y)
        {
            X = x; 
            Y = y; 
        }

        public abstract double GetArea(); //GetArea MUSS in der Vererbten Klasse implementiert werden 
    }

    public class Rectangle : Shape
    {
        private double x, y;

        public Rectangle()
            : base(0,0)
        {

        }

        public Rectangle(double x, double y)
            : base(x, y)
        {

        }

        public override double X 
        { 
            get { return x; }
            set
            {
                if (value >= 0)
                {
                    x = value;
                }
            }
        }
        public override double Y { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override double GetArea()
        {
            return X * Y;
        }
    }
}
