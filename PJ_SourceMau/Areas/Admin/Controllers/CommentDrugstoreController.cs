using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PJ_SourceMau.Models;
using PJ_SourceMau.Repositories;

namespace PJ_SourceMau.Areas.Admin.Controllers
{
    public class CommentDrugstoreController : Controller
    {
        [Route("Admin/Comment")]
        [Area("Admin")]
        public IActionResult Index()
        {
            List<DrugStore> lst = DrupStoreRes.GetAll();
            if (((ClaimsIdentity)User.Identity).FindFirst("GroupId").Value == "1")
            {
                lst = DrupStoreRes.GetAll();
            }
            else
            {
                lst = DrupStoreRes.GetAll().Where(i => i.iduser.ToString() == ((ClaimsIdentity)User.Identity).FindFirst("UserId").Value && i.status == 1).ToList();
            }
            var listloainhathuoc = DrugCategoryRes.GetAll();

            var map = new Dictionary<int, string>();
            foreach (var list in listloainhathuoc)
            {
                map.Add(list.categoryId, list.categoryName);
            }
            ViewBag.list = map;

            var listdistrict = DistrictRes.GetAll();
            ViewBag.listdistric = listdistrict;
            return View(lst);
        }

        [Route("Admin/CommentDetailDrugStore/{id}")]
        [Area("Admin")]
        public IActionResult CommentDetailDrugStore(int id)
        {
            List<Comment> lst = DrupStoreRes.GetAllCmt().Where(i => i.storeId == id).ToList();
            ViewData["storeId"] = id;
            return View(lst);
        }

        [Route("Admin/CommentDetailDrugStore/Detele/{id}")]
        [Area("Admin")]
        public IActionResult CommentDetailDeleteDrugStore(int id)
        {
            object[] value = { id };
            var errorCode = 0;
            var errorMessage = "";
            string[] output = { };
            Comment store = DrupStoreRes.GetAllCmt().Where(i => i.cid == id).FirstOrDefault();
            var result = DrupStoreRes.DeleteComment(value, ref output, ref errorCode, ref errorMessage);
            if (result)
            {
                TempData["AlertMessage"] = "Xóa Bình luận Thành Công";
            }
            return RedirectToAction("CommentDetailDrugStore", new { @id = store.storeId });
        }
    }
}
