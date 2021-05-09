using First_ASP.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace First_ASP.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult List()
        {
            string keyword = Request.Form["txtQuery"];
            List<CCustomer> list = null;
            if (string.IsNullOrEmpty(keyword))
                list = new CCustomerFactory().getAll();
            else
                list = new CCustomerFactory().getByKeyWord(keyword);
            return View(list);
        }
        public ActionResult Create()
        {
            return View();
        }
    //List=>Create=>Create
    //同名 <form action=""> 可以省略action
        [HttpPost]
    public ActionResult Create(int? p )
    {
            CCustomer cust = new CCustomer();
            cust.fName = Request.Form["txtName"];
            cust.fPassword = Request.Form["txtPassword"];
            cust.fEmail = Request.Form["txtEmail"];
            cust.fPhone = Request.Form["txtPhone"];
            cust.fAddress = Request.Form["txtAddress"];
            new CCustomerFactory().insert(cust);
        return RedirectToAction ("List");
    }
        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                CCustomer cust = new CCustomer();
                {
                    cust.fId = (int)id;
                }
                new CCustomerFactory().delete(cust);
            }
            return RedirectToAction("List");
        }
        public ActionResult Edit(int? id)
        {
            CCustomer cust = null;
            if (id != null)
            {
                cust = new CCustomerFactory().getById((int)id);
            }
            return View(cust);
        }
        [HttpPost]
        public ActionResult Edit(CCustomer cust)
        {           
            //Edit.cshtml =>input name=tCustomer欄位，系統自動Mapping
            new CCustomerFactory().update(cust);
            return RedirectToAction("List");
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "LastName, FirstMidName, EnrollmentDate")] Student student)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            db.Students.Add(student);
        //            db.SaveChanges();
        //            return RedirectToAction("Index");
        //        }
        //    }
        //    catch (DataException /* dex */)
        //    {
        //        //Log the error (uncomment dex variable name and add a line here to write a log.
        //        ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
        //    }
        //    return View(student);
        //}
    }
}