using System;

namespace OOP {

    class Person {
        private string name;
        private int age;

        public Person(string name, int age) {
            this.name = name;
            this.age = age;
        }

        public void DisplayInfo() {
            Console.WriteLine($"Name: {name}\nAge: {age}");
        }
    }

    class Program {
        static void Main() {
            Person person1 = new Person("Elon", 53);
            person1.DisplayInfo();
            Person person2 = new Person("Pavel", 39);
            person2.DisplayInfo();
        }
    }

}