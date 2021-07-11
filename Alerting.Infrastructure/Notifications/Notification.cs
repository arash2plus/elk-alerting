using Alerting.DomainModel.Interfaces;
using Alerting.DomainModel.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alerting.Infrastructure.Notifications
{
    public class Notification : INotification
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;
        public Notification(IConfiguration configuration, IUserRepository userRepository)
        {
            _configuration = configuration;
            _userRepository = userRepository;
        }

        public async Task SendNotification(Root logModel)
        {
            string applicationName = logModel.events[0].Properties.ApplicationName;
            string message = logModel.events[0].MessageTemplate;
            var timeSpan = logModel.events[0].Timestamp;
            var index = logModel.index;

            if (string.IsNullOrEmpty(index))
                index = $"{DateTime.Now.Date}.{DateTime.Now.Month}.{DateTime.Now.Day}";

            var timestamp = logModel.Timestamp;
            var users = _userRepository.GetUsersByApplicationName(applicationName);
            if (users.Count() != 0)
            {
                await SendEmail($"Error in {applicationName} System at {timeSpan}",
                    "Error message : " + message + "\n\n"
                    + "To see your detail error follow path then run query" + "\n\n"
                    + "http://192.168.250.50:5601/app/dev_tools#/console " + "\n\n"
                    + "Query: " + "\n\n"
                    + $"GET {index}/_search" + "\n"
                    + "\t{\"query\": {" + "\n"
                        + "\t\t\"match\": {" + "\n"
                            + $"\t\t\t\"@timestamp\": \"{timestamp}\"" + "\n"
                        + "\t\t}" + "\n"
                    + "\t}" + "\n"
                + "}" + "\n\n\n\n"
                + "Thank you"
                ,
                    users.Select(x => x.Email).ToList());
            }
        }

        private async Task SendEmail(string subject, string content, List<string> tos)
        {
            string smtpServer = _configuration.GetSection("AlertConfig:smtpServer").Value;
            string clientCredentialUserName = _configuration.GetSection("AlertConfig:clientCredentialUserName").Value; ;
            string clientCredentialUserPassword = _configuration.GetSection("AlertConfig:clientCredentialUserPassword").Value;
            EmailManager mailMan = new EmailManager(smtpServer);

            EmailSendConfigure myConfig = new EmailSendConfigure();

            myConfig.ClientCredentialUserName = clientCredentialUserName;
            myConfig.ClientCredentialPassword = clientCredentialUserPassword;
            myConfig.TOs = tos;
            myConfig.CCs = new string[] { };
            myConfig.From = "ELK-Notification@nsedna.com"; //"m.rafiee@nsedna.com";
            myConfig.FromDisplayName = "ElkNotification";
            myConfig.Priority = System.Net.Mail.MailPriority.Normal;
            myConfig.Subject = subject;

            EmailContent myContent = new EmailContent();
            myContent.Content = content;

            await mailMan.SendMail(myConfig, myContent);
        }


    }
}
