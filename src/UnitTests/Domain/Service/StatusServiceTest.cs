using Domain.Contracts.Services;
using Domain.DTO;
using Domain.Service;
using Domain.VO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace UnitTests.Domain.Service
{
    [TestClass]
    public class StatusServiceTest
    {
        private readonly IStatusService _statusService;
        public StatusServiceTest()
        {
            _statusService = new StatusService();
        }
        [TestMethod]
        [TestCategory("StatusValidation")]
        public void IsValidateReturnAprovado()
        {
            #region Arrage
            var totalorder = new TotalOrder("123456")
            {
                Amount = 20,
                Qtd = 3
            };
            StatusRequest statusRequest = new StatusRequest()
            {
                OrderId = "123456",
                AmountApproved = 20,
                ItensApproved = 3,
                Status = "APROVADO"
            };
            #endregion
            #region ACT

            var result = _statusService.Validate(totalorder, statusRequest);
            #endregion
            #region Assert
            var expectedJson = JsonConvert.SerializeObject( new List<string>() { "APROVADO" });
            var resultJson = JsonConvert.SerializeObject(result);
            Assert.AreEqual(expectedJson, resultJson);
            #endregion
        }
        [TestMethod]
        [TestCategory("StatusValidation")]
        public void IsValidateReturnAprovadoValorMenor()
        {
            #region Arrage
            var totalorder = new TotalOrder("123456")
            {
                Amount = 20,
                Qtd = 3
            };
            StatusRequest statusRequest = new StatusRequest()
            {
                OrderId = "123456",
                AmountApproved = 10,
                ItensApproved = 3,
                Status = "APROVADO"
            };
            #endregion
            #region ACT

            var result = _statusService.Validate(totalorder, statusRequest);
            #endregion
            #region Assert
            var expectedJson = JsonConvert.SerializeObject(new List<string>() { "APROVADO_VALOR_A_MENOR" });
            var resultJson = JsonConvert.SerializeObject(result);
            Assert.AreEqual(expectedJson, resultJson);
            #endregion
        }
        [TestMethod]
        [TestCategory("StatusValidation")]
        public void IsValidateReturnAprovadoValorAndQtdMaior()
        {
            #region Arrage
            var totalorder = new TotalOrder("123456")
            {
                Amount = 20,
                Qtd = 3
            };
            StatusRequest statusRequest = new StatusRequest()
            {
                OrderId = "123456",
                AmountApproved = 21,
                ItensApproved = 4,
                Status = "APROVADO"
            };
            #endregion
            #region ACT

            var result = _statusService.Validate(totalorder, statusRequest);
            #endregion
            #region Assert
            var expectedJson = JsonConvert.SerializeObject(new List<string>() {"APROVADO_VALOR_A_MAIOR", "APROVADO_QTD_A_MAIOR", });
            var resultJson = JsonConvert.SerializeObject(result);
            Assert.AreEqual(expectedJson, resultJson);
            #endregion
        }
        [TestMethod]
        [TestCategory("StatusValidation")]
        public void IsValidateReturnAprovadoQtdMenor()
        {
            #region Arrage
            var totalorder = new TotalOrder("123456")
            {
                Amount = 20,
                Qtd = 3
            };
            StatusRequest statusRequest = new StatusRequest()
            {
                OrderId = "123456",
                AmountApproved = 20,
                ItensApproved = 2,
                Status = "APROVADO"
            };
            #endregion
            #region ACT

            var result = _statusService.Validate(totalorder, statusRequest);
            #endregion
            #region Assert
            var expectedJson = JsonConvert.SerializeObject(new List<string>() { "APROVADO_QTD_A_MENOR" });
            var resultJson = JsonConvert.SerializeObject(result);
            Assert.AreEqual(expectedJson, resultJson);
            #endregion
        }
        [TestMethod]
        [TestCategory("StatusValidation")]
        public void IsValidateReturnReprovado()
        {
            #region Arrage
            var totalorder = new TotalOrder("123456")
            {
                Amount = 20,
                Qtd = 3
            };
            StatusRequest statusRequest = new StatusRequest()
            {
                OrderId = "123456",
                AmountApproved = 0,
                ItensApproved = 0,
                Status = "REPROVADO"
            };
            #endregion
            #region ACT

            var result = _statusService.Validate(totalorder, statusRequest);
            #endregion
            #region Assert
            var expectedJson = JsonConvert.SerializeObject(new List<string>() { "REPROVADO" });
            var resultJson = JsonConvert.SerializeObject(result);
            Assert.AreEqual(expectedJson, resultJson);
            #endregion
        }
    }
}
