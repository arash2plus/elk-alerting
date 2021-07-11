using System;
using System.Collections.Generic;
using System.Text;

namespace Alerting.DomainModel.Models
{
   public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public Application application { get; set; }
        public int ApplicationId { get; set; }
        public bool Enable { get; set; }
    }
}
