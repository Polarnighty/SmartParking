using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartParking.Server.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartParking.Server.Start.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private ILoginService loginService;
        public UserController(ILoginService loginService)
        {
            this.loginService = loginService;
        }
        [HttpPost]
        [Route("login")]
        public string Login([FromForm] string userName,[FromForm] string password)
        {

            return "";
        }
    }
}
