using MobileStore.Domain.Abstract;
using MobileStore.Domain.Entities;
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
        private ICommodityRepository iCommodityRepository;
        private IInvoiceRepository iInvoiceRepository;
        
        public SaleController (ISaleRepository repo)
        {
            iSaleRepository = repo;
        }

        public SaleController (ISaleRepository iSaleRepo, ICommodityRepository iCommodityRepo, IInvoiceRepository iInvoiceRepo)
        {
            iSaleRepository = iSaleRepo;
            iCommodityRepository = iCommodityRepo;
            iInvoiceRepository = iInvoiceRepo;
        }

        public ViewResult Index()
        {
            return View("Index", iSaleRepository.Sales);
        }

        public ViewResult Create(int commodityId, int invoiceId)
        {
            Commodity comm = new Commodity();
            comm = iCommodityRepository.Commodities.FirstOrDefault(c => c.CommodityID == commodityId);
            Sale sale = new Sale
            {
                CommodityID = commodityId,
                SalesDate = DateTime.Now,
                SalesPrice = 0,
                InvoiceID =invoiceId
            };

            return View("Create", sale);
        }

        [HttpPost]
        public ActionResult Create(Sale sale)
        {
            if (ModelState.IsValid)
            {
                iSaleRepository.SaveSale(sale);
                //zmiana dostępności towaru w przypadku sprzedaży   
                iCommodityRepository.ChangeCommodityAvailability(sale.CommodityID);
                iInvoiceRepository.EditInvoiceAmount(sale.InvoiceID);
                return RedirectToAction("AddSale", "Invoice", new { invoiceId = sale.InvoiceID });
            }
            else
            {
                return View(sale);
            }
        }
    }
}