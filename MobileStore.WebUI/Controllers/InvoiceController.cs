using MobileStore.Domain.Abstract;
using MobileStore.Domain.Entities;
using MobileStore.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobileStore.WebUI.Controllers
{
    public class InvoiceController : Controller
    {
        private IInvoiceRepository iInvoiceRepository;
        private ICommodityRepository iCommodityRepository;
        private ISellerRepository iSellerRepository;
        private IProductModelRepository iProductModelRepository;
        private IProducerRepository iProducerRepository;
        private ISimLockerRepository iSimLockerRepository;
        private ISaleRepository iSaleRepository;


        public InvoiceController(IInvoiceRepository iInvoiceRepo, ICommodityRepository iCommodityRep)
        {
            iInvoiceRepository = iInvoiceRepo;
            iCommodityRepository = iCommodityRep;
        }

        public InvoiceController(ICommodityRepository iCommodityRep)
        {
            iCommodityRepository = iCommodityRep;
        }

        public InvoiceController(ICommodityRepository iCommodityRep, ISaleRepository iSaleRepo)
        {
            iCommodityRepository = iCommodityRep;
            iSaleRepository = iSaleRepo;
        }

        public InvoiceController(IInvoiceRepository iInvoiceRepo, ICommodityRepository iCommodityRepo, ISellerRepository iSellerRepo,
                                   IProductModelRepository iProductModelRepo, IProducerRepository iProducerRepo,
                                   ISimLockerRepository iSimLockerRepo, ISaleRepository iSaleRepo)
        {
            iInvoiceRepository = iInvoiceRepo;
            iCommodityRepository = iCommodityRepo;
            iSellerRepository = iSellerRepo;
            iProductModelRepository = iProductModelRepo;
            iProducerRepository = iProducerRepo;
            iSimLockerRepository = iSimLockerRepo;
            iSaleRepository = iSaleRepo;
        }

        public InvoiceController(ISaleRepository iSaleRepo)
        {
            iSaleRepository = iSaleRepo;
        }


        public ViewResult Index()
        {
            return View("Index", iInvoiceRepository.Invoices);
        }

        public ViewResult Edit(int invoiceId)
        {
            Invoice inv = iInvoiceRepository.Invoices.FirstOrDefault(i => i.InvoiceID == invoiceId);
            return View(inv);
        }

        [HttpPost]
        public ActionResult Edit(Invoice inv)
        {
            if (ModelState.IsValid)
            {
                iInvoiceRepository.SaveInvoice(inv);
                TempData["message"] = string.Format("Zapisano: {0}", inv.InvoiceNumber);
                return RedirectToAction("Index");
            }
            else
            {
                return View(inv);
            }
        }

        public ViewResult Create()
        {
            return View("Edit", new Invoice());
        }

        public ViewResult AddSale(int invoiceId)
        {
            Invoice inv = iInvoiceRepository.Invoices.FirstOrDefault(i => i.InvoiceID == invoiceId);
            return View("AddSale", inv);
        }

        public PartialViewResult AvailableCommodities(int invoiceID)
        {

            List<CommodityInvoiceViewModel> commodityInvoiceViewModelList = new List<CommodityInvoiceViewModel>();
            IQueryable<Commodity> commodities = iCommodityRepository.Commodities.Where(c => c.IsAvailable == true).Include(s => s.Seller).Include(l => l.SimLocker).Include(m => m.ProductModel).Include(p => p.ProductModel.Producer);

            foreach (Commodity com in commodities)
            {
                CommodityInvoiceViewModel commodityInvoiceViewModel = new CommodityInvoiceViewModel();
                commodityInvoiceViewModel.Commodity = com;
                commodityInvoiceViewModel.SellerFullName = com.Seller.GetFullName;
                commodityInvoiceViewModel.ProducerName = com.ProductModel.Producer.ProducerName;
                commodityInvoiceViewModel.SimLockName = com.SimLocker.Name;
                commodityInvoiceViewModel.InvoiceID = invoiceID;

                commodityInvoiceViewModelList.Add(commodityInvoiceViewModel);
            }
            return PartialView("_AvailableCommodities", commodityInvoiceViewModelList.AsQueryable());
        }

        [HttpPost]
        public ActionResult AddNewSale(int? commodityID)
        {
            Commodity comm = iCommodityRepository.Commodities.FirstOrDefault(c => c.CommodityID == commodityID);
            Sale newSale = new Sale { CommodityID = (int)commodityID,
                InvoiceID = 1, SalesDate = DateTime.Now, SalesPrice = 0

            };
            iSaleRepository.SaveSale(newSale);
            return RedirectToAction(null);
        }

        public PartialViewResult InvoiceSale(int invoiceId)
        {
            return PartialView("_InvoiceSale", iSaleRepository.Sales.Where(s => s.InvoiceID == invoiceId));
        }

        public ViewResult Details(int invoiceId)
        {
            Invoice invoiceDetails = new Invoice();
            invoiceDetails=iInvoiceRepository.Invoices.FirstOrDefault(i => i.InvoiceID == invoiceId);
            return View(invoiceDetails);
        }
    }
}