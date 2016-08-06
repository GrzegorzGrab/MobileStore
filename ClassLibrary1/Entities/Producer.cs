using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MobileStore.Domain.Entities
{
    public class Producer
    {
        [HiddenInput(DisplayValue =false)]
        public int ProducerID { get; set; }

        [Required(ErrorMessage ="Proszę podać nazwę producenta!")]
        public string ProducerName { get; set; }
        [DataType(DataType.MultilineText)]
        public string ProducerDescription { get; set; }
    }
}
