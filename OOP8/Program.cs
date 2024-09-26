using System;

namespace OOP8
{
    abstract class Device
    {
        public abstract string Name { get; set; }
        public abstract string Brand { get; set; }
        
        public abstract void TurnOn();
        public abstract void TurnOff();
        
        public virtual void ShowInfo()
        {
            Console.WriteLine($"Device: {Name}, Brand: {Brand}");
        }
    }
    
    class Smartphone : Device
    {
        public override string Name { get; set; }
        public override string Brand { get; set; }
        public string OperatingSystem { get; set; }

        public Smartphone(string name, string brand, string os)
        {
            Name = name;
            Brand = brand;
            OperatingSystem = os;
        }

        public override void TurnOn()
        {
            Console.WriteLine($"{Name} by {Brand} is now ON.");
        }

        public override void TurnOff()
        {
            Console.WriteLine($"{Name} by {Brand} is now OFF.");
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Operating System: {OperatingSystem}");
        }
    }

    class Laptop : Device
    {
        public override string Name { get; set; }
        public override string Brand { get; set; }
        public double ScreenSize { get; set; }

        public Laptop(string name, string brand, double screenSize)
        {
            Name = name;
            Brand = brand;
            ScreenSize = screenSize;
        }

        public override void TurnOn()
        {
            Console.WriteLine($"{Name} by {Brand} with a {ScreenSize}-inch screen is now ON.");
        }

        public override void TurnOff()
        {
            Console.WriteLine($"{Name} by {Brand} is now OFF.");
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Screen Size: {ScreenSize} inches");
        }
    }

    class SmartLamp : Device
    {
        public override string Name { get; set; }
        public override string Brand { get; set; }
        public string LightColor { get; set; }

        public SmartLamp(string name, string brand, string color)
        {
            Name = name;
            Brand = brand;
            LightColor = color;
        }

        public override void TurnOn()
        {
            Console.WriteLine($"{Name} by {Brand} is now ON with {LightColor} light.");
        }

        public override void TurnOff()
        {
            Console.WriteLine($"{Name} by {Brand} is now OFF.");
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Light Color: {LightColor}");
        }
    }
    
    class Program
    {
        static void TestDevice(Device device)
        {
            device.ShowInfo();
            device.TurnOn();
            device.TurnOff();
        }

        static void Main(string[] args)
        {
            Smartphone smartphone = new Smartphone("IPhone 16", "Apple", "IOS");
            Laptop laptop = new Laptop("MacBook Pro", "Apple", 16.0);
            SmartLamp lamp = new SmartLamp("Mi Lamp", "Xiaomi", "Warm White");
            
            TestDevice(smartphone);
            TestDevice(laptop);
            TestDevice(lamp);
        }
    }
}