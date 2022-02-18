using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartParking.Server.IService;
using SmartParking.Server.Models;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace SmartParking.Server.Start.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        ILoginService loginService;
        IMenuService menuService;
        public UserController(ILoginService loginService, IMenuService menuService)
        {
            this.loginService = loginService;
            this.menuService = menuService;
        }
        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromForm] string userName, [FromForm] string password)
        {
            string pwd = GetMd5Str(GetMd5Str(password) + "|" + userName);
            var users = loginService.Query<SysUserInfo>(u => u.UserName == userName && u.PassWord == pwd);

            if (users?.Count() > 0)
            {
                var userInfo = users.ToList();
                SysUserInfo sysUserInfo = userInfo[0];

                // 菜单
                // 需要进行权限管理
                // menu->role->role_user->user
                var menus = menuService.GetMenuByUserId(sysUserInfo.UserId);
                sysUserInfo.Menus = menus;

                return Ok(sysUserInfo);
            }
            else
            {
                return NoContent();
            }
        }

        private string GetMd5Str(string inputStr)
        {
            if (string.IsNullOrEmpty(inputStr)) return "";

            byte[] result = Encoding.Default.GetBytes(inputStr);    //tbPass为输入密码的文本框
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(result);
            return BitConverter.ToString(output).Replace("-", "");  //tbMd5pass为输出加密文本的文本框
        }

    }
}
