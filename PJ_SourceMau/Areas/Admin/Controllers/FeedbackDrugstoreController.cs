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
    public class FeedbackDrugstoreController : Controller
    {
        [Route("Admin/Feedback")]
        [Area("Admin")]
        public IActionResult Index()
        {
            List<FeedBack> lst = FeedBackRes.GetAll();
            return View(lst);
        }

        [Route("Admin/Feedback/Detele/{id}")]
        [Area("Admin")]
        public IActionResult CommentDetailDeleteDrugStore(int id)
        {
            object[] value = { id };
            var errorCode = 0;
            var errorMessage = "";
            string[] output = { };
            var result = FeedBackRes.DeleteFeedback(value, ref output, ref errorCode, ref errorMessage);
            if (result)
            {
                TempData["AlertMessage"] = "Xóa feedback Thành Công";
            }
            return RedirectToAction("Index");
        }

    }
}
