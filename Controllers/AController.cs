using First_ASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace First_ASP.Controllers
{
    public class AController : Controller
    {

        //查詢

        public string querySelectAll(int? fid)
        {
            //先驗證
            if (fid == null)
                return "請輸入查詢條件「fid」";
            CCustomer cust = new CCustomerFactory().getById((int)fid);
            if (cust == null)
                return "查無資料";
            return "查詢結果：</br>" + cust.fName + " / " + cust.fPhone;
        }


        //--------------------------------------------------------------


        //==================================
        //public string queryById()
        //{

        //    CCustomer cust = new CCustomerFactory().getById(2);
        //    if (cust == null)
        //        return "查無資料";
        //    return "查詢結果：</br>" + cust.fName + " / " + cust.fPhone;
        //}
        //public string queryById1()
        //{
        //    string id = Request.QueryString["ID"];
        //    CCustomer cust = new CCustomerFactory().getById(int.Parse(id));
        //    if (cust == null)
        //        return "查無資料";
        //    return "查詢結果：</br>" + cust.fName + " / " + cust.fPhone;
        //}

        //int? 可以接受null ,int?需轉換成int ==>(int)fid   
        public string queryById2(int? fid)
        {
            //先驗證
            if (fid == null)
                return "請輸入查詢條件「fid」";
            CCustomer cust = new CCustomerFactory().getById((int)fid);
            if (cust == null)
                return "查無資料";
            return "查詢結果：</br>" + cust.fName + " / " + cust.fPhone;
        }

        ////------------------------------------------------------------------

        //==CRUD無參數=============================
        public string customer_insert()
        {
            CCustomer x = new CCustomer()
            {
                fName = "Andy",
                fPassword = "1234",
                fEmail = "andy@gmail.com",
                fPhone = "0912345678",
                fAddress = "台北市"
            };
            new CCustromerFactoryNoParameters().insert(x); 
            return "新增成功";
        }
        
        public string customer_update()
        {
            CCustomer x = new CCustomer()
            {
                fId = 1,
                fName = "King",
                fPassword = "1234",
                fEmail = "King@gmail.com",
                fPhone = "0987654321",
                fAddress = "台中市"
            };
            new CCustromerFactoryNoParameters().update(x);
            return "修改成功";
        }
        public string customer_delete()
        {
            CCustomer x = new CCustomer()
            {
                fId = 1,                
            };
            new CCustromerFactoryNoParameters().delete (x);
            return "刪除成功";
        }

        //==CRUD有參數================================================
        public string customer_insert_withParameters()
        {
            CCustomer x = new CCustomer()
            {
                fName = "Andy",
                fPassword = "1234",
                fEmail = "andy@gmail.com",
                fPhone = "0912345678",
                fAddress = "台北市"
            };
            new CCustromerFactoryNoParameters().insert(x);
            return "新增成功";
        }

        public string customer_update_withParameters()
        {
            CCustomer x = new CCustomer()
            {
                fId = 1,
                fName = "King",
                fPassword = "1234",
                fEmail = "King@gmail.com",
                fPhone = "0987654321",
                fAddress = "台中市"
            };
            new CCustromerFactoryNoParameters().update(x);
            return "修改成功";
        }
        public string customer_delete_withParameters()
        {
            CCustomer x = new CCustomer()
            {
                fId = 1,
            };
            new CCustromerFactoryNoParameters().delete(x);
            return "刪除成功";
        }


        //--FirstDay-------------------------------------------------------------------------------------
        //樂透
        public string Clotto()
        {
            //共用方法移至model
            return new ShowLotto().getLotto();
        }

        //https://localhost:44389/A/DemoShop/?productId=1             Key=Value
        public string DemoShop()
        {
            string id = Request.QueryString["productId"];
            if (string.IsNullOrEmpty(id))
                return "請確定要加入購物車的商品";
            else if (id == "0") 
            return "加入 PS5 到購物車中";
            else if (id=="1")
                return "加入 Switch 到購物車中";
            else if (id =="2")
                return "加入 XBox 到購物車中";
            return "發生未明原因錯誤";
        }
        
        //todo 把Controller 變成方法 [NonAction]  public string Page_Load() {*}
        //[NonAction]
        //取得網頁實體目錄
        public string Page_Load()
        {
            string s = "目前再伺服器上的實體位置：" + Server.MapPath(".");
            return s;
        }

        //下載圖片
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Clear();
            Response.ContentType = "application/octet-stream";
            Response.Filter.Close();
            Response.WriteFile(@"C:\aspSample\files\01");
            Response.End();
        }
        //protected override void HandleUnknownAction(string actionName)
        //{
        //    Response.Redirect(@"..\First_ASP\Controllers\AController.cs");
        //}
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult cCustomerView(int? fid)
        {

            ViewBag.customer = "沒有指定查詢編號";
            //先驗證
            if (fid == null)
                return View();
            CCustomer cust = new CCustomerFactory().getById((int)fid);
            ViewBag.customer = "查無資料";
            ViewBag.cPhoto = @"~\Images\unknow.jpg";
            if (cust != null)
            {
                ViewBag.customer = cust.fName;
                ViewBag.cPhone = cust.fPhone;
                ViewBag.cEmail = cust.fEmail;
                ViewBag.cPhoto = "~\\Images\\{fid}.jpg";
            }
            return View();
        }
        public ActionResult bingcCustomerView(int? fid)
        {
            CCustomer cust = null;
            if (fid != null)
                cust = new CCustomerFactory().getById((int)fid);
            return View(cust);
        }
        public string DDDD(int id)
        {
            CCustomer c = new CCustomer()
            {
                fId = id
            };
            new CCustomerFactory().delete(c);
            return "OK";

        }
    }
}