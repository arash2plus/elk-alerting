using Alerting.Application.Interface;
using Alerting.DomainModel.Interfaces;
using Alerting.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Alerting.Application.Services
{
    public class NotificationService : INotificationService
    {
        private readonly INotification _iNotification;
        public NotificationService(INotification iNotification)
        {
            _iNotification = iNotification;
        }
        public Task SendEmail(Root logModel)
        {
            return _iNotification.SendNotification(logModel);
        }
    }
}
