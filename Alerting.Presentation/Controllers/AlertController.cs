using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alerting.DomainModel.Interfaces;
using Alerting.DomainModel.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Alerting.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlertController : ControllerBase
    {
        private readonly INotification _notification;
        public AlertController(INotification notification)
        {
            _notification = notification;
        }

        [Route("NotificationError")]
        [HttpPost]
        public   IActionResult NotificationError([FromBody] Root log)
        {
            if (log.events==null)
                return NotFound();

              _notification.SendNotification(log);

            return Ok();

        }
    }
}
