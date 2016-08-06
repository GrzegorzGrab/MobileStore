using MobileStore.Domain.Abstract;
using MobileStore.WebUI.Models;
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
        public int PageSize = 4;

        public ProducerController(IProducerRepository producerRepository)
        {
            this.repository = producerRepository;
        }
        
        public ViewResult List(int page=1 )
        {
            ProducerListViewModel viewModel = new ProducerListViewModel
            {
                Producers = repository.Producers
                .OrderBy(p => p.ProducerID)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.Producers.Count()
                }
            };
            return View(viewModel);
        }
    }
}