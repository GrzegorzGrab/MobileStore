using MobileStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MobileStore.WebUI.Models
{
    public class ProductModelViewModel
    {
        public IEnumerable<ProductModel> ProductModel { get; set; }
        [Required(ErrorMessage = "Proszę wybrać producenta")]
        public IEnumerable<Producer> Producer { get; set; }
        public IEnumerable<ProductType> ProductType { get; set; }           
    }
}