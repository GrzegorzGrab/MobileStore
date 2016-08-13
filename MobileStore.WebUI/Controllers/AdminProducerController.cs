using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MobileStore.Domain.Abstract;
using MobileStore.Domain.Entities;

namespace MobileStore.WebUI.Controllers
{
    //Controller wykorzystywany do administracji producentami

    public class AdminProducerController : Controller
    {
        private IProducerRepository repository;

        public AdminProducerController(IProducerRepository repo)
        {
            repository = repo;
        }

        // GET: AdminProducer
        public ViewResult Index()
        {
            return View(repository.Producers);
        }

        public ViewResult Edit(int producerID)
        {
            Producer producer = repository.Producers
                .FirstOrDefault(p => p.ProducerID == producerID);
            return View(producer);
        }

        [HttpPost]
        public ActionResult Edit(Producer producer)
        {
            if (ModelState.IsValid)
            {
                repository.SaveProducer(producer);
                TempData["message"] = string.Format("Zapisano: {0}", producer.ProducerName);
                return RedirectToAction("Index");
            }
            else
            {
                return View(producer);
            }
        }

        public ViewResult Create()
        {
            return View("Edit", new Producer());
        }

        //implementacja metody usuwającej producenta
        [HttpPost]
        public ActionResult Delete(int producerId)
        {
            Producer deletedProducer = repository.DeleteProducer(producerId);
            if (deletedProducer != null)
            {
                TempData["message"] = string.Format("Usunięto: {0}", deletedProducer.ProducerName);
            }
            return RedirectToAction("Index");
        }

        //dla widoku wyświetlającego szczegóły producenta
        public ViewResult Details (int producerId)
        {
            Producer producer = repository.ProducerDetails(producerId);
            return View("Details", producer);
        }
    }
}