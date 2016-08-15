using MobileStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileStore.WebUI.Models
{
    public class CommodityInvoiceViewModel
    {
        public   int InvoiceID { get; set; }
        public Commodity  Commodity { get; set; }
        public string SellerFullName { get; set; }
        public string ProducerName { get; set; }
        public string SimLockName { get; set; }
        //public IQueryable<Commodity> Commodities { get; set; }
    }

}