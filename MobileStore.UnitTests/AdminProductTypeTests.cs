using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MobileStore.Domain.Abstract;
using Moq;
using MobileStore.Domain.Entities;
using System.Linq;
using MobileStore.WebUI.Controllers;
using System.Collections;
using System.Collections.Generic;

namespace MobileStore.UnitTests
{
    [TestClass]
    public class AdminProductTypeTests
    {
       [TestMethod]
       public void Index_Contains_All_ProductTypes()
        {
            Mock<IProductTypeRepository> mock = new Mock<IProductTypeRepository>();
            mock.Setup(m => m.ProductTypes).Returns(new ProductType[]
            {
                new ProductType {ProductTypeID=1,ProductTypeName="P1" },
                new ProductType {ProductTypeID=2,ProductTypeName="P2" },
                new ProductType {ProductTypeID=3,ProductTypeName="P3" }
            }.AsQueryable());

            AdminProductTypeController target = new AdminProductTypeController(mock.Object);

            ProductType[] result = ((IEnumerable<ProductType>)target.Index().ViewData.Model).ToArray();

            Assert.AreEqual(result.Length, 3);
            Assert.AreEqual("P1", result[0].ProductTypeName);
            Assert.AreEqual("P2", result[1].ProductTypeName);
            Assert.AreEqual("P3", result[2].ProductTypeName);
        }

        [TestMethod]
        public void Can_Edit_ProductType()
        {
            Mock<IProductTypeRepository> mock = new Mock<IProductTypeRepository>();
            mock.Setup(m => m.ProductTypes).Returns(new ProductType[]
            {
                new ProductType {ProductTypeID=1, ProductTypeName="P1" },
                new ProductType {ProductTypeID=2, ProductTypeName="P2" },
                new ProductType {ProductTypeID=3, ProductTypeName="P3" }
            }.AsQueryable());

            AdminProductTypeController target = new AdminProductTypeController(mock.Object);

            ProductType p1 = target.Edit(1).ViewData.Model as ProductType;
            ProductType p2 = target.Edit(2).ViewData.Model as ProductType;
            ProductType p3 = target.Edit(3).ViewData.Model as ProductType;

            Assert.AreEqual(1, p1.ProductTypeID);
            Assert.AreEqual(2, p2.ProductTypeID);
            Assert.AreEqual(3, p3.ProductTypeID);
        }

        [TestMethod]
        public void Can_Edit_Nonexistent_ProductType()
        {
            Mock<IProductTypeRepository> mock = new Mock<IProductTypeRepository>();
            mock.Setup(m => m.ProductTypes).Returns(new ProductType[]
            {
                new ProductType {ProductTypeID=1, ProductTypeName="P1" },
                new ProductType {ProductTypeID=2, ProductTypeName="P2" },
                new ProductType {ProductTypeID=3, ProductTypeName="P3" }
            }.AsQueryable());

            AdminProductTypeController target = new AdminProductTypeController(mock.Object);

            ProductType result = (ProductType)target.Edit(4).ViewData.Model;
            Assert.IsNull(result);
        }

        [TestMethod]
        public void Can_Delete_Valid_ProductType()
        {
            //stworzenie przykladwego ProducType
            ProductType productType = new ProductType { ProductTypeID = 2, ProductTypeName = "test" };
            Mock<IProductTypeRepository> mock = new Mock<IProductTypeRepository>();
            mock.Setup(m => m.ProductTypes).Returns(new ProductType[]
            {
                new ProductType {ProductTypeID=1,ProductTypeName="P1" },
                new ProductType {ProductTypeID=3, ProductTypeName="P3" }
            }.AsQueryable());

            AdminProductTypeController target = new AdminProductTypeController(mock.Object);
            target.Delete(productType.ProductTypeID);
            mock.Verify(m => m.DeleteProductType(productType.ProductTypeID));
        }
    }
}
