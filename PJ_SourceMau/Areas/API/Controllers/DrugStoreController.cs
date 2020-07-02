using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DCSL.DatabaseFactory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PJ_SourceMau.Caption;
using PJ_SourceMau.Models;
using PJ_SourceMau.Repositories;

namespace PJ_SourceMau.Areas.API.Admin.Controllers
{
    public class DrugStoreController : Controller
    {   

        [Route("API/ListStore")]
        [Area("API")]
        public IActionResult ListDrugStore()
        {
            DEntity<DrugStore> e = new DEntity<DrugStore>(ConstValue.ConnectionString, DrugStore.getTableName());
            return Json(e.getAll());
        }


        [Route("API/ListStore/GetStore")]
        [Area("API")]
        public ActionResult DrugStoreGetId(int id)
        {
            DEntity<DrugStore> e = new DEntity<DrugStore>(ConstValue.ConnectionString, DrugStore.getTableName());
            return Json(e.get("ID", id));
        }
    }   
}