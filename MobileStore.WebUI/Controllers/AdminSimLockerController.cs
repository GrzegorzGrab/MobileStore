using MobileStore.Domain.Abstract;
using MobileStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobileStore.WebUI.Controllers
{
    public class AdminSimLockerController : Controller
    {
        private ISimLockerRepository repository;

        public AdminSimLockerController (ISimLockerRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index()
        {
            return View(repository.SimLockers);
        }

        public ViewResult Edit (int simLockerID) 
        {
            SimLocker simLocker = repository.SimLockers.FirstOrDefault(s => s.SimLockerID == simLockerID);
            return View(simLocker);
        }

        [HttpPost]
        public ActionResult Edit(SimLocker simLocker)
        {
            if (ModelState.IsValid)
            {
                repository.SaveSimLocker(simLocker);
                TempData["message"] = string.Format("Zapisano: {0}", simLocker.Name);
                return RedirectToAction("Index");
            }
            else
            {
                return View(simLocker);
            }
        }

        public ViewResult Create()
        {
            return View("Edit", new SimLocker());
        }

        [HttpPost]
        public ActionResult Delete(int simLockerId)
        {
            SimLocker deletedSimLocker = repository.DeleteSimLocker(simLockerId);
            if (deletedSimLocker != null)
            {
                TempData["message"] = string.Format("Usunięto: {0} ", deletedSimLocker.Name);
            }
            return RedirectToAction("Index");
        }
    }
}