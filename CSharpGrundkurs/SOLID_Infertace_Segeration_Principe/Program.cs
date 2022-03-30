using System;

namespace SOLID_Infertace_Segeration_Principe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }


    #region badCode

    public interface IBadVehicle
    {
        void CanFly();
        void CanDrive();
        void CanSwim();
    }

    public class MultiVehicle : IBadVehicle
    {
        public void CanDrive()
        {
            
        }

        public void CanFly()
        {
            
        }

        public void CanSwim()
        {
            
        }
    }

    public class BadCarVehicle : IBadVehicle
    {
        public void CanDrive()
        {
            
        }

        public void CanFly()
        {
            throw new NotImplementedException();
        }

        public void CanSwim()
        {
            //gab es auch
        }
    }

    #endregion


    #region Best Practice


    public interface IFlyVehicle
    {
        void Fly();
    }

    public interface IDriveVehicle
    {
        void Drive();
    }

    public interface ISwimVehicle
    {
        void Swim();
    }

    public class MultiVehicle2 : IFlyVehicle, IDriveVehicle, ISwimVehicle
    {
        public void Drive()
        {
            
        }

        public void Fly()
        {
            
        }

        public void Swim()
        {
            
        }
    }

    public class AmphibischeVehicle : ISwimVehicle, IDriveVehicle
    {
        public void Drive()
        {
            
        }

        public void Swim()
        {
            
        }
    }
    #endregion
}
