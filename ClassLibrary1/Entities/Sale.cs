using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileStore.Domain.Entities
{
    public class Sale
    {
        public int SaleID { get; set; }

        public int CommodityID { get; set; }
        public virtual Commodity Commodity { get; set; }

        public DateTime SalesDate { get; set; }
        public decimal SalesPrice { get; set; }

        public int InvoiceID { get; set; }
        public virtual Invoice Invoice { get; set; }
    }
}
