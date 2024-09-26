using System;

namespace OOP6
{   
    class Airplane
    {
        public string Model { get; set; }
        public int Capacity { get; set; }
        public double MaxSpeed { get; set; }

        public string? Airline { get; set; }
        public int? ManufactureYear { get; set; }
        public double? FuelCapacity { get; set; }
    }

    internal class Program
    {   
        static void PrintAirplaneInfo(Airplane airplane)
        {
            Console.WriteLine($"Model: {airplane.Model}");
            Console.WriteLine($"Capacity: {airplane.Capacity}");
            Console.WriteLine($"MaxSpeed: {airplane.MaxSpeed} km/h");

            Console.WriteLine($"Airline: {(airplane.Airline ?? "Данные отсутствуют")}");
            Console.WriteLine($"ManufactureYear: {(airplane.ManufactureYear.HasValue ? airplane.ManufactureYear.Value.ToString() : "Данные отсутствуют")}");
            Console.WriteLine($"FuelCapacity: {(airplane.FuelCapacity.HasValue ? airplane.FuelCapacity.Value.ToString() : "Данные отсутствуют")}");
            Console.WriteLine();
        }
        
        // присвоение значения свойству, если оно null
        static void AssignValueIfNull(Airplane airplane)
        {   
            //если ManufactureYear null, присваиваем 2024
            airplane.ManufactureYear ??= 2024; 
        }
        
        //функция, возвращающая значение свойства или константу, если передан null объект
        static string GetAirline(Airplane? airplane)
        {
            return airplane?.Airline ?? "Unknown Airline"; //объект null или Airline == null
        }
        // возвращает значение nullable свойства или константу, если значение null
        static double GetFuelCapacity(Airplane airplane)
        {   
            //озвращаем константу, если FuelCapacity null
            return airplane.FuelCapacity ?? 10000.0;
        }
        
        public static void Main(string[] args)
        {
            Airplane airplane1 = new Airplane
            {
                Model = "Boeing 747",
                Capacity = 416,
                MaxSpeed = 933.8,
                Airline = "Lufthansa",
                ManufactureYear = 1998,
                FuelCapacity = 238840
            };

            Airplane airplane2 = new Airplane
            {
                Model = "Airbus A320",
                Capacity = 180,
                MaxSpeed = 828,
                Airline = null,
                ManufactureYear = null,
                FuelCapacity = null
            };
            PrintAirplaneInfo(airplane1);
            PrintAirplaneInfo(airplane2);
            
            airplane1.Model = null!; // подавление предупреждения

            //присвоение значения если оно null
            AssignValueIfNull(airplane2);
            Console.WriteLine($"Airline: {GetAirline(airplane2)}");
            Console.WriteLine($"FuelCapacity: {GetFuelCapacity(airplane2)}");
        }
    }
}