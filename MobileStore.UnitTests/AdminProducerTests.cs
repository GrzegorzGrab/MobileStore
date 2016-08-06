using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MobileStore.Domain.Abstract;
using MobileStore.Domain.Entities;
using MobileStore.WebUI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MobileStore.UnitTests
{
    [TestClass]
    public class AdminProducerTests
    {
        [TestMethod]
        public void Index_Contains_All_Producers()
        {
            Mock<IProducerRepository> mock = new Mock<IProducerRepository>();
            mock.Setup(m => m.Producers).Returns(new Producer[]
            {
                new Producer {ProducerID=1, ProducerName="P1" },
                new Producer {ProducerID=2, ProducerName="P2" },
                new Producer {ProducerID=3, ProducerName="P3" }
            }.AsQueryable());

            AdminProducerController target = new AdminProducerController(mock.Object);

            Producer[] result = ((IEnumerable<Producer>)target.Index().ViewData.Model).ToArray();

            Assert.AreEqual(result.Length, 3);
            Assert.AreEqual("P1", result[0].ProducerName);
            Assert.AreEqual("P2", result[1].ProducerName);
            Assert.AreEqual("P3", result[2].ProducerName);
        }

        [TestMethod]
        public void Can_Edit_Producer()
        {
            Mock<IProducerRepository> mock = new Mock<IProducerRepository>();
            mock.Setup(m => m.Producers).Returns(new Producer[]
            {
                new Producer {ProducerID=1, ProducerName="P1" },
                new Producer {ProducerID=2, ProducerName="P2" },
                new Producer {ProducerID=3, ProducerName="P3" }
            }.AsQueryable());

            AdminProducerController target = new AdminProducerController(mock.Object);

            Producer p1 = target.Edit(1).ViewData.Model as Producer;
            Producer p2 = target.Edit(2).ViewData.Model as Producer;
            Producer p3 = target.Edit(3).ViewData.Model as Producer;

            Assert.AreEqual(1, p1.ProducerID);
            Assert.AreEqual(2, p2.ProducerID);
            Assert.AreEqual(3, p3.ProducerID);
        }

        [TestMethod]
        public void Cannot_Edit_Nonexistent_Producer()
        {
            Mock<IProducerRepository> mock = new Mock<IProducerRepository>();
            mock.Setup(m => m.Producers).Returns(new Producer[]
            {
                new Producer {ProducerID=1, ProducerName="P1" },
                new Producer {ProducerID=2, ProducerName="P2" },
                new Producer {ProducerID=3, ProducerName="P3" }
            }.AsQueryable());

            AdminProducerController target = new AdminProducerController(mock.Object);

            Producer result = (Producer)target.Edit(4).ViewData.Model;

            Assert.IsNull(result);
        }

        [TestMethod]
        public void Can_Delete_Valid_Producer()
        {
            //stworzenie przykladowego producenta
            Producer prod = new Producer { ProducerID = 2, ProducerName = "Test" };

            Mock<IProducerRepository> mock = new Mock<IProducerRepository>();
            mock.Setup(m => m.Producers).Returns(new Producer[]
            {
                new Producer {ProducerID=1, ProducerName="P1" },
                prod,
                new Producer {ProducerID=3, ProducerName="P3" }
            }.AsQueryable());

            AdminProducerController target = new AdminProducerController(mock.Object);

            target.Delete(prod.ProducerID);

            mock.Verify(m => m.DeleteProducer(prod.ProducerID));
        }
    }
}
