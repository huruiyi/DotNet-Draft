using System;
using System.Collections.Generic;
using System.Linq;
using Omu.ValueInjecter;
using VirtoCommerce.Platform.Core.Notifications;
using VirtoCommerce.Platform.Data.Repositories;

namespace VirtoCommerce.Platform.Data.Notifications
{
	public class NotificationManager : INotificationManager
	{
		private INotificationTemplateResolver _resolver;
		private Func<INotificationRepository> _repositoryFactory;
		private INotificationTemplateService _notificationTemplateService;

		public NotificationManager(INotificationTemplateResolver resolver, Func<INotificationRepository> repositoryFactory, INotificationTemplateService notificationTemplateService)
		{
			_resolver = resolver;
			_repositoryFactory = repositoryFactory;
			_notificationTemplateService = notificationTemplateService;
		}

		private List<Func<Core.Notifications.Notification>> _notifications = new List<Func<Core.Notifications.Notification>>();

        /// <summary>
        /// Register notification type
        /// </summary>
        /// <param name="notification"></param>
		public void RegisterNotificationType(Func<Core.Notifications.Notification> notification)
		{
            ///Check that this type of notification already not registered
			var notificationType = GetNewNotification(notification().GetType().Name);

			if (notificationType == null)
			{
                ///Adding new type
				_notifications.Add(notification);
			}
		}

        /// <summary>
        /// Get all registered notification types
        /// </summary>
        /// <returns></returns>
		public Core.Notifications.Notification[] GetNotifications()
		{
			return _notifications.Select(x => x()).ToArray();
		}

        /// <summary>
        /// Send notification
        /// </summary>
        /// <param name="notification"></param>
        /// <returns></returns>
		SendNotificationResult INotificationManager.SendNotification(Core.Notifications.Notification notification)
		{
            ///Resolving notification body and subject based on notification template
			ResolveTemplate(notification);

            ///Immediately sends notification
			var result = notification.SendNotification();

			return result;
		}

        /// <summary>
        /// Schedule send notification
        /// </summary>
        /// <param name="notification"></param>
		public void ScheduleSendNotification(Core.Notifications.Notification notification)
		{
            ///Resolving notification body and subject based on notification template
			ResolveTemplate(notification);

            var repository = _repositoryFactory();
            ///Adding notification to log for future sending
			repository.Add(notification);
		}

        /// <summary>
        /// Resolving notification content
        /// </summary>
        /// <param name="notification"></param>
		private void ResolveTemplate(Core.Notifications.Notification notification)
		{
            ///Resolving notification body and subject based on notification template 
			_resolver.ResolveTemplate(notification);
		}

        /// <summary>
        /// Get sending notification by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
		public Core.Notifications.Notification GetNotificationById(string id)
		{
            Core.Notifications.Notification retVal = null;
            var repository = _repositoryFactory();
			var notificationEntity = repository.Notifications.FirstOrDefault(x => x.Id == id);
			if (notificationEntity != null)
			{
				retVal = GetNotificationCoreModel(notificationEntity);
			}

			return retVal;
		}

        /// <summary>
        /// Get registered notification type 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetNewNotification<T>() where T : Core.Notifications.Notification
        {
            return GetNewNotification<T>(null, null, null);
        }

        /// <summary>
        /// Get registered notification type 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
		public Notification GetNewNotification(string type)
		{
			return GetNewNotification(type, null, null, null);
		}

        /// <summary>
        /// Get registered notification type 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="objectId"></param>
        /// <param name="objectTypeId"></param>
        /// <param name="language"></param>
        /// <returns></returns>
		public Notification GetNewNotification(string type, string objectId, string objectTypeId, string language)
		{
			var notifications = GetNotifications();
			var retVal = notifications.FirstOrDefault(x => x.GetType().Name == type);
			if (retVal != null)
			{
				retVal.ObjectId = objectId;
				retVal.ObjectTypeId = objectTypeId;
				retVal.Language = language;
				if (retVal != null)
				{
                    ///Get notification template by notification parameter
					var template = _notificationTemplateService.GetByNotification(type, objectId, objectTypeId, language);
					if (template != null)
					{
						retVal.NotificationTemplate = template;
					}
					else if (retVal.NotificationTemplate == null)
					{
						retVal.NotificationTemplate = new NotificationTemplate();
					}
				}

				if (retVal.NotificationTemplate != null && string.IsNullOrEmpty(retVal.NotificationTemplate.NotificationTypeId))
				{
					retVal.NotificationTemplate.NotificationTypeId = type;
				}
			}

			return retVal;
		}

        /// <summary>
        /// Get registered notification type 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objectId"></param>
        /// <param name="objectTypeId"></param>
        /// <param name="language"></param>
        /// <returns></returns>
		public T GetNewNotification<T>(string objectId, string objectTypeId, string language) where T : Core.Notifications.Notification
		{
			var notifications = GetNotifications();
			return GetNewNotification(typeof(T).Name, objectId, objectTypeId, language) as T;
		}

        /// <summary>
        /// Update sending notification
        /// </summary>
        /// <param name="notification"></param>
		public void UpdateNotification(Core.Notifications.Notification notification)
		{
            var repository = _repositoryFactory();
			repository.Add(notification);
		}

        /// <summary>
        /// Delete sending notificaiton
        /// </summary>
        /// <param name="id"></param>
		public void DeleteNotification(string id)
		{
            var repository = _repositoryFactory();
			var deletedEntity = repository.Notifications.FirstOrDefault(x => x.Id == id);
			if(deletedEntity != null)
			{
				repository.Notifications.Remove(deletedEntity);
			}
		}

    
        /// <summary>
        /// Stop sending notification
        /// </summary>
        /// <param name="ids"></param>
		public void StopSendingNotifications(string[] ids)
		{
            var repository = _repositoryFactory();
			foreach(var id in ids)
			{
				var entity = repository.Notifications.FirstOrDefault(n => n.Id == id);
				if(entity != null)
				{
					entity.IsActive = false;
					repository.Add(entity);
				}
			}
		}

		private Core.Notifications.Notification GetNotificationCoreModel(Notification entity)
		{
			var retVal = GetNewNotification(entity.Type);
			retVal.InjectFrom(entity);

			return retVal;
		}
	}
}
