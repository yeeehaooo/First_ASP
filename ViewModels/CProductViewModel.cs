using First_ASP.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace First_ASP.ViewModels
{
    public class CProductViewModel
    {
        private tProduct iv_tProduct = null;
        public tProduct product { get { return iv_tProduct; } }
        public CProductViewModel(tProduct p)
        {
            iv_tProduct = p;
        }
        public CProductViewModel()
        {
            iv_tProduct = new tProduct();
        }

        [DisplayName("序號")]

        public int fId { get { return iv_tProduct.fId; } set { iv_tProduct.fId = value; } }
        [DisplayName("產品名稱")]
        [Required(ErrorMessage ="無效的產品名稱")]
        public string fName { get { return iv_tProduct.fName; } set { iv_tProduct.fName = value; } }
        [DisplayName("數量")]

        public Nullable<int> fQty { get { return iv_tProduct.fQty; } set { iv_tProduct.fQty = value; } }
        [DisplayName("產品價格")]

        public Nullable<decimal> fPrice { get { return iv_tProduct.fPrice; } set { iv_tProduct.fPrice = value; } }
        [DisplayName("產品成本")]

        public Nullable<decimal> fCost { get { return iv_tProduct.fCost; } set { iv_tProduct.fCost = value; } }
        [DisplayName("產品照片")]

        public string fImagePath { get { return iv_tProduct.fImagePath; } set { iv_tProduct.fImagePath = value; } }
        public Nullable<bool> fdelete { get { return iv_tProduct.fdelete; } set { iv_tProduct.fdelete = value; } }
    }
}