using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileStore.Domain.Entities
{
    public class Commodity
    {
        public int CommodityID { get; set; }

        public int ProductModelID { get; set; }
        public virtual ProductModel ProductModel { get; set; }

        public int SellerID { get; set; }
        public virtual Seller Seller { get; set; }

        [Display(Name="Data zakupu")]
        [Required(ErrorMessage ="Proszę wybrać datę zakupu")]
        [DataType(DataType.Date)]
        public System.DateTime PurchaseDate { get; set; }

        [Display(Name ="Kwota zakupu")]
        [Required(ErrorMessage ="Proszę podać kwotę zakupu")]
        public decimal PurchasePrice { get; set; }

        [Required(ErrorMessage="Proszę podać stan towaru")]
        public string Condition { get; set; }
        [Required(ErrorMessage ="Proszę podać opis towaru")]
        public string Description { get; set; }

        public int SimLockerID { get; set; }
        public virtual SimLocker SimLocker { get; set; }

        //GrGr dodanie pola IsAvailable dla porzteb sprzedazy. Towar sprzedany nie jest już dostępny
        public bool IsAvailable { get; set; }
    }
}
