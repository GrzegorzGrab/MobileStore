using MobileStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileStore.WebUI.Models
{
    public class ProducerListViewModel
    {
        public IEnumerable<Producer>Producers { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}