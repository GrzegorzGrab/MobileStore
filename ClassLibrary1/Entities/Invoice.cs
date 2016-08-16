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

        /*
        [Display(Name="Numer faktury")]
        [Required(ErrorMessage ="Proszę podać numer faktury")]
        */
        public string  InvoiceNumber { get; set; }
        public decimal InvoiceAmount { get; set; }
    }
}
