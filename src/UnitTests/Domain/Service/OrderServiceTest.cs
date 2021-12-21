using Domain.Contracts.Services;
using Domain.Entities;
using Domain.Service;
using Domain.VO;
using Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Collections.Generic;
using UnitTests.FakeRepository;

namespace UnitTests.Domain.Service
{
    [TestClass]
    public class OrderServiceTest
    {
        private readonly IOrderService _orderService;
        public OrderServiceTest()
        {
            _orderService = new OrderService(new OrderFakeRepository());
        }

        [TestMethod]
        public void GetTotalOrderTwoItens()
        {
            #region Arrage
            var expectedTotalOrder = new TotalOrder("123456")
            {
                Amount = 60,
                Qtd = 7
            };
            var orderId = "123456";
            #endregion
            #region ACT

            var result = _orderService.GetTotalOrder(orderId);
            #endregion
            #region Assert
            var expectedJson = JsonConvert.SerializeObject(expectedTotalOrder);
            var resultJson = JsonConvert.SerializeObject(result);
            Assert.AreEqual(expectedJson, resultJson);
            #endregion
        }
        [TestMethod]
        public void GetTotalOrderOneIten()
        {
            #region Arrage
            var expectedTotalOrder = new TotalOrder("one")
            {
                Amount = 20,
                Qtd = 2
            };
            var orderId = "one";
            #endregion
            #region ACT

            var result = _orderService.GetTotalOrder(orderId);
            #endregion
            #region Assert
            var expectedJson = JsonConvert.SerializeObject(expectedTotalOrder);
            var resultJson = JsonConvert.SerializeObject(result);
            Assert.AreEqual(expectedJson, resultJson);
            #endregion
        }
        [TestMethod]
        public void GetTotalOrderOneQtdIten()
        {
            #region Arrage
            var expectedTotalOrder = new TotalOrder("oneQtd")
            {
                Amount = 20,
                Qtd =1
            };
            var orderId = "oneQtd";
            #endregion
            #region ACT

            var result = _orderService.GetTotalOrder(orderId);
            #endregion
            #region Assert
            var expectedJson = JsonConvert.SerializeObject(expectedTotalOrder);
            var resultJson = JsonConvert.SerializeObject(result);
            Assert.AreEqual(expectedJson, resultJson);
            #endregion
        }
        [TestMethod]
        [ExpectedException(typeof(AlredyExistsException))]
        public void InsertReturnAlreadyExists()
        {
            #region Arrage
            var order = new Order
            {
                Id = "123456",
                Items = new List<Item>()
                {
                    new Item()
                    {
                        Description = "Item A",
                        Qtd = 1,
                        UnitPrice = 10
                    },
                    new Item()
                    {
                        Description = "Item B",
                        UnitPrice = 5,
                        Qtd= 2
                    }
                }
            };
            #endregion
            #region ACT

            _orderService.Insert(order);
            #endregion
        }
        [TestMethod]
        public void InsertReturnOk()
        {
            #region Arrage
            var order = new Order
            {
                Id = "12345665",
                Items = new List<Item>()
                {
                    new Item()
                    {
                        Description = "Item A",
                        Qtd = 1,
                        UnitPrice = 10
                    },
                    new Item()
                    {
                        Description = "Item B",
                        UnitPrice = 5,
                        Qtd= 2
                    }
                }
            };
            #endregion
            #region ACT

            _orderService.Insert(order);
            #endregion
            #region Assert
            Assert.IsTrue(true);
            #endregion
        }
        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public void DeleteReturnNotFound()
        {
            #region Arrage
            var orderId = "M456";
            #endregion
            #region ACT

            _orderService.Delete(orderId);
            #endregion
        }
        [TestMethod]
        public void DeleteReturnOk()
        {
            #region Arrage
            var orderId = "123456";
            #endregion
            #region ACT

            _orderService.Delete(orderId);
            #endregion
            #region Assert
            Assert.IsTrue(true);
            #endregion
        }
    }
}
