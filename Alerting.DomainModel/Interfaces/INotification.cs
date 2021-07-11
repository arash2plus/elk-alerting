using Alerting.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Alerting.DomainModel.Interfaces
{
    public interface INotification
    {
        Task SendNotification(Root logModel);
    }
}
