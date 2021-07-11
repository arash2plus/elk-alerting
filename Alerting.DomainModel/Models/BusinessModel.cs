using System;
using System.Collections.Generic;
using System.Text;

namespace Alerting.DomainModel.Models
{
    public class BusinessModel<T>
    {
        public T Data { get; set; }
        public string Message { get; set; }
        public int StatusCode { get; set; }
    }
}
