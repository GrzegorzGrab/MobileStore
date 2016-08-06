using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MobileStore.Domain.Entities
{
    public class ProductType
    {
        [HiddenInput(DisplayValue=false)]
        public int ProductTypeID { get; set; }

        [Required(ErrorMessage ="Proszę podać nazwę typu produku!")]
        public string ProductTypeName { get; set; }

    }
}
