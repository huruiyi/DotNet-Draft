using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using VirtoCommerce.Platform.Core.Notifications;

namespace VirtoCommerce.Platform.Data.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        private ICollection<Notification> _notifications;

        public ICollection<Notification> Notifications { get { return _notifications ?? (_notifications = new Collection<Notification>()); } }

        public void Add<T>(T item) where T : class
        {
            if (item is Notification)
                Notifications.Add(item as Notification);
        }
    }
}
