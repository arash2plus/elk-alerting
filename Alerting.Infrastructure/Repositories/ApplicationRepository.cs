using Alerting.DomainModel.Interfaces;
using Alerting.DomainModel.Models;
using Alerting.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alerting.Infrastructure.Repositories
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly AlertingContext _context;
        private readonly ILogger<ApplicationRepository> _logger;
        public ApplicationRepository(ILogger<ApplicationRepository> logger, AlertingContext context)
        {
            _context = context;
            _logger = logger;
        }

        public BusinessModel<Application> AddApplication(Application application)
        {
            var result = new BusinessModel<Application>();
            try
            {
                var applicationModel = _context.Application.Where(x => x.ApplicationName == application.ApplicationName).FirstOrDefault();
                if (applicationModel != null)
                {
                    result.Message = "اپلیکیشن تکراری می باشد";
                    result.StatusCode = 401;
                    return result;
                }
                _context.Application.Add(application);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError("Add Application faild", ex.Message);
            }
            return result;
        }

        public void DeleteApplication(int id)
        {
            try
            {
                var app = _context.Application.Where(x => x.Id == id).FirstOrDefault();
                if (app != null)
                {
                    _context.Application.Remove(app);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Add User Faild", ex.Message);
            }
        }

        public IEnumerable<Application> GetApplications()
        {
            var applicationList = new List<Application>();
            try
            {

                applicationList = _context.Set<Application>().ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError("GetApplications faild", ex.Message);
            }
            return applicationList;
        }
    }
}
