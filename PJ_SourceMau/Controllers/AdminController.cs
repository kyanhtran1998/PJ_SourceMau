using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace PJ_SourceMau.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            var identity = (ClaimsIdentity)HttpContext.User.Identity;
            if (identity.FindFirst("Groupid")  == null)
            {
                return RedirectToAction("Index", "Login");
            }

            if (identity.FindFirst("Groupid").Value == "2")
            {
                return RedirectToAction("Index", "HomeDrugstore");
            }

            return View();
        }
    }
}