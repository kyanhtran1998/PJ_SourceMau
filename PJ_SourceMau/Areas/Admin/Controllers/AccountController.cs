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
    public class AccountController : Controller
    {
        [Route("Admin/ListAccount")]
        [Area("Admin")]
        public IActionResult ListAccount()
        {
            List<Account> lst = AccountRes.GetAll();
            return View(lst);
        }


        [Route("Admin/ListAccount/Detail/{id}")]
        [Area("Admin")]
        public IActionResult DetailAccount(int id)
        {
            DEntity<AccountDetail> e = new DEntity<AccountDetail>(ConstValue.ConnectionString, AccountDetail.getTableName());
            AccountDetail lst = e.get("iduser", id);
            return View(lst);
        }

        [Route("Admin/ListAccount/Delete/{id}")]
        [Area("Admin")]
        public IActionResult DeleteAccount(int id)
        {
            object[] value = { id };
            var errorCode = 0;
            var errorMessage = "";
            string[] output = { };
            var result = AccountRes.DeleteAccount(value, ref output, ref errorCode, ref errorMessage);
            if (result)
            {
                return RedirectToAction("ListAccount");
            }
            return Content("loi"+ errorMessage);
        }

    }
}