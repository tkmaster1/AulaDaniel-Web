using ProjetoDanielEx.Web.UI.Application.BaseService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoDanielEx.Web.UI.Application.BaseService
{
    public class NotificationHandler : INotificationHandler<Notification>
    {
        #region properties
       
        private List<Notification> _notifications;
        public IReadOnlyCollection<Notification> Notifications => _notifications;

        public bool HasNotifications => _notifications.Any();

        #endregion

        #region Constructor

        public NotificationHandler()
        {
            _notifications = new List<Notification>();
        }

        #endregion

        #region Methods

        public Task Handle(Notification notification)
        {
            _notifications.Add(notification);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _notifications = new List<Notification>();
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
