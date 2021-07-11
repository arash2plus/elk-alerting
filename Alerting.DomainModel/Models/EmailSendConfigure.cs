using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace Alerting.DomainModel.Models
{
    public class EmailSendConfigure
    {
        public List<string> TOs { get; set; }
        public string[] CCs { get; set; }
        public string From { get; set; }
        public string FromDisplayName { get; set; }
        public string Subject { get; set; }
        public MailPriority Priority { get; set; }
        public string ClientCredentialUserName { get; set; }
        public string ClientCredentialPassword { get; set; }
    }
}
