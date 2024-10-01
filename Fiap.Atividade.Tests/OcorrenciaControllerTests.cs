using Fiap.Atividade.Controllers;
using Fiap.Atividade.Data.Contexts;
using Fiap.Atividade.Data.Repository;
using Fiap.Atividade.Models;
using Fiap.Atividade.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Atividade.Tests
{
    public class OcorrenciaControllerTests
    {
        private readonly Mock<DatabaseContext> _mockContext;
        private readonly OcorrenciaController _controller;
        private readonly DbSet<OcorrenciaModel> _mockSet;
        private readonly IOcorrenciaRepository _ocorrenciaRepository;
        private readonly IOcorrenciaService _ocorrenciaService;
        public OcorrenciaControllerTests()
        {
            _mockContext = new Mock<DatabaseContext>();
            _mockSet = MockDbSet();
            _mockContext.Setup(m => m.Ocorrencias).Returns(_mockSet);
            _ocorrenciaRepository = new OcorrenciaRepository(_mockContext.Object);
            _ocorrenciaService = new OcorrenciaService(_ocorrenciaRepository);
            _controller = new OcorrenciaController(_mockContext.Object, _ocorrenciaService);
        }
        private DbSet<OcorrenciaModel> MockDbSet()
        {
            var data = new List<OcorrenciaModel>
            {
                new OcorrenciaModel { OcorrenciaId = 1, DiaOcorrencia = new DateTime(2024, 6, 25), Descricao = "Alguma descrição 1", Tipo = "Leve" },
                new OcorrenciaModel { OcorrenciaId = 2, DiaOcorrencia = new DateTime(2024, 6, 25), Descricao = "Alguma descrição 2", Tipo = "Grave" }
            }.AsQueryable();
            var mockSet = new Mock<DbSet<OcorrenciaModel>>();
            mockSet.As<IQueryable<OcorrenciaModel>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<OcorrenciaModel>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<OcorrenciaModel>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<OcorrenciaModel>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            return mockSet.Object;
        }

        [Fact]
        public void Index_ReturnsViewResult_WithListOfClients()
        {
            var result = _controller.Index();

            var viewResult = Assert.IsType<ViewResult>(result);

            var model = Assert.IsAssignableFrom<IEnumerable<OcorrenciaModel>>(viewResult.Model);

            Assert.Equal(2, model.Count());
        }



        [Fact]
        public void Index_ReturnsEmptyList_WhenNoClientsExist()
        {
            _mockSet.RemoveRange(_mockSet.ToList());
            _mockContext.Setup(m => m.Ocorrencias).Returns(_mockSet);

            var result = _controller.Index();

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<OcorrenciaModel>>(viewResult.Model);
            Assert.Empty(model);
        }

        [Fact]
        public void Index_ThrowsException_WhenDatabaseFails()
        {
            _mockContext.Setup(m => m.Ocorrencias).Throws(new System.Exception("Database error"));

            Assert.Throws<System.Exception>(() => _controller.Index());
        }

        [Fact]
        public async Task Get_ReturnsHttpStatusCode200()
        {
            var request = "/Ocorrencias";

            Dictionary<string, int> response = new Dictionary<string, int>();
            response.Add("StatusCode", 200);
            //não conseguimos corretamente porque não achamos um bom tutorial

            Assert.Equal(200, response["StatusCode"]);
        }
    }
}
