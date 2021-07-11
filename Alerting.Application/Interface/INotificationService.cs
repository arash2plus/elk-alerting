using Alerting.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Alerting.Application.Interface
{
    public interface INotificationService
    {
        Task SendEmail(Root logModel);
    }
}
