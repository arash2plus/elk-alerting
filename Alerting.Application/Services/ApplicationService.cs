using Alerting.Application.Interface;
using Alerting.DomainModel.Interfaces;
using Alerting.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alerting.Application.Services
{
    public class ApplicationService : IApplicationQuery, IApplicationCommand
    {
        private readonly IApplicationRepository _applicationRepository;

        public ApplicationService(IApplicationRepository applicationRepository)
        {
            _applicationRepository = applicationRepository;
        }

        public BusinessModel<DomainModel.Models.Application> AddApplication(DomainModel.Models.Application application)
        {
            return _applicationRepository.AddApplication(application);
        }

        public void DeleteApplication(int id)
        {
              _applicationRepository.DeleteApplication(id);
        }

        public IEnumerable<DomainModel.Models.Application> GetApplications()
        {
            return _applicationRepository.GetApplications();
        }
    }
}
