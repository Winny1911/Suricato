using SaturdayMP.XPlugins.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace Suricato
{
    public class NotificationObserver : INotificationObserver
    {
        public void NotificationReceived(Notification notification)
        {
            Console.WriteLine(notification.Id);
            Console.WriteLine(notification.Title);
            Console.WriteLine(notification.Message);

           // App.Current.MainPage = new Views.vMarkRegister();

        }
    }
}
