using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using VirtoCommerce.Platform.Core.Notifications;
using VirtoCommerce.Platform.Data.Notifications;
using VirtoCommerce.Platform.Data.Repositories;

namespace VirtoCommerce.Notification.Tests
{
    [TestClass]
    public class NotificationTests
    {
        [TestMethod]
        public void RegisterNotificationTest()
        {
            var manager = GetNotificationManager();
            var sendingGateway = GetSendingGateway();

            //Register notification in manager
            manager.RegisterNotificationType(() => new RegistrationEmailNotification(sendingGateway)
            {
                DisplayName = "Registration notification",
                Description = "This notification sends by email to client when he finish registration",
                NotificationTemplate = new NotificationTemplate
                {
                    Body = "Thank you for registration {{ firstname }} {{ lastname }}. Your login - {{ login }}.",
                    Subject = "Thank you!",
                    Language = "en-US"
                }
            });

            //Get instance of RegistrationEmailNotification
            var notification = manager.GetNewNotification<RegistrationEmailNotification>();

            Assert.IsNotNull(notification);
            Assert.AreEqual("Thank you for registration {{ firstname }} {{ lastname }}. Your login - {{ login }}.", notification.NotificationTemplate.Body);
            Assert.AreEqual("Thank you!", notification.NotificationTemplate.Subject);

            //Set parameters of notification, that used in template
            notification.FirstName = "Eugene";
            notification.LastName = "White";
            notification.Login = "SuperUser";

            //Sending notification
            var result = manager.SendNotification(notification);

            Assert.AreEqual("Thank you for registration Eugene White. Your login - SuperUser.", notification.Body);
            Assert.AreEqual("Thank you!", notification.Subject);
            Assert.IsTrue(result.IsSuccess);
        }

        private INotificationManager GetNotificationManager()
        {
            var repositoryFactory = GetRepository();
            var resolver = GetResolver();
            var templateService = GetTemplateService();

            return new NotificationManager(resolver, repositoryFactory, templateService);
        }

        private Func<INotificationRepository> GetRepository()
        {
            return () => new NotificationRepository();
        }

        private INotificationTemplateResolver GetResolver()
        {
            return new LiquidNotificationTemplateResolver();
        }

        private INotificationTemplateService GetTemplateService()
        {
            var mock = new Mock<INotificationTemplateService>();

            return mock.Object;
        }

        private IEmailNotificationSendingGateway GetSendingGateway()
        {
            var mock = new Mock<IEmailNotificationSendingGateway>();

            mock.Setup(x => x.SendNotification(It.IsAny<Platform.Core.Notifications.Notification>())).Returns(new SendNotificationResult { IsSuccess = true });

            return mock.Object;
        }
    }
}
