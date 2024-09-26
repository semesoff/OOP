using System;
using System.Collections.Generic;

namespace OOP5
{
    class Human
    {
        private static int humanCounter = 0;
        public int PersonalId { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }

        public Human(string fullName, DateTime birthDate)
        {
            PersonalId = ++humanCounter;
            FullName = fullName;
            BirthDate = birthDate;
            // автоматически добавляем в List нового человека
            PeopleDatabase.AddPerson(this);
        }
    }
    
    class Student : Human
    {
        public int GradeBookNumber { get; private set; } // номер зачетки студента
        public University University { get; private set; }

        public Student(string fullName, DateTime birthDate, University university) 
            : base(fullName, birthDate)
        {
            University = university;
            // присвоение номера зачетки
            GradeBookNumber = university.AssignGradeBookNumber();
            university.AddStudent(this); //добавление студента в университет
        }
    }
    
    class University
    {
        private static int gradeBookCounter = 0;
        public string Name { get; private set; }
        private List<Student> students = new List<Student>();

        public University(string name)
        {
            Name = name;
        }

        public int AssignGradeBookNumber()
        {
            return ++gradeBookCounter;
        }

        public void AddStudent(Student student)
        {
            students.Add(student);
        }

        public void GetStudentByGradeBookNumber(int gradeBookNumber)
        {
            foreach (Student student in students)
            {
                if (student.GradeBookNumber == gradeBookNumber)
                {
                    Console.WriteLine($"Студент: {student.FullName}, Университет: {Name}, Номер зачетки: {student.GradeBookNumber}");
                    return;
                }
            }
            Console.WriteLine("Студент с таким номером зачетки не найден.");
        }
    }
    
    static class PeopleDatabase
    {
        private static Dictionary<int, Human> people = new Dictionary<int, Human>();

        public static void AddPerson(Human person)
        {
            people[person.PersonalId] = person;
        }

        public static Human GetPersonById(int id)
        {
            if (people.ContainsKey(id))
            {
                return people[id];
            }
            throw new Exception("Человек с таким ID не найден.");
        }
    }
    
    class Program
    {
        public static void Main(string[] args)
        {
            University university1 = new University("Московский политехнический университет");
            University university2 = new University("ВШЭ");

            Student student1 = new Student("Иванов Семён Андреевич", new DateTime(1920, 1, 13), university1);
            Student student2 = new Student("Фабрикант Тимур Романович", new DateTime(1920, 1, 13), university1);
            Student student3 = new Student("Шматов Алексей Михайлович", new DateTime(1920, 1, 13), university2);
        
            Human person = PeopleDatabase.GetPersonById(1);
            Console.WriteLine(person.FullName);
            
            university1.GetStudentByGradeBookNumber(1);
            university1.GetStudentByGradeBookNumber(2);
            university1.GetStudentByGradeBookNumber(3);
            university2.GetStudentByGradeBookNumber(1);
            university2.GetStudentByGradeBookNumber(3);
        }
    }
}