using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileStore.Domain.Entities
{
    public class Sale
    {
        public int SaleID { get; set; }

        [Display(Name="Towar Id")]
        public int CommodityID { get; set; }
        public virtual Commodity Commodity { get; set; }

        [Display(Name ="Data sprzedaży")]
        [DataType(DataType.Date)]
        public DateTime SalesDate { get; set; }

        [Display(Name ="Cena sprzedaży")]
        [DisplayFormat(DataFormatString ="{0:c}")]
        public decimal SalesPrice { get; set; }

        [Display(Name ="Numer faktury")]
        public int InvoiceID { get; set; }
        public virtual Invoice Invoice { get; set; }
    }
}
