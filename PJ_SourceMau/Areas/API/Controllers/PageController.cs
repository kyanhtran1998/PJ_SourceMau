using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using DCSL.DatabaseFactory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PJ_SourceMau.Areas.API.Models;
using PJ_SourceMau.Caption;
using PJ_SourceMau.Models;
using PJ_SourceMau.Repositories;

namespace PJ_SourceMau.Areas.API.Controllers
{
    [Authorize]
    public class PageController : Controller
    {

        [Route("API/Page/GetAllPage")]
        [Area("API")]
        public ActionResult GetAllPage()
        {
            DEntity<Page> e = new DEntity<Page>(ConstValue.ConnectionString, Page.getTableName());
            return Json(e.getAll());
        }

        [Route("API/Page/GetPage")]
        [Area("API")]
        public ActionResult GetPage(int id)
        {
            DEntity<Page> e = new DEntity<Page>(ConstValue.ConnectionString, Page.getTableName());
            return Json(e.get("id", id));
        }

        [Route("API/Page/InsertPage")]
        [Area("API")]
        [Authorize(Roles ="page_insert")]
        public ActionResult InsertPage(IFormCollection form)
        {
            int id = Int32.Parse(form["id"].ToString());
            string name = form["name"].ToString();
            string alias = form["alias"].ToString();
            int permission = Convert.ToInt32(form["permission"].ToString());
            string note = WebUtility.HtmlDecode(form["note"].ToString());

            string email = HttpContext.User.Claims.Where(c => c.Type == System.Security.Claims.ClaimsIdentity.DefaultNameClaimType).FirstOrDefault().Value ;

            object[] value = { id, name, alias, permission, note, email };
            var errorCode = 0;
            var errorMessage = "";
            string[] output = { };
            var result = PageRes.Save(value, ref output, ref errorCode, ref errorMessage);
            return Json(result);
        }

        [Route("API/Page/UpdatePage")]
        [Area("API")]
        [Authorize(Roles = "page_update")]
        public ActionResult UpdatePage(IFormCollection form)
        {
            int id = Int32.Parse(form["id"].ToString());
            string name = form["name"].ToString();
            string alias = form["alias"].ToString();
            int permission = Convert.ToInt32(form["permission"].ToString());
            string note = WebUtility.HtmlDecode(form["note"].ToString());
            string description_fn = WebUtility.HtmlDecode(form["description_fn"].ToString());
            string email = HttpContext.User.Claims.Where(c => c.Type == System.Security.Claims.ClaimsIdentity.DefaultNameClaimType).FirstOrDefault().Value;

            object[] value = { id, name, alias, permission, note , email , description_fn };
            var errorCode = 0;
            var errorMessage = "";
            string[] output = { };
            var result = PageRes.Save(value, ref output, ref errorCode, ref errorMessage);
            return Json(result);
        }

    }
}