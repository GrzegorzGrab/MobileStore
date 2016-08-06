using MobileStore.Domain.Abstract;
using MobileStore.Domain.Entities;
//using MobileStore.WebUI.HtmlHelpers;
using MobileStore.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MobileStore.WebUI.Controllers
{
    public class AdminProductModelController : Controller
    {
        private IProductModelRepository iProductModelRepository;
        private IProducerRepository iProducerRepository;
        private IProductTypeRepository iProductTypeRepository;
        //private IProductModelRepository repository;

        public AdminProductModelController(IProductModelRepository productModelRepo, IProducerRepository producerRepo, IProductTypeRepository productTypeRepo)
        {
            iProductModelRepository = productModelRepo;
            iProducerRepository = producerRepo;
            iProductTypeRepository = productTypeRepo;
            //repository = repo;
        }

        public ViewResult Index()
        { 
            var result = new ProductModelViewModel();
            result.ProductModel = iProductModelRepository.ProductModels.Include(i => i.Producer).Include(i=>i.ProductType);
            return View(result);
        }

        public ViewResult Edit(int productModelId)
        {
            ProductModel productModel = iProductModelRepository.ProductModels.Include(i=>i.Producer).Include(i=>i.ProductType).FirstOrDefault(p => p.ProductModelID == productModelId);

            ViewBag.ProducerID = iProducerRepository.SelectListProducer(productModel.ProducerID);
            ViewBag.ProductTypeID = iProductTypeRepository.SelectListProductType(productModel.ProductTypeID);
            return View(productModel);
        }

        [HttpPost]
        public ActionResult Edit(ProductModel productModel)
        {
            if (ModelState.IsValid)
            {
                iProductModelRepository.SaveProductModel(productModel);
                TempData["message"] = string.Format("Zapisano: {0}", productModel.ProductModelName);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ProducerID = iProducerRepository.SelectListProducer(productModel.ProducerID);
                ViewBag.ProductTypeID = iProductTypeRepository.SelectListProductType(productModel.ProductTypeID);
                return View(productModel);
            }
        }

        public ViewResult Create()
        {
            ViewBag.ProducerID = iProducerRepository.SelectListProducer();
            ViewBag.ProductTypeID = iProductTypeRepository.SelectListProductType();
            return View("Edit", new ProductModel());
        }

        [HttpPost]
        public ActionResult Delete(int productModelId)
        {
            ProductModel deletedProductModel = iProductModelRepository.DeleteProductModel(productModelId);
            if (deletedProductModel != null)
            {
                TempData["message"] = string.Format("Usunięto: {0}", deletedProductModel.ProductModelName);
            }
            return RedirectToAction("Index");
        }
    }
}