using System;
using System.Collections.Generic;

namespace OOP7
{   
    public abstract class Vehicle
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }

        public Vehicle(string brand, string model, int year)
        {
            Brand = brand;
            Model = model;
            Year = year;
        }
        
        public override string ToString()
        {
            return $"Brand: {Brand}, Model: {Model}, Year: {Year}";
        }
    }
    
    public class Car : Vehicle
    {
        public int NumberOfDoors { get; set; }
        public bool IsElectric { get; set; }

        public Car(string brand, string model, int year, int numberOfDoors, bool isElectric) : base(brand, model, year)
        {
            NumberOfDoors = numberOfDoors;
            IsElectric = isElectric;
        }

        public void Drive()
        {
            Console.WriteLine($"{Brand} {Model} is driving!");
        }

        public override string ToString()
        {
            return base.ToString() + $", Number of Doors: {NumberOfDoors}, Electric: {IsElectric}";
        }
    }
    
    public class Bike : Vehicle
    {
        public bool HasGear { get; set; }

        public Bike(string brand, string model, int year, bool hasGear)
            : base(brand, model, year)
        {
            HasGear = hasGear;
        }

        public void Ride()
        {
            Console.WriteLine($"{Brand} {Model} is being ridden!");
        }

        public override string ToString()
        {
            return base.ToString() + $", Has Gear: {HasGear}";
        }
    }
    
    public class Truck : Vehicle
    {
        public int LoadCapacity { get; set; }

        public Truck(string brand, string model, int year, int loadCapacity)
            : base(brand, model, year)
        {
            LoadCapacity = loadCapacity;
        }

        public void Haul()
        {
            Console.WriteLine($"{Brand} {Model} is hauling!");
        }

        public override string ToString()
        {
            return base.ToString() + $", Load Capacity: {LoadCapacity}";
        }
    }
    
    public class VehicleContainer
    {   
        private List<Vehicle> vehicles = new List<Vehicle>();

        public void AddVehicle(Vehicle vehicle)
        {
            vehicles.Add(vehicle);
        }

        public void CountVehicles()
        {
            int cars = 0, bikes = 0, trucks = 0;

            foreach (var vehicle in vehicles)
            {
                switch (vehicle)
                {
                    case Car:
                        cars++;
                        break;
                    case Bike:
                        bikes++;
                        break;
                    case Truck:
                        trucks++;
                        break;
                }
            }

            Console.WriteLine($"Cars: {cars}, Bikes: {bikes}, Trucks: {trucks}");
        }
    }
    
    internal class Program
    {
        public static void Main(string[] args)
        {
            VehicleContainer container = new VehicleContainer();

            Car car = new Car("Tesla", "Model S", 2020, 4, true);
            Bike bike = new Bike("Manufact", "Timur", 2018, true);
            Truck truck = new Truck("Tesla", "CyberTruck", 2024, 1000);

            container.AddVehicle(car);
            container.AddVehicle(bike);
            container.AddVehicle(truck);

            Console.WriteLine(car);
            car.Drive();

            Console.WriteLine(bike);
            bike.Ride();

            Console.WriteLine(truck);
            truck.Haul();

            container.CountVehicles();
        }
    }
}