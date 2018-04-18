using System.Collections.Generic;
using System.Collections.ObjectModel;
using VirtoCommerce.Platform.Core.Notifications;


namespace VirtoCommerce.Platform.Data.Repositories
{
	public interface INotificationRepository
	{
		ICollection<Notification> Notifications { get; }

        void Add<T>(T item) where T : class;
	}
}
