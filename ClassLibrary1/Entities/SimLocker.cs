using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileStore.Domain.Entities
{
    public class SimLocker
    {
        public int SimLockerID { get; set; }

        [Display(Name="Nazwa")]
        [Required(ErrorMessage ="Proszę podać nazwę")]
        public string Name { get; set; }
    }
}
