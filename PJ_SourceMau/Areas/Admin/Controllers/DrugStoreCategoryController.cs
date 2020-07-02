using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DCSL.DatabaseFactory;
using Microsoft.AspNetCore.Mvc;
using PJ_SourceMau.Models;
using PJ_SourceMau.Repositories;

namespace PJ_SourceMau.Areas.Admin.Controllers
{
    public class DrugStoreCategoryController : Controller
    {
        [Route("Admin/ListDrugCategory")]
        [Area("Admin")]
        public IActionResult ListDrugStoreCategory()
        {
            List<DrugCategory> lst = DrugCategoryRes.GetAll();
            return View(lst);
        }   

        [Route("Admin/ListDrugCategory/Edit/{id}")]
        [Area("Admin")]
        public ActionResult EditDrugCategory(int id = 0)
        {
            ViewData["DrugCategoryID"] = id;
            return View();
        }

        [Route("Admin/ListDrugCategory/Delete/{id}")]
        [Area("Admin")]
        public IActionResult DeleteDrugCategory(int id)
        {
            object[] value = { id };
            var errorCode = 0;
            var errorMessage = "";
            string[] output = { };
            var result = DrugCategoryRes.DeleteDrugCategory(value, ref output, ref errorCode, ref errorMessage);
            return RedirectToAction("ListDrugStoreCategory");
        }


        [Route("Admin/ListDrugCategory/insert")]
        [Area("Admin")]
        public IActionResult DetailDrugStoregetvalue(int categoryId, string categoryName)
        {
            if (categoryName != null)
            {
                object[] value = { categoryId, categoryName };
                var errorCode = 0;
                var errorMessage = "";
                string[] output = { };
                var result = DrugCategoryRes.SaveDrugCategory(value, ref output, ref errorCode, ref errorMessage);
                return RedirectToAction("ListDrugStoreCategory");
            }
            else
            {
                TempData["AlertMessageError"] = "Vui lòng nhập tên loại nhà thuốc ";
            }
            return RedirectToAction("ListDrugStoreCategory");
        }

    }
}