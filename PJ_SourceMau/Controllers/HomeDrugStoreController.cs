using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DCSL.DatabaseFactory;
using Microsoft.AspNetCore.Mvc;
using PJ_SourceMau.Caption;
using PJ_SourceMau.FunctionSupport;
using PJ_SourceMau.Models;
using PJ_SourceMau.Repositories;


namespace PJ_SourceMau.Controllers
{
    public class HomeDrugStoreController : Controller
    {
        public IActionResult Index()
        {   
         
            List<DrugStore> listall = DrupStoreRes.GetAll().Where(a=> a.status == 1).Take(5).ToList();
            var listloainhathuoc = DrugCategoryRes.GetAll();
            var map = new Dictionary<int, string>();
            foreach (var list in listloainhathuoc)
            {
                map.Add(list.categoryId, list.categoryName);
            }
            ViewBag.list = map;
            List<DrugStore> lst = DrupStoreRes.GetTopfive().ToList();
            ViewData["Topfive"] = lst;
           
            return View(listall) ;
        }
        [Route("HomeDrugStore/DetailStore/{id}")]
        public IActionResult DetailStore(int id)
        {
            List<DrugStore> lst1 = DrupStoreRes.GetTopfive().Take(3).ToList();
            ViewData["Topfive"] = lst1;
            DrugStore lst = DrupStoreRes.GetAll().Where(i => i.ID == id).FirstOrDefault();
            ViewData["lat"] = lst.lat;
            ViewData["lng"] = lst.lng;
            ViewData["storeid"] = id;
            ViewData["phone"] = lst.phone;
            ViewData["name"] = lst.name;
            ViewData["imgSrc"] = lst.imgSrc;
            ViewData["opentime"] = lst.openTime;
            ViewData["closedtime"] = lst.closedTime;
            ViewData["description"] = lst.description;
            ViewData["address"] = lst.address;

            List<Comment> lstcmt = DrupStoreRes.GetAllCmt().Where(i => i.storeId == id).ToList();
            ViewData["countCmt"] = lstcmt.Count;
            ViewData["comments"] = lstcmt;
            int sum = 0;
            for(int i = 0; i < lstcmt.Count; i++)
            {
                sum += lstcmt[i].rating;
            }
            int count = 0;
            if (lstcmt.Count == 0) { count = 1; } else { count = lstcmt.Count; }
                
            ViewData["average"] = sum / count;
            List<DrugDetails> detail = DetailDrugStoreRes.GetAll().Where(i => i.iddrugstore == id).ToList();
            ViewData["detail"] = detail;


            List<Comment> lstcmt1 = DrupStoreRes.GetAllCmt().Where(i => i.storeId == id && i.rating == 4).ToList();
            ViewData["dem4"] = lstcmt1.Count;
            return View();
        }

        [HttpPost]
        [Route("HomeDrugStore/DetailStore/Comment/{id}")]
        public ActionResult CommentOnStore(Comment model, int id)
        {
            DateTime datetime = DateTime.Now;
            if (ModelState.IsValid)   
            {
                object[] value = new object[] { model.cid, "" + model.name, "" + model.email, "" + model.comment, "" + datetime, "" + model.rating, "" + id };
                String errMessage = "";
                int errorCode = 0;
                String[] ouput = null;
                string kaa = model.cid+ "" + model.name+ "" + model.email+ "" + model.comment+ "" + datetime+ "" + model.rating+ "id nha thuoc" + id;
                bool result = DrupStoreRes.SaveComment(value, ref ouput, ref errorCode, ref errMessage);
                if (result)
                {
                    TempData["AlertMessage"] = "Cập nhật Bình Luận Thành Công";
                    return RedirectToAction("DetailStore" + "/" + id, "HomeDrugStore");
                }

            }
            return View();
        }

        [Route("HomeDrugStore/DetailStore/{id}&{Search}")]
        public IActionResult DetailStore(int id, string Search)
        {
            List<DrugStore> lst1 = DrupStoreRes.GetTopfive().Take(4).ToList();
            ViewData["Topfive"] = lst1;
            DrugStore lst = DrupStoreRes.GetAll().Where(i => i.ID == id).FirstOrDefault();
            ViewBag.search = Search;
            //code moi 
            ViewData["lat"] = lst.lat;
            ViewData["lng"] = lst.lng;
            ViewData["storeid"] = id;
            ViewData["phone"] = lst.phone;
            ViewData["name"] = lst.name;
            ViewData["imgSrc"] = lst.imgSrc;
            ViewData["opentime"] = lst.openTime;
            ViewData["closedtime"] = lst.closedTime;
            ViewData["description"] = lst.description;
            ViewData["address"] = lst.address;

            List<Comment> lstcmt = DrupStoreRes.GetAllCmt().Where(i => i.storeId == id).ToList();
            ViewData["countCmt"] = lstcmt.Count;
            ViewData["comments"] = lstcmt;
            int sum = 0;
            for (int i = 0; i < lstcmt.Count; i++)
            {
                sum += lstcmt[i].rating;
            }
            int count = 0;
            if (lstcmt.Count == 0) { count = 1; } else { count = lstcmt.Count; }

            ViewData["average"] = sum / count;
            List<DrugDetails> detail = DetailDrugStoreRes.GetAll().Where(i => i.iddrugstore == id).ToList();
            ViewData["detail"] = detail;


            List<Comment> lstcmt1 = DrupStoreRes.GetAllCmt().Where(i => i.storeId == id && i.rating == 4).ToList();
            ViewData["dem4"] = lstcmt1.Count;




            return View();
        }

        [Route("HomeDrugStore/SearchStore/{id}")]
        public IActionResult SearchStore(int id)
        {
            int total = DrupStoreRes.GetAll().Count(i => i.status == 1);
            var pageSize = 5;
            int  page;
            if (id == null)
            {
                 page = 1;
            }
            else
            {
                 page = id;
            }
         
            var skip = pageSize * (page - 1);
            var canPage = skip < total;
            List<DrugStore> lst = DrupStoreRes.GetAll().Where(a => a.status == 1).Skip(skip).Take(pageSize).ToList();
           
            int pagetotal = FunctionUtility.CalcTotalPage(total, 5);
            ViewBag.page = pagetotal;
            List<DrugStore> lst1 = DrupStoreRes.GetTopfive().ToList();
            List<District> dis = DistrictRes.GetAll();
            List<DrugCategory> Category = DrugCategoryRes.GetAll();
            ViewData["Category"] = Category;
            ViewData["Distrist"] = dis;
            ViewData["Topfive"] = lst1;
            return View(lst);
        }


        
        [Route("HomeDrugStore/SearchStore")]
        public IActionResult SearchStore()
        {
            int total = DrupStoreRes.GetAll().Count(i => i.status == 1);
            var pageSize = 5;
            int page;
            page = 1;
            var skip = pageSize * (page - 1);
            var canPage = skip < total;
            List<DrugStore> lst = DrupStoreRes.GetAll().Where(a => a.status == 1).Skip(skip).Take(pageSize).ToList();

            int pagetotal = FunctionUtility.CalcTotalPage(total, 5);
            ViewBag.page = pagetotal;
            List<DrugStore> lst1 = DrupStoreRes.GetTopfive().ToList();
            List<District> dis = DistrictRes.GetAll();
            List<DrugCategory> Category = DrugCategoryRes.GetAll();
            ViewData["Category"] = Category;
            ViewData["Distrist"] = dis;
            ViewData["Topfive"] = lst1;
            return View(lst);
        }
        [HttpPost]
        [Route("HomeDrugStore/SearchStore")]
        public IActionResult SearchStore(string search, float Latitude, float Longitude)
        {
            String errMessage = "";
            int errorCode = 0;
            String[] ouput = null;
            object[] value = new object[] { Latitude, Longitude };
            List<DrugStore> lst = DrupStoreRes.GetAllSearch(value, ref ouput, ref errorCode, ref errMessage);
            ViewBag.search = search;
            ViewBag.Latitude = Latitude;
            ViewBag.Longitude = Longitude;
            List<DrugStore> lst1 = DrupStoreRes.GetTopfive();
            ViewData["Topfive"] = lst1;
            ViewData["aaaaaaa"] = lst;
            ViewBag.search = search;
            int total = DrupStoreRes.GetAll().Count(i => i.status == 1);
            var pageSize = 5;
            int page;
            page = 1;
            var skip = pageSize * (page - 1);
            var canPage = skip < total;
            List<DrugStore> lsttest = lst.Skip(skip).Take(pageSize).ToList();

            int pagetotal = FunctionUtility.CalcTotalPage(total, 5);
            ViewBag.page = pagetotal;
            return View(lsttest);
        }

        [Route("HomeDrugStore/feedback")]
        public IActionResult feedback()
        {
            return View();
        }

        [HttpPost]
        [Route("HomeDrugStore/feedback")]
        public IActionResult feedback(FeedBack model)
        {
            object[] value = { model.fbName , model.fbContent,model.fbEmail,model.fbPhone };
            var errorCode = 0;
            var errorMessage = "";
            string[] output = { };
            var result = FeedBackRes.SaveFeedBack(value, ref output, ref errorCode, ref errorMessage);
            return RedirectToAction("feedback");
        }
        [HttpPost]
        [Route("HomeDrugStore/filter")]
        public IActionResult filter(List<DrugStore> lis)
        {
            string s;
            if (lis.Count == 0)
            {
                s = "lp cp";
            }
            else
            {
                s = "lp cpaaaaaaaaaaaaaaaaaaa";
            }
          
            return Content(""+s);
        }
        [Route("HomeDrugStore/testgooglemap")]
        public IActionResult testgooglemap()
        {
            return View();
        }



        [Route("HomeDrugStore/introduce")]
        public IActionResult introduce()
        {
            return View();
        }
    }
}