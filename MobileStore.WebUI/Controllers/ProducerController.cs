using MobileStore.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobileStore.WebUI.Controllers
{
    public class ProducerController : Controller
    {
        private IProducerRepository repository;

        public ProducerController(IProducerRepository producerRepository)
        {
            this.repository = producerRepository;
        }

        public ViewResult List()
        {
            return View(repository.Producers);
        }
    }
}