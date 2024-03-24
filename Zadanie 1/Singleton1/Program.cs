using System;
using System.Collections.Generic;

namespace Singleton1
{
    class Programme
    {
        static void Main(string[] args)
        {
            NotificationLog log = NotificationLog.GetInstance();
            log.AddNotification("Notification 1");
            log.AddNotification("Notification 2");

            log.RenderNotifications();
        }
    }

    public class NotificationLog
    {
        private static NotificationLog _instance;

        private readonly List<string> _notifications = new List<string>();

        private NotificationLog()
        {
        }

        public static NotificationLog GetInstance()
        {
            if (_instance is null)
                _instance = new NotificationLog();

            return _instance;
        }

        public void AddNotification(string notification)
        {
            _notifications.Add(notification);
        }

        public void RenderNotifications()
        {
            foreach (string notification in _notifications)
            {
                Console.WriteLine(notification);
            }

            return;
        }
    }
}
