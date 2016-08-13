using MobileStore.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobileStore.WebUI.Controllers
{
    public class SaleController : Controller
    {
        private ISaleRepository iSaleRepository;
        
        public SaleController (ISaleRepository repo)
        {
            iSaleRepository = repo;
        }

        public ViewResult Index()
        {
            return View("Index", iSaleRepository.Sales);
        }
    }
}