using MobileStore.Domain.Abstract;
using MobileStore.Domain.Concrete;
using MobileStore.Domain.Entities;
using Moq;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;

namespace MobileStore.WebUI.Infrastructure
{
    public class NinjectControllerFactory:DefaultControllerFactory
    {
        private IKernel ninjectKernel;

        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null
                ? null
                : (IController)ninjectKernel.Get(controllerType);
        }

        private void AddBindings()
        {
           
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new List<Product>
            {
                new Product { Name = "Piłka nożna", Price = 25 },
                new Product { Name = "Deska surfingowa", Price = 179 },
                new Product { Name = "Buty do biegania", Price = 95 }
            }.AsQueryable()
            );
            ninjectKernel.Bind<IProductRepository>().ToConstant(mock.Object);
            /*
           ninjectKernel.Bind<IProducerRepository>().To<EFProducerRepository>();
           */
        }
    }
}