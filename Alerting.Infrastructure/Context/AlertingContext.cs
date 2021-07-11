using Alerting.DomainModel.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alerting.Infrastructure.Context
{
    public class AlertingContext : DbContext
    {
        public AlertingContext(DbContextOptions<AlertingContext> options) : base(options)
        {

        }

        public DbSet<Application> Application { get; set; }
        public DbSet<User> User { get; set; }
    }
}
