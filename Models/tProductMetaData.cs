using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace First_ASP.Models
{
    [MetadataType(typeof(tProductMetaData))]

    public partial class tProduct
    {
        public class tProductMetaData
    {
            public int fId { get; set; }
            [DisplayName("產品名稱")]
            public string fName { get; set; }
            public Nullable<int> fQty { get; set; }
            public Nullable<decimal> fPrice { get; set; }
            public Nullable<decimal> fCost { get; set; }
            public string fImagePath { get; set; }
            public Nullable<bool> fdelete { get; set; }
        }
    }
}