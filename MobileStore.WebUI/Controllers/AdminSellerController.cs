using MobileStore.Domain.Abstract;
using MobileStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobileStore.WebUI.Controllers
{
    public class AdminSellerController : Controller
    {
        private ISellerRepository repository;

        public AdminSellerController(ISellerRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index()
        {
            return View(repository.Sellers);
        }

        public ViewResult Edit (int sellerId)
        {
            Seller seller = repository.Sellers.FirstOrDefault(s => s.SellerID == sellerId);
            return View(seller);
        }

        [HttpPost]
        public ActionResult Edit(Seller seller)
        {
            if (ModelState.IsValid)
            {
                repository.SaveSeller(seller);
                TempData["message"] = string.Format("Zapisano sprzedawcę:{0} {1}", seller.LastName, seller.FirstName);
                return RedirectToAction("Index");
            }
            else
            {
                return View(seller);
            }
        }

        public ViewResult Create()
        {
            return View("Edit", new Seller());
        }

        [HttpPost]
        public ActionResult Delete(int sellerId)
        {
            Seller deletedSeller = repository.DeleteSeller(sellerId);
            if (deletedSeller != null)
            {
                TempData["message"] = string.Format("Usunięto: {0} {1}", deletedSeller.LastName, deletedSeller.FirstName);
            }
            return RedirectToAction("Index");
        }
    }
}