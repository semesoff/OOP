﻿using System;

namespace OOP {

    class Person {
        // приватные поля класса
        private string name;
        private int age;
        
        // конструктор класса
        public Person(string name, int age) {
            this.name = name;
            this.age = age;
        }
        
        // метод для отображения введённых данных
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