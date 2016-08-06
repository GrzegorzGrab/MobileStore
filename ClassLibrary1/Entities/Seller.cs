using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileStore.Domain.Entities
{
    public class Seller
    {
        public int SellerID { get; set; }
        public string Pesel { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool IsRemoved { get; set; }

        //GrGr 20160717
        [Display(Name="Sprzedawca")]
        public string GetFullName
        {
            get { return LastName + " " + FirstName; }
        }
    }
}
