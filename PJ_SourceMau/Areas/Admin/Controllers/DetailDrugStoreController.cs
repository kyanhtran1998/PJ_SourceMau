using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PJ_SourceMau.Models;
using PJ_SourceMau.Repositories;

namespace PJ_SourceMau.Areas.Admin.Controllers
{
    public class DetailDrugStoreController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("Admin/DetailDrugStore/{id}")]
        [Area("Admin")]
        public IActionResult DetailDrugStore(int id)
        {
            List<DrugDetails> lst = DetailDrugStoreRes.GetAll().Where(i => i.iddrugstore == id).ToList();
            ViewData["idstore"] = id;
            return View(lst);
        }
       
        [Route("Admin/DetailDrugStore/insert")]
        [Area("Admin")]
        public IActionResult DetailDrugStoregetvalue(string id , string drugname , string price, string note, string idstore)
        {   
            if(drugname != null && price != null){
                object[] value = { id, drugname, price, note, idstore };
                var errorCode = 0;
                var errorMessage = "";
                string[] output = { };
                var result = DetailDrugStoreRes.SaveDrugDetail(value, ref output, ref errorCode, ref errorMessage);
            }
            else
            {
                TempData["AlertMessageError"] = "Vui lòng nhập đủ thông tin thuốc ";
            }
            return RedirectToAction("DetailDrugStore", new { @id = idstore });
        }

        [Route("Admin/DetailDrugStore/Delete/{id}")]
        [Area("Admin")]
        public IActionResult DeleteDrugCategory(int id)
        {
            object[] value = { id };
            var errorCode = 0;
            var errorMessage = "";
            string[] output = { };
            DrugDetails store = DetailDrugStoreRes.GetAll().Where(i => i.id == id).FirstOrDefault();
            var result = DetailDrugStoreRes.DeleteDetailDrugStore(value, ref output, ref errorCode, ref errorMessage);
            return RedirectToAction("DetailDrugStore", new { @id = store.iddrugstore });
        }   

        [Route("Admin/DetailDrugStore/User/{id}")]
        [Area("Admin")]
        public IActionResult DetailUserDrugStore(int id)
        {   
            DrugStore store = DrupStoreRes.GetAll().Where(i => i.iduser == id).FirstOrDefault();
            if (store != null)
            {
                List<DrugDetails> lst = DetailDrugStoreRes.GetAll().Where(i => i.iddrugstore == store.ID).ToList();
                return RedirectToAction("DetailDrugStore", new { @id = store.ID });
            }
            else
            {
                TempData["AlertMessageError"] = "Không có  dữ liệu nhà thuốc ";
                return RedirectToAction("ListAccount", "Account");
            }
           
            return View();
        }
    }
}