using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DCSL.DatabaseFactory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PJ_SourceMau.Areas.API.Models;
using PJ_SourceMau.Caption;
using PJ_SourceMau.Models;
using PJ_SourceMau.Repositories;

namespace PJ_SourceMau.Areas.Admin.Controllers
{
    [Authorize]
    public class PageController : Controller
    {
        //[Authorize(Roles = "admin")]
        [Route("admin/ChucNang")]
        [Area("Admin")]
        [Authorize(Roles = "page_view")]
        public ActionResult Index()
        {
            DEntity<Page> e = new DEntity<Page>(ConstValue.ConnectionString, Page.getTableName());
            List<Page> lst=e.getAll();
            return View(lst);
        }

        //[Authorize(Roles = "admin")]
        [Route("admin/ChucNang/Edit/{id}")]
        [Area("Admin")]
        [Authorize(Roles = "page_insert,page_update")]
        public ActionResult EditPage(int id = 0)
        {
            //Session["fullname"] = HttpContext.Session["FullName"];
            ViewData["Page_id"] = id;
            return View();
        }

        [Route("ChucNang/AboutWebsite")]
        [Area("Admin")]
        public ActionResult AboutWebsite(int id = 0)
        {
            return View();
        }
    }
}