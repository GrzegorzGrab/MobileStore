using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MobileStore.Domain.Abstract;
using MobileStore.Domain.Entities;
using System.Linq;
using MobileStore.WebUI.Controllers;
using System.Collections.Generic;
using MobileStore.WebUI.Models;

namespace MobileStore.UnitTests
{
    [TestClass]
    public class AdminProductModelTests
    {
        /*
        [TestMethod]
        public  void Index_Contains_All_ProductModels()
        {
            Mock<IProductModelRepository> mockProductModel = new Mock<IProductModelRepository>();
            mockProductModel.Setup(m => m.ProductModels).Returns(new ProductModel[]
            {
                new ProductModel {ProductModelID=1, ProducerID=1, ProductTypeID=1, ProductModelName="P1", ScreenSize=1,Weight=1, Memory=1,Ram=1,Description="D1",UrlAddress="U1" },
                new ProductModel {ProductModelID=2, ProducerID=2, ProductTypeID=2, ProductModelName="P2", ScreenSize=2,Weight=2, Memory=2,Ram=2,Description="D2",UrlAddress="U2" },
                new ProductModel {ProductModelID=3, ProducerID=3, ProductTypeID=3, ProductModelName="P3", ScreenSize=3,Weight=3, Memory=3,Ram=3,Description="D3",UrlAddress="U3" }
            }.AsQueryable());


            Mock<IProducerRepository> mockProducer = new Mock<IProducerRepository>();
            mockProducer.Setup(m => m.Producers).Returns(new Producer[]
            {
                new Producer {ProducerID=1, ProducerName="P1" },
                new Producer {ProducerID=2, ProducerName="P2" },
                new Producer {ProducerID=3, ProducerName="P3" }
            }.AsQueryable());

            Mock<IProductTypeRepository> mockProductType = new Mock<IProductTypeRepository>();
            mockProductType.Setup(m => m.ProductTypes).Returns(new ProductType[]
            {
                new ProductType {ProductTypeID=1,ProductTypeName="P1" },
                new ProductType {ProductTypeID=2,ProductTypeName="P2" },
                new ProductType {ProductTypeID=3,ProductTypeName="P3" }
            }.AsQueryable());

            AdminProductModelController target = new AdminProductModelController(mockProductModel.Object, mockProducer.Object, mockProductType.Object);

            ProductModelViewModel[] result = ((IEnumerable<ProductModelViewModel>)target.Index().ViewData.Model).ToArray();

            Assert.AreEqual(result.Length, 3);
            Assert.AreEqual(new ProductModel { ProductModelID = 1, ProducerID = 1, ProductTypeID = 1, ProductModelName = "P1", ScreenSize = 1, Weight = 1, Memory = 1, Ram = 1, Description = "D1", UrlAddress = "U1" }, result[0].ProductModel);
           // Assert.AreEqual("P2", result[1].ProductModel.ProductModelName);
            //Assert.AreEqual("P3", result[2].ProductModel.ProductModelName);
        }

           */
    }
}
