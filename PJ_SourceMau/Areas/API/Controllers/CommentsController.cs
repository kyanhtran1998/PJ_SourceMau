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
    public class CommentsController : Controller
    {
        [Route("API/Comments/GetAllComments")]
        [Area("API")]
        public ActionResult GetAllDetailDrugStore()
        {
            DEntity<Comment> e = new DEntity<Comment>(ConstValue.ConnectionString, Comment.getTableName());
            return Json(e.getAll());
        }

        [Route("API/Comments/GetCommentsOnStore")]
        [Area("API")]
        public ActionResult GetCommentsbyStoreID(int id)
        {
            DEntity<Comment> e = new DEntity<Comment>(ConstValue.ConnectionString, Comment.getTableName());
            return Json(e.getAll().Where(i => i.storeId == id).ToList());
        }
    }
}
