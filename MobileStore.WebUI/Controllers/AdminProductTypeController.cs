using MobileStore.Domain.Abstract;
using MobileStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobileStore.WebUI.Controllers
{
    public class AdminProductTypeController : Controller
    {
        private IProductTypeRepository repository;

        public AdminProductTypeController (IProductTypeRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index()
        {
            return View(repository.ProductTypes);
        }

        public ViewResult Edit(int productTypeId)
        {
            ProductType productType = repository.ProductTypes
                .FirstOrDefault(p => p.ProductTypeID == productTypeId);
            return View(productType);
        }

        [HttpPost]
        public ActionResult Edit (ProductType productType)
        {
            if (ModelState.IsValid)
            {
                repository.SaveProductType(productType);
                TempData["message"] = string.Format("{0} został zapisany", productType.ProductTypeName);
                return RedirectToAction("Index");
            }
            else
            {
                return View(productType);
            }
        }

        public ViewResult Create()
        {
            return View("Edit", new ProductType());
        }

        //metoda akcji wykorzystywana do usuwanie typuproduktu
        [HttpPost]
        public ActionResult Delete(int productTypeId)
        {
            ProductType deletedProductType = repository.DeleteProductType(productTypeId);
            if(deletedProductType!=null)
            {
                TempData["message"] = string.Format("Usinięto: {0}", deletedProductType.ProductTypeName);
            }
            return RedirectToAction("Index");
        }
       
    }
}