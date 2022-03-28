using FahrzeugLib;
using System;

namespace FahrzeugConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ExlectroCar electroCar = new ExlectroCar();
            electroCar.LackiereAuto(); //public Methode
            electroCar.PublicGeschwindigkeit = 12;
        }
    }
}
