using System;

namespace OOP4
{   
    class PersonInfo
    {
        public string FirstName { get; set; }

        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }
        
        private int _age;
        public int Age
        {
            get { return _age; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Age cannot be negative!");
                }
                _age = value;
            }
        }
        
        public bool IsYoung => Age < 25;

        public string GetInfo()
        {
            return $"FirstName: {FirstName}, LastName: {LastName}, Age: {Age}, IsYoung: {IsYoung}";
        }

        public string GetInfo(bool includeIntProperty)
        {
            if (includeIntProperty)
            {
                return GetInfo();
            }
            else
            {
                return $"FirstName: {FirstName}, LastName: {LastName}, IsYoung: {IsYoung}";
            }
        }
    }

    internal class Program
    {
        public static void Main(string[] args)
        {
            PersonInfo person = new PersonInfo
            {
                FirstName = "David",
                LastName = "Goggins",
                Age = 23
            };
            Console.WriteLine(person.GetInfo());
            Console.WriteLine(person.GetInfo(false));
        }
    }
}