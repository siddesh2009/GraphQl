using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sco.Business.Contract;

namespace GraphQlV1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserBusinessMgr _userBusinessMgr;

        public UserController(IUserBusinessMgr userBusinessMgr)
        {
            _userBusinessMgr = userBusinessMgr;
        }

        [HttpGet]
        [Route("GetAllUsers")]
        public IActionResult GetAllUsers()
        {
            var users = _userBusinessMgr.GetAllUsers();
            return Ok(users);
        }

        [HttpGet]
        [Route("GetAllUsersQuerable")]
        public IActionResult GetAllUsersQuerable()
        {
            var users = _userBusinessMgr.GetAllUsersQuerable();
            return Ok(users);
        }
    }
}
