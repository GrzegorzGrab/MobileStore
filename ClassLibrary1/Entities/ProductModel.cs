using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileStore.Domain.Entities
{
    public class ProductModel
    {
        public int ProductModelID { get; set; }
        [Required(ErrorMessage = "Proszę nazwę modelu")]
        public string ProductModelName { get; set; }

        [Required(ErrorMessage ="Proszę wybrać producenta")]
        public int ProducerID { get; set; }
        //[Required(ErrorMessage = "Proszę wybrać producenta")]
        public virtual Producer Producer { get; set; }
        [Required(ErrorMessage = "Proszę wybrać typ produktu")]
        public int ProductTypeID { get; set; }

        //[Required(ErrorMessage ="Proszę wybrać typ produktu")]
        public virtual ProductType ProductType { get; set; }

        public decimal ScreenSize { get; set; }
        public int Weight { get; set; }
        public int  Memory { get; set; }
        public int Ram { get; set; }
        public string Description { get; set; }
        public string UrlAddress { get; set; }

        public string GetModelNameAndProducerName
        {
            get  {  return ProductModelName + " " +  Producer.ProducerName; } 
        }
    }
}
