using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DCSL.DatabaseFactory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PJ_SourceMau.Caption;
using PJ_SourceMau.Models;
using PJ_SourceMau.Repositories;

namespace PJ_SourceMau.Areas.API.Controllers
{
    public class DrugStoreCategoryController : Controller
    {
        [Route("API/DrugCategory/ListDrugCategory")]
        [Area("Admin")]
        public IActionResult GetListDrugStoreCategory()
        {
            DEntity<DrugCategory> e = new DEntity<DrugCategory>(ConstValue.ConnectionString, DrugCategory.getTableName());
            return Json(e.getAll());
        }

        [Route("API/DrugCategory/GetDrugCategory")]
        [Area("API")]
        public ActionResult GetDrugCategory(int categoryId)
        {
            DEntity<DrugCategory> e = new DEntity<DrugCategory>(ConstValue.ConnectionString, DrugCategory.getTableName());
            return Json(e.get("categoryId", categoryId));
        }
    }
}