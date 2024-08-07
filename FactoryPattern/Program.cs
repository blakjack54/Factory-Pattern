using System;

namespace FactoryPattern
{
    public interface IVehicle
    {
        void Drive();
    }

    public class Car : IVehicle
    {
        public void Drive()
        {
            Console.WriteLine("Building a new Car!");
        }
    }

    public class Motorcycle : IVehicle
    {
        public void Drive()
        {
            Console.WriteLine("Building a new Motorcycle!");
        }
    }

    public static class VehicleFactory
    {
        public static IVehicle GetVehicle(int numberOfTires)
        {
            switch (numberOfTires)
            {
                case 2:
                    return new Motorcycle();
                case 4:
                    return new Car();
                // Add more cases for different vehicles if needed
                default:
                    throw new ArgumentException("Invalid number of tires");
            }
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of tires on the vehicle:");

            // Get the number of tires from the user's input
            if (int.TryParse(Console.ReadLine(), out int numberOfTires))
            {
                try
                {
                    // Get the vehicle from the factory
                    IVehicle vehicle = VehicleFactory.GetVehicle(numberOfTires);

                    // Call the Drive method
                    vehicle.Drive();
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
    }
}