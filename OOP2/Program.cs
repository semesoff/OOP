using System;
using System.Collections.Generic;

namespace OOP2
{
    public enum TaskType
    {
        Personal,
        Work,
        Cooking,
        Walking,
        Meeting,
        University,
        Study
    }

    public struct TaskInfo
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public TaskType Type { get; set; }
        public bool IsCompleted { get; set; }

        // Конструктор структуры TaskInfo
        public TaskInfo(string name, string description, TaskType type, bool isCompleted)
        {
            Name = name;
            Description = description;
            Type = type;
            IsCompleted = isCompleted;
        }

        // Метод копирования структуры с изменением параметров
        public TaskInfo With(string name = null, string description = null, TaskType? type = null, bool? isCompleted = null)
        {
            return new TaskInfo(
                name ?? Name,
                description ?? Description,
                type ?? Type,
                isCompleted ?? IsCompleted
            );
        }

        // Метод для отображения задачи
        public void DisplayTask()
        {
            Console.WriteLine($"Task: {Name}, Description: {Description}, Type: {Type}, Completed: {IsCompleted}");
        }
    }

    public class TaskManager
    {
        private List<TaskInfo> tasks = new List<TaskInfo>();

        // Добавление новой задачи
        public void AddTask(TaskInfo task)
        {
            tasks.Add(task);
            Console.WriteLine($"Task '{task.Name}' added.");
        }

        // Удаление задачи по имени
        public void RemoveTask(string name)
        {
            tasks.RemoveAll(t => t.Name == name);
            Console.WriteLine($"Task '{name}' removed.");
        }

        // Копирование задачи с измененными параметрами
        public TaskInfo CopyTask(TaskInfo originalTask, string newName = null, string newDescription = null)
        {
            return originalTask.With(newName, newDescription);
        }

        // Отображение всех задач
        public void DisplayAllTasks()
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("No tasks available.");
                return;
            }

            Console.WriteLine("List of tasks:");
            foreach (var task in tasks)
            {
                task.DisplayTask();
            }
        }
    }
    
    internal class Program
    {
        public static void Main(string[] args)
        {
            // Создаем экземпляр TaskManager
            TaskManager taskManager = new TaskManager();

            // Создаем задачи
            TaskInfo task1 = new TaskInfo("Buy groceries", "Buy milk, bread, and eggs", TaskType.Personal, false);
            TaskInfo task2 = new TaskInfo("Finish project", "Complete the project by next week", TaskType.Work, false);

            // Добавляем задачи в менеджер
            taskManager.AddTask(task1);
            taskManager.AddTask(task2);

            // Отображаем все задачи
            taskManager.DisplayAllTasks();

            // Копируем задачу с новыми параметрами
            TaskInfo copiedTask = taskManager.CopyTask(task1, "Buy groceries and fruits", "Include apples and bananas");
            taskManager.AddTask(copiedTask);

            // Отображаем обновленный список задач
            taskManager.DisplayAllTasks();
        }
    }
}