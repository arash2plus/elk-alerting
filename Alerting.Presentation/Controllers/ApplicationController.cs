using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alerting.Application.Interface;
using Alerting.Presentation.Model.Request;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Alerting.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationCommand _applicationCommand;
        private readonly IApplicationQuery _applicationQuery;

        public ApplicationController(IApplicationCommand applicationCommand, IApplicationQuery applicationQuery)
        {
            _applicationCommand = applicationCommand;
            _applicationQuery = applicationQuery;
        }

        [Route("getApplications")]
        [HttpGet]
        public IActionResult GetApplications()
        {
            var result = _applicationQuery.GetApplications();
            return Ok(result);
        }

        [Route("addApplication")]
        [HttpPost]
        public IActionResult AddApplication([FromBody] ApplicationRequestModel application)
        {
            if (application.ApplicationName==null)
                return StatusCode(500, "لطفا اپلیکیشن را وارد نمایید");

            var response = _applicationCommand.AddApplication(new DomainModel.Models.Application()
            {
                ApplicationName = application.ApplicationName
            });

            if (!string.IsNullOrEmpty(response.Message))
                return StatusCode(500, response.Message);
            return Ok();
        }

        [Route("deleteApplication")]
        [HttpDelete]
        public IActionResult DeleteApplication(int id)
        {
            _applicationCommand.DeleteApplication(id);
            return Ok();
        }
    }
}
