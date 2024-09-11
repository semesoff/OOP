using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace OOP3
{
    [Serializable]
    public class Student
    {
        private string _firstName;
        private string _lastName;
        private int _age;
        private double _averageGrade;

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("First name cannot be empty.");
                    return;
                }
                _firstName = value;
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("Last name cannot be empty.");
                    return;
                }
                _lastName = value;
            }
        }

        public int Age
        {
            get { return _age; }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Age cannot be negative.");
                    return;
                }
                _age = value;
            }
        }
        
        public double AverageGrade
        {
            get { return _averageGrade; }
            set
            {
                if (value < 0.0 || value > 10.0)
                {
                    Console.WriteLine("Average grade must be between 0 and 10.");
                    return;
                }
                _averageGrade = value;
            }
        }
        
        public Student() {}
        
        public Student(string firstName, string lastName, int age, double averageGrade)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            AverageGrade = averageGrade;
        }
    }

    public class University
    {
        private List<Student> _students = new List<Student>();

        public void AddStudent(Student student)
        {
            if (student == null)
            {
                Console.WriteLine("Student cannot be null.");
                return;
            }
            _students.Add(student);
        }
        
        public void RemoveStudent(Student student)
        {
            if (student == null)
            {
                Console.WriteLine("Student cannot be null.");
                return;
            }
            _students.Remove(student);
        }
        
        public Student FindStudent(string firstName, string lastName)
        {
            return _students.FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName);
        }
        
        public List<Student> GetAllStudents()
        {
            return _students;
        }
    }
    
    public class StudentsRepository
    {
        private readonly string _filePath;

        public StudentsRepository(string filePath)
        {
            _filePath = filePath;
        }

        public void SaveStudents(IEnumerable<Student> students)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Student>));
            using (StreamWriter writer = new StreamWriter(_filePath))
            {
                serializer.Serialize(writer, students);
            }
        }

        public List<Student> LoadStudents()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Student>));
            using (StreamReader reader = new StreamReader(_filePath))
            {
                return (List<Student>)serializer.Deserialize(reader);
            }
        }
    }
    
    internal class Program
    {
        public static void Main(string[] args)
        {
            University university = new University();
            university.AddStudent(new Student("Oleg", "Tinkoff", 40, 10));
            university.AddStudent(new Student("Alex", "Shmatov", 99, 5));
            university.AddStudent(new Student("Timur", "Manufacturer", 11, 0));
            Console.WriteLine(university.FindStudent("Alex", "Shmatov"));

            StudentsRepository studentsRepository = new StudentsRepository("list.xml");
            studentsRepository.SaveStudents(university.GetAllStudents());
            Console.WriteLine(studentsRepository.LoadStudents());
        }
    }
}
