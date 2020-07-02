using System.Collections.Generic;
using System.Linq;
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
    public class GroupController : Controller
    {
        //[Authorize(Roles = "admin")]
        [Route("admin/Group")]
        [Area("Admin")]
        [Authorize(Roles = "group_view")]
        public ActionResult Index()
        {
            //Session["fullname"] = HttpContext.Session["FullName"];
            DEntity<Group> e = new DEntity<Group>(ConstValue.ConnectionString, Group.getTableName());
            List<Group> g = e.getAll();
            g = g.Where(r => r.id != 1).ToList();
            return View(g);
        }

        //[Authorize(Roles = "admin")]
        [Area("Admin")]
        public ActionResult QLN()
        {
            //Session["fullname"] = HttpContext.Session["FullName"];
            return View();
        }

        //[Authorize(Roles = "admin")]
        [Route("admin/Group/EditGroup/{id}")]
        [Area("Admin")]
        [Authorize(Roles = "group_insert,group_update")]
        public ActionResult EditGroup(int id = 0)
        {
            //Session["fullname"] = HttpContext.Session["FullName"];
            ViewData["group_id"] = id;
            return View();
        }

        //[Authorize(Roles = "admin")]
        [Route("admin/Group/Member/{id}")]
        [Area("Admin")]
        [Authorize(Roles = "group_update")]
        public ActionResult Member(int id)
        {
            //Session["fullname"] = HttpContext.Session["FullName"];
            //ViewData["Account"] ="";// AccountRes.GetAll();
            ViewData["group_id"] = id;
            DEntity<Member> e = new DEntity<Member>(ConstValue.ConnectionString, API.Models.Member.getTableName());
            e.setPrimaryKey("id");
            List<Member> lst= e.getList("group_id", id);
            return View(lst);
        }

        //[Authorize(Roles = "admin")]
        [Route("admin/Group/Permission/{id}")]
        [Area("Admin")]
        [Authorize(Roles = "group_update,subpergroup_view")]
        public ActionResult Permission(int id)
        {
            //Session["fullname"] = HttpContext.Session["FullName"];
            ViewData["group_id"] = id;
            ViewData["functions"] = Areas.API.Models.Permission.getAllFunction();
            ViewData["permissions"] = Areas.API.Models.Permission.getAll(id);
            var lstPage = PageRes.Page_GetAll();
            if (User.IsInRole("subpergroup_view") == false)
            {
                lstPage = lstPage.Where(p => p.alias != "subpergroup").ToList();
            }
            ViewData["page"] = lstPage;
            return View();
        }

        [Route("admin/Group/InsertPage")]
        [Area("Admin")]
        [Authorize(Roles = "group_update")]
        public JsonResult InsertPage(int group_id, int page_id)
        {
            var permisstionExists = PermissionRes.Permission_GetAll().Where(x => x.group_id == group_id && x.page_id == page_id).ToList();
            if (permisstionExists.Count != 0)
            {
                return Json("Exists");
            }
            int result = PermissionRes.insert(group_id, page_id, 0);
            return Json(result);
        }

        [Route("admin/Group/SubperAdmin")]
        [Area("Admin")]
        [Authorize(Roles = "subpergroup_view")]
        public ActionResult SubperAdminIndex()
        {
            //Session["fullname"] = HttpContext.Session["FullName"];
            DEntity<Group> e = new DEntity<Group>(ConstValue.ConnectionString, Group.getTableName());
            List<Group> g = e.getAll();
            return View(g);
        }
    }
}