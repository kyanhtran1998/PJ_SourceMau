using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DCSL.DatabaseFactory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PJ_SourceMau.Caption;
using PJ_SourceMau.Models;
using PJ_SourceMau.Repositories;

namespace PJ_SourceMau.Areas.Admin.Controllers
{
    public class DrugStoreController : Controller
    {   
        [Route("Admin/ListStore")]
        [Area("Admin")]
        public IActionResult ListStore()
        {
            List<DrugStore> lst = DrupStoreRes.GetAll();
            if (((ClaimsIdentity)User.Identity).FindFirst("GroupId").Value == "1")
            {
                lst = DrupStoreRes.GetAll();
            }
            else
            {
                lst = DrupStoreRes.GetAll().Where(i => i.iduser.ToString() == ((ClaimsIdentity)User.Identity).FindFirst("UserId").Value).ToList();
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

        [Route("Admin/ListStore/InsertStore")]
        [Area("Admin")]
        public IActionResult InsertStore()
        {
            var listloainhathuoc = DrugCategoryRes.GetAll();
            ViewBag.listloai = listloainhathuoc.Select(x => new SelectListItem
            {
                Text = x.categoryName,
                Value = x.categoryId.ToString()
            }).ToList();

            var listdistrict = DistrictRes.GetAll();
            ViewBag.listdistrict = listdistrict.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.ID.ToString()
            }).ToList();
            return View();
        }

        [HttpPost]
        [Route("Admin/ListStore/InsertStore")]
        [Area("Admin")]
        public async Task<IActionResult> InsertStore(DrugStore model, IFormFile file)
        {
            var listloainhathuoc = DrugCategoryRes.GetAll();
            ViewBag.listloai = listloainhathuoc.Select(x => new SelectListItem
            {
                Text = x.categoryName,
                Value = x.categoryId.ToString()
            }).ToList();

            var listdistrict = DistrictRes.GetAll();
            ViewBag.listdistrict = listdistrict.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.ID.ToString()
            }).ToList();

            if (ModelState.IsValid)
            {
                if (file != null && file.Length > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    string type = fileName.Substring(fileName.IndexOf("."));
                    if (type.Equals(".jpg") || type.Equals(".png") || type.Equals(".gif") ||
                        type.Equals(".jpeg"))
                    {
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\upload", fileName);
                        using (var fileSteam = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(fileSteam);
                        }
                        model.imgSrc = fileName;

                    }
                    else if (model.imgSrc == null)
                    {
                        TempData["AlertMessageError"] = "Vui lòng Chọn Đúng file ảnh ";
                        return View();

                    }
                }
                else
                {
                    TempData["AlertMessageError"] = "Vui lòng chọn file ảnh ";
                    return View();
                }
                DateTime dt = DateTime.Parse(model.openTime);
                string openTime = dt.ToString("HH:mm:ss");
                DateTime dt1 = DateTime.Parse(model.closedTime);
                string closedTime = dt1.ToString("HH:mm:ss");

                object[] value = new object[] { model.ID, "" + model.name, "" + model.address, "" + model.phone, "" + model.district, "" + model.imgSrc, model.status,
                    model.categoryId,""+model.description, ""+openTime, ""+closedTime,""+model.lat ,""+model.lng };
                String errMessage = "";
                int errorCode = 0;
                String[] ouput = null;
                bool result = DrupStoreRes.SaveStore(value, ref ouput, ref errorCode, ref errMessage);
                if (result)
                {
                    TempData["AlertMessage"] = "Create Nhà Thuốc Thành Công";
                    return RedirectToAction("ListStore");
                }
                else
                {
                    return Content("loi" + model.lat + model.lat + errMessage);
                }
            }
            return View();
        }



        [Route("Admin/ListStore/Edit/{id}")]
        [Area("Admin")]
        public ActionResult UpdateStore(int id)
        {
            DrugStore lstid = DrupStoreRes.GetAll().Where(i=>i.ID == id).FirstOrDefault();
            var listloainhathuoc = DrugCategoryRes.GetAll();
            ViewBag.listloai = listloainhathuoc.Select(x => new SelectListItem
            {
                Text = x.categoryName,
                Value = x.categoryId.ToString()
            }).ToList();
            var listdistrict = DistrictRes.GetAll();
            ViewBag.listdistrict = listdistrict.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.ID.ToString()
            }).ToList();
            return View(lstid);
        }

        [HttpPost]
        [Route("Admin/ListStore/Edit")]
        [Area("Admin")]
        public async Task<IActionResult> UpdateStore(DrugStore model, IFormFile file)
        {
            var listloainhathuoc = DrugCategoryRes.GetAll();
            ViewBag.listloai = listloainhathuoc.Select(x => new SelectListItem
            {
                Text = x.categoryName,
                Value = x.categoryId.ToString()
            }).ToList();
            var listdistrict = DistrictRes.GetAll();
            ViewBag.listdistrict = listdistrict.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.ID.ToString()
            }).ToList();

            if (ModelState.IsValid)
            {
                if (file != null && file.Length > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    string type = fileName.Substring(fileName.IndexOf("."));
                    if (type.Equals(".jpg") || type.Equals(".png") || type.Equals(".gif") ||
                        type.Equals(".jpeg"))
                    {
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\upload", fileName);
                        using (var fileSteam = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(fileSteam);
                        }
                        model.imgSrc = fileName;

                    }
                    else if (model.imgSrc == null)
                    {
                        TempData["AlertMessageError"] = "Vui lòng Chọn Đúng file ảnh ";
                        return RedirectToAction("UpdateStore", new { @id = model.ID });

                    }
                }
                DateTime dt = DateTime.Parse(model.openTime);
                string openTime = dt.ToString("HH:mm:ss");
                DateTime dt1 = DateTime.Parse(model.closedTime);
                string closedTime = dt1.ToString("HH:mm:ss");
                object[] value = new object[] { model.ID, "" + model.name, "" + model.address, "" + model.phone, "" + model.district, "" + model.imgSrc, model.status,
                    model.categoryId,""+model.description, ""+ openTime,""+closedTime,""+model.lat ,""+model.lng  };
                String errMessage = "";
                int errorCode = 0;
                String[] ouput = null;
                bool result = DrupStoreRes.SaveStore(value, ref ouput, ref errorCode, ref errMessage);
                if (result)
                {
                    TempData["AlertMessage"] = "Cập nhật Nhà Thuốc Thành Công";
                    return RedirectToAction("ListStore");
                }
            }
            return View(model);
        }

        [Route("Admin/ListStore/Delete/{id}")]
        [Area("Admin")]
        public ActionResult DeleteStore(int id)
        {
            object[] value = new object[] { id };
            String errMessage = "";
            int errorCode = 0;
            String[] ouput = null;
            bool result = DrupStoreRes.DeleteStore(value, ref ouput, ref errorCode, ref errMessage);
            return RedirectToAction("ListStore");
        }

        //Load file hình

        [Route("Admin/ListStore/create")]
        [Area("Admin")]
        public IActionResult testloadhinh()
        { 
            return View();
        }
        [HttpPost]
        [Route("Admin/ListStore/create")]
        [Area("Admin")]
        public async Task<IActionResult> UploadImageAndOpenItAsync(IFormFile file)
        {
            var fileName = Path.GetFileName(file.FileName);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\upload", fileName);
            using (var fileSteam = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileSteam);
            }
            return Content("sai" + filePath);
        }

    }
}