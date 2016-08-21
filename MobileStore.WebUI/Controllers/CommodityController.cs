using MobileStore.Domain.Abstract;
using MobileStore.Domain.Entities;
using MobileStore.WebUI.HtmlHelpers;
using MobileStore.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobileStore.WebUI.Controllers
{
    public class CommodityController : Controller
    {
        private ICommodityRepository iCommodityRepository;
        private ISellerRepository iSellerRepository;
        private IProductModelRepository iProductModelRepository;
        private IProducerRepository iProducerRepository;
        private ISimLockerRepository iSimLockerRepository;

        public CommodityController (ICommodityRepository iCommodityRepo)
        {
            iCommodityRepository = iCommodityRepo;
        }
       
        public CommodityController(ICommodityRepository iCommodityRepo, ISellerRepository iSellerRepo,
                                   IProductModelRepository iProductModelRepo, IProducerRepository iProducerRepo,
                                   ISimLockerRepository iSimLockerRepo)
        {
            iCommodityRepository = iCommodityRepo;
            iSellerRepository = iSellerRepo;
            iProductModelRepository = iProductModelRepo;
            iProducerRepository = iProducerRepo;
            iSimLockerRepository = iSimLockerRepo;
        }
        
        public ViewResult Index()
        {
            TempData["title"] = "Wszystkie towary";
            return View(iCommodityRepository.Commodities.Include(s=>s.Seller).Include(l=>l.SimLocker).Include(m=>m.ProductModel).Include(p=>p.ProductModel.Producer));
        }

        public ViewResult Edit(int commodityId )
        {
            
            Commodity commodity = iCommodityRepository.Commodities.FirstOrDefault(c => c.CommodityID == commodityId);
            ViewBag.ProductModelID = iProductModelRepository.SelectListProductModel(commodity.ProductModelID);
            ViewBag.SellerID = iSellerRepository.SelectListSeller(commodity.SellerID);
            ViewBag.SimLockerID = iSimLockerRepository.SelectListSimLocker(commodity.SimLockerID);
            return View(commodity);
        }

        [HttpPost]
        public ActionResult Edit(Commodity commodity)
        {
            if (ModelState.IsValid)
            {
                iCommodityRepository.SaveCommodity(commodity);
                TempData["message"] = string.Format("Zapisano:  {0}", commodity.CommodityID);
                return RedirectToAction("Index");
            }
            else
            {
                return View(commodity);
            }
        }

        public ViewResult Create()
        {
            ViewBag.ProductModelID = iProductModelRepository.SelectListProductModel();
            ViewBag.SellerID = iSellerRepository.SelectListSeller();
            ViewBag.SimLockerID = iSimLockerRepository.SelectListSimLocker();
            return View("Edit", new Commodity());
        }

        //Akcja prezentująca dostępne towary
        public ViewResult AvailableCommodities()
        {
            TempData["title"] = "Dostępne towary";
            return View("Index",iCommodityRepository.Commodities.Where(c=>c.IsAvailable==true).Include(s => s.Seller).Include(l => l.SimLocker).Include(m => m.ProductModel).Include(p => p.ProductModel.Producer));
        }

        //Akcja prezentująca niedostępne towary
        public ViewResult UnAvailableCommodities()
        {
            TempData["title"] = "Sprzedane towary";
            return View("Index", iCommodityRepository.Commodities.Where(c => c.IsAvailable == false).Include(s => s.Seller).Include(l => l.SimLocker).Include(m => m.ProductModel).Include(p => p.ProductModel.Producer));
        }

        public ViewResult Details(int commodityId)
        {
            Commodity com= iCommodityRepository.Commodities.Include(p => p.ProductModel.Producer).FirstOrDefault(c => c.CommodityID == commodityId);
            return View(com);
        }

        public PartialViewResult _CommodityDetails(int commodityId =1)
        {
            Commodity com = iCommodityRepository.Commodities.Include(p => p.ProductModel.Producer).FirstOrDefault(c => c.CommodityID == commodityId);
            return PartialView(com);
        }
    }
}