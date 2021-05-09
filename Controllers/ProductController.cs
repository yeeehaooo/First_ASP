using First_ASP.Models;
using First_ASP.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace First_ASP.Controllers
{
    public class ProductController : Controller
    {
        // GET: CProductFactory
        static int count = 0;
        public ActionResult Index()
        {
            count++;
            ViewBag.KK = count;
            return View();
        }
        public ActionResult SessionIndex()
        {
            int count = 0;
            if (Session["Count"] != null)
            {
                count=(int) Session["Count"];
            }
            count++;
            Session["Count"] = count;
            ViewBag.KK = count;           
            return View();
        }
        public ActionResult CookieIndex()
        {
            int count = 0;
            HttpCookie cookie = Request.Cookies["KK"];
            if (cookie != null)
            {
                count = Convert.ToInt32(cookie.Value);
            }
            count++;
            cookie = new HttpCookie("KK");
            cookie.Value = count.ToString();
            Response.Cookies.Add(cookie);
            cookie.Expires = DateTime.Now.AddSeconds(10);
            ViewBag.KK = count;
            return View();
        }
        public ActionResult List(int? page)
        {
            string keyword = Request.Form["txtQuery"];
            IEnumerable<tProduct> table = null;            
            if (string.IsNullOrEmpty(keyword))
            {
                table = (new dBDeomEntities()).tProduct.Where(p => p.fdelete == false).ToList();
            }
            else
            {
                table = (new dBDeomEntities()).tProduct.Where(p => p.fdelete == false && p.fName.Contains(keyword)).ToList(); 
            }
            int pageNumber = page ?? 1;
            int pageSize = 2;
            List<CProductViewModel> list = new List<CProductViewModel>();
            foreach (tProduct item in table)
                list.Add(new CProductViewModel(item));
            return View(list.ToPagedList(pageNumber,pageSize));
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CProductViewModel p)
        {
            dBDeomEntities db = new dBDeomEntities();
            p.fdelete = false;
            db.tProduct.Add(p.product);
            db.SaveChanges();
            return RedirectToAction("List");
        }
        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                dBDeomEntities db = new dBDeomEntities();
                var p =db.tProduct.FirstOrDefault(d => d.fId == id);
                if (p != null)
                {
                    p.fdelete = true;
                    db.SaveChanges();
                }
            }
            return RedirectToAction("List");
        }
        public ActionResult Edit(int? id)
        {
            if (id != null)
            {
                dBDeomEntities db = new dBDeomEntities();
                tProduct p = db.tProduct.FirstOrDefault(d => d.fId == id);                
                return View(new CProductViewModel(p));
            }
            return RedirectToAction("List");
        }
        [HttpPost]
        public ActionResult Edit(CProductViewModel p_productEdit)
        {
            if (p_productEdit != null)
            {
                dBDeomEntities db = new dBDeomEntities();
                tProduct l_product被修改 = db.tProduct.FirstOrDefault(t => t.fId == p_productEdit.fId);
                if (l_product被修改 != null)
                {
                    l_product被修改.fName = p_productEdit.fName ;
                    l_product被修改.fQty = p_productEdit.fQty ;
                    l_product被修改.fPrice = p_productEdit.fPrice ;
                    l_product被修改.fCost = p_productEdit.fCost ;
                    l_product被修改.fImagePath = p_productEdit.fImagePath ;                    
                    db.SaveChanges();
                }              
            }            
            return RedirectToAction("List");
        }
    }
}