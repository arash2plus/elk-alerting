using Alerting.Application.Interface;
using Alerting.Presentation.Model.Request;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alerting.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserCommand _userCommand;
        private readonly IUserQuery _userQuery;
        public UserController(IUserCommand userCommand, IUserQuery userQuery)
        {
            _userCommand = userCommand;
            _userQuery = userQuery;
        }

        [Route("getUsersByApplicationId")]
        [HttpGet]
        public IActionResult GetUserByApplicationId(int applicationId)
        {
            var result = _userQuery.GetUserByapplicationId(applicationId);
            return Ok(result);
        }

        [Route("addUser")]
        [HttpPost]
        public IActionResult AddUser([FromBody] UserRequestModel user)
        {
            if (user.Email== null)
            {
                return StatusCode(500, "لطفا ایمیل کاربر را به درستی وارد نمایید.");
            }

            var response = _userCommand.AddUser(new DomainModel.Models.User()
            {
                Email = user.Email,
                ApplicationId = user.ApplicationId,
                Enable = user.Enable
            });
            if (response.Message!=null)
            {
                return StatusCode(500, response.Message);
            }
            return Ok();
        }

        [Route("deleteUser")]
        [HttpDelete("id")]
        public IActionResult DeleteUser(int id)
        {
            _userCommand.DeletUser(id);
            return Ok();
        }
    }
}
