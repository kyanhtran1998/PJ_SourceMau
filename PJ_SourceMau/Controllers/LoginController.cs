using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace PJ_SourceMau.Controllers
{

    public class LoginController : Controller
    {
        public async Task<IActionResult> Index()
        {
            //thêm thông tin Authorization
            ClaimsIdentity userIdentity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
            string roles = Areas.API.Models.Permission.getPermissionString("EMAIL");//thay bằng email đăng nhập
            string[] lstRole = roles.Split(new Char[] { ',' });
            Claim cl;
            userIdentity.AddClaim(new Claim(ClaimTypes.Email, "EMAIL"));//thay bằng email đăng nhập
            userIdentity.AddClaim(new Claim(ClaimTypes.Name, "FullName"));//thay bằng fullname đăng nhập
            userIdentity.AddClaim(new Claim("ISADMIN", "1"));//tùy theo trường hợp mà set giá trị tương ứng
            for (int i = 0; i < lstRole.Length; i++)
            {
                cl = new Claim(ClaimTypes.Role, lstRole[i]);
                userIdentity.AddClaim(cl);
            }
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            return Redirect("/Admin/Index");
        }

        public ActionResult Logout()
        {
            foreach (var cookie in Request.Cookies.Keys)
            {
                Response.Cookies.Delete(cookie);
            }

            HttpContext.Session.Clear();
            return Redirect("/Home/Index");
        }
    }
}
