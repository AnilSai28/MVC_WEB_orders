using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvc_web_api_orders.Models
{
    public class ordermodel
    {
        public int orderid { get; set; }
        public string customername { get; set; }
        public string customermobileno { get; set; }
        public string itemname { get; set; }
        public int itemprice { get; set; }
        public int itemquantity { get; set; }
    }
}