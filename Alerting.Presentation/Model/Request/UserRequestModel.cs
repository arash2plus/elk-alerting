using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alerting.Presentation.Model.Request
{
    public class UserRequestModel
    { 
        public string Email { get; set; }
        public int ApplicationId { get; set; }
        public bool Enable { get; set; }
    }
}
