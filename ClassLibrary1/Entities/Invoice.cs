using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileStore.Domain.Entities
{
    public class Invoice
    {
        public int InvoiceID { get; set; }

        
        [Display(Name="Numer faktury")]
        [Required(ErrorMessage ="Proszę podać numer faktury")]
        public string  InvoiceNumber { get; set; }

        [Display(Name ="Kwota faktury")]
        [DisplayFormat(DataFormatString ="{0:c}")]
        public decimal InvoiceAmount { get; set; }

        [Display(Name ="Data wystawienia")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage ="Proszę podać datę wystawienia faktury")]
        public DateTime InvoiceDate { get; set; }
    }
}
