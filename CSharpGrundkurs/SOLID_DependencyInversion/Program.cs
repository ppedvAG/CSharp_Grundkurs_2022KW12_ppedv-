using System;

namespace SOLID_DependencyInversion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ICarService service = new CarService();



            //Für Testzwecke Tag 4,5 (Testen) 
            ICar mockCar = new MockCar();

            //Produktives Object
            ICar car = new Car();

            //Testen Tag 4,5
            service.Repair(mockCar);

            //Produktive Implementierung
            service.Repair(car);
        }
    }


    #region BadCode
    //Programmierer A: 5 Tage (Fängt an Tag 1 an und an Tag 5 fertig) 
    public class BadCar
    {
        public string Marke { get; set; }
        public string Modell { get; set; }  
        public int Baujahr { get; set; }    
    }

    //Programmierer B: 3 Tage (Fängt an Tag 5/6 und arbeitet bis Tag 8)
    public class BadCarService
    {
        public void Repair(BadCar car)
        {
            //repariere Auto
        }
    }
    #endregion

    #region Best Practice
    //Tag 1: Entwickler setzen sich zusammen und erstellen mithilfe der Sepzifikation die Interface -Strukturen
    //Code - First 
    public interface ICar
    {
        string Marke { get; set; }
        string Modell { get; set; }
        int Baujahr { get; set; }

        //Version 2 hat Farbe
        string Farbe { get; set; }  
    }

    public interface ICarVersion2 : ICar
    {
        public bool AutonomesFahren { get; set; }
    }

    public interface ICarService
    {
        void Repair(ICar car);
    }


    //Programmierer A -> Tag 1 - 5
    public class Car : ICar
    {
        public string Marke { get; set; }
        public string Modell { get; set; }
        public int Baujahr { get; set; }
        public string Farbe { get; set; }
    }


    //Programmierer B -> Tag 1-3
    public class CarService : ICarService
    {
        public void Repair(ICar car) //Lose Kopplung = CarService kennt nicht die Klasse Car
        {
            //repariere Auto
        }
    }

    //Programmierer B kann vorab mit Mock-Objects arbeiten 

    public class MockCar : ICar
    {
        public string Marke { get; set; } = "VW";
        public string Modell { get; set; } = "Polo";
        public int Baujahr { get; set; } = 2020;
        public string Farbe { get; set; }
    }

    #endregion
}
