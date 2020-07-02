using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DCSL.DatabaseFactory;
using Microsoft.AspNetCore.Mvc;
using PJ_SourceMau.Caption;
using PJ_SourceMau.Models;

namespace PJ_SourceMau.Areas.API.Controllers
{
    public class DetailDrugStoreController : Controller
    {

        [Route("API/DetailDrugStore/GetAllDetailDrugStore")]
        [Area("API")]
        public ActionResult GetAllDetailDrugStore()
        {
            DEntity<DrugDetails> e = new DEntity<DrugDetails>(ConstValue.ConnectionString, DrugDetails.getTableName());
            return Json(e.getAll());
        }

        [Route("API/DetailDrugStore/GetdetailDrugStore")]
        [Area("API")]
        public ActionResult GetdetailDrugStore(int id)
        {
            DEntity<DrugDetails> e = new DEntity<DrugDetails>(ConstValue.ConnectionString, DrugDetails.getTableName());
            return Json(e.get("id", id));
        }



    }
}