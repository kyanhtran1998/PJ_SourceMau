using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DCSL.DatabaseFactory;
using Microsoft.AspNetCore.Mvc;
using PJ_SourceMau.Caption;
using PJ_SourceMau.Models;
using PJ_SourceMau.Repositories;

namespace PJ_SourceMau.Areas.Admin.Controllers
{
    public class DistrictController : Controller
    {
        [Route("Admin/District")]
        [Area("Admin")]
        public IActionResult ListDistrict()
        {
            List<District> lst = DistrictRes.GetAll();
            return View(lst);
        }


        [Route("Admin/District/Edit/{id}")]
        [Area("Admin")]
        public ActionResult EditDistrict(int id = 0)
        {
            ViewData["DrugCategoryID"] = id;
            return View();
        }

        [Route("Admin/District/Delete/{id}")]
        [Area("Admin")]
        public IActionResult DeleteDistrict(int id)
        {
            object[] value = { id };
            var errorCode = 0;
            var errorMessage = "";
            string[] output = { };
            var result = DistrictRes.DeleteDistrict(value, ref output, ref errorCode, ref errorMessage);
            if (result)
            {

                TempData["AlertMessage"] = "Xóa Thành Công";
            }
            return RedirectToAction("ListDistrict");
        }


        [Route("Admin/District/insert")]
        [Area("Admin")]
        public IActionResult DistrictInsert(int ID, string Name)
        {
            if (Name != null)
            {
                object[] value = { ID, Name };
                var errorCode = 0;
                var errorMessage = "";
                string[] output = { };
                var result = DistrictRes.SaveDistrict(value, ref output, ref errorCode, ref errorMessage);
                if (result)
                {
                    return RedirectToAction("ListDistrict");
                }

            }
            else
            {
                TempData["AlertMessageError"] = "Vui lòng nhập tên loại nhà thuốc ";
            }
            return RedirectToAction("ListDistrict");
        }


        [Route("Admin/District/GetDistrictId")]
        [Area("Admin")]
        public ActionResult GetDistrict(int id)
        {
            DEntity<District> e = new DEntity<District>(ConstValue.ConnectionString, District.getTableName());
            return Json(e.get("ID", id));
        }
    }
}