using System;
using System.Collections.Generic;

namespace OOP9
{
    abstract class Notification : IComparable<Notification>
    {
        public string Message { get; set; }
        public DateTime Date { get; set; }

        public Notification(string message, DateTime date)
        {
            Message = message;
            Date = date;
        }
        
        public int CompareTo(Notification other)
        {
            return Date.CompareTo(other.Date);
        }

        public abstract void Display();
    }
    
    class NotificationContainer<T> where T : Notification, IComparable<T>
    {
        private List<T> notifications = new List<T>();

        // Добавление уведомления в контейнер
        public void Add(T notification)
        {
            notifications.Add(notification);
        }

        // Получение всех уведомлений
        public List<T> GetAll()
        {
            return notifications;
        }

        // Проверка наличия уведомлений
        public bool HasNotifications()
        {
            return notifications.Count > 0;
        }

        // Сортировка уведомлений
        public void Sort()
        {
            notifications.Sort();
        }
    }
    
    class EmailNotification : Notification
    {
        public string EmailAddress { get; set; }

        public EmailNotification(string message, DateTime date, string emailAddress)
            : base(message, date)
        {
            EmailAddress = emailAddress;
        }

        public override void Display()
        {
            Console.WriteLine($"Email to {EmailAddress}: {Message} at {Date}");
        }
    }
    
    class SMSNotification : Notification
    {
        public string PhoneNumber { get; set; }

        public SMSNotification(string message, DateTime date, string phoneNumber)
            : base(message, date)
        {
            PhoneNumber = phoneNumber;
        }

        public override void Display()
        {
            Console.WriteLine($"SMS to {PhoneNumber}: {Message} at {Date}");
        }
    }
    
    class PushNotification : Notification
    {
        public string AppName { get; set; }

        public PushNotification(string message, DateTime date, string appName)
            : base(message, date)
        {
            AppName = appName;
        }

        public override void Display()
        {
            Console.WriteLine($"Push from {AppName}: {Message} at {Date}");
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            // Создаем контейнеры для разных типов уведомлений
            var emailContainer = new NotificationContainer<EmailNotification>();
            var smsContainer = new NotificationContainer<SMSNotification>();
            var pushContainer = new NotificationContainer<PushNotification>();

            // Добавляем уведомления в наши контейнеры
            emailContainer.Add(new EmailNotification("Email #1", DateTime.Now.AddHours(-3), "email@example.com"));
            emailContainer.Add(new EmailNotification("Email #2", DateTime.Now.AddHours(-1), "email2@example.com"));

            smsContainer.Add(new SMSNotification("SMS #1", DateTime.Now.AddMinutes(-30), "123-456-789"));
            smsContainer.Add(new SMSNotification("SMS #2", DateTime.Now.AddMinutes(-60), "987-654-321"));

            pushContainer.Add(new PushNotification("Push #1", DateTime.Now.AddDays(-1), "AppA"));
            pushContainer.Add(new PushNotification("Push #2", DateTime.Now.AddHours(-2), "AppB"));

            // Проверка наличия элементов в контейнерах
            Console.WriteLine($"Email container has notifications: {emailContainer.HasNotifications()}");
            Console.WriteLine($"SMS container has notifications: {smsContainer.HasNotifications()}");
            Console.WriteLine($"Push container has notifications: {pushContainer.HasNotifications()}");

            // Получение и вывод элементов из контейнеров
            Console.WriteLine("\nEmails:");
            foreach (var email in emailContainer.GetAll())
            {
                email.Display();
            }

            Console.WriteLine("\nSMS:");
            foreach (var sms in smsContainer.GetAll())
            {
                sms.Display();
            }

            Console.WriteLine("\nPush Notifications:");
            foreach (var push in pushContainer.GetAll())
            {
                push.Display();
            }

            // Сортировка уведомлений по дате
            Console.WriteLine("\nSorted Emails:");
            emailContainer.Sort();
            foreach (var email in emailContainer.GetAll())
            {
                email.Display();
            }
        }
    }
}