using MobileStore.Domain.Abstract;
using MobileStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobileStore.WebUI.Controllers
{
    public class InvoiceController : Controller
    {
        private IInvoiceRepository iInvoiceRepository;

        public InvoiceController (IInvoiceRepository iInvoiceRepo)
        {
            iInvoiceRepository = iInvoiceRepo;
        }

        public ViewResult Index()
        {
            return View("Index", iInvoiceRepository.Invoices);
        }

        public ViewResult Edit(int invoiceId)
        {
            Invoice inv = iInvoiceRepository.Invoices.FirstOrDefault(i => i.InvoiceID == invoiceId);
            return View( inv);
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
    }
}