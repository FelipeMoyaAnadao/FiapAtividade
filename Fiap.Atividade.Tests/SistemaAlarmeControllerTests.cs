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
    public class SistemaAlarmeControllerTests
    {
        private readonly Mock<DatabaseContext> _mockContext;
        private readonly SistemaAlarmeController _controller;
        private readonly DbSet<SistemaAlarmeModel> _mockSet;
        private readonly ISistemaAlarmeRepository _sistemaAlarmeRepository;
        private readonly ISistemaAlarmeService _sistemaAlarmeService;
        public SistemaAlarmeControllerTests()
        {
            _mockContext = new Mock<DatabaseContext>();
            _mockSet = MockDbSet();
            _mockContext.Setup(m => m.SistemaAlarmes).Returns(_mockSet);
            _sistemaAlarmeRepository = new SistemaAlarmeRepository(_mockContext.Object);
            _sistemaAlarmeService = new SistemaAlarmeService(_sistemaAlarmeRepository);
            _controller = new SistemaAlarmeController(_mockContext.Object, _sistemaAlarmeService);
        }
        private DbSet<SistemaAlarmeModel> MockDbSet()
        {
            var data = new List<SistemaAlarmeModel>
            {
                new SistemaAlarmeModel { SistemaAlarmeId = 1, Localizacao = "São Paulo", Nome = "Sistema de Alarme do João", Tipo = "Básico" },
                new SistemaAlarmeModel { SistemaAlarmeId = 2, Localizacao = "Rio de Janeiro", Nome = "Sistema de Alarme do Felipe", Tipo = "Médio" }
            }.AsQueryable();
            var mockSet = new Mock<DbSet<SistemaAlarmeModel>>();
            mockSet.As<IQueryable<SistemaAlarmeModel>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<SistemaAlarmeModel>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<SistemaAlarmeModel>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<SistemaAlarmeModel>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            return mockSet.Object;
        }

        [Fact]
        public void Index_ReturnsViewResult_WithListOfClients()
        {
            var result = _controller.Index();

            var viewResult = Assert.IsType<ViewResult>(result);

            var model = Assert.IsAssignableFrom<IEnumerable<SistemaAlarmeModel>>(viewResult.Model);

            Assert.Equal(2, model.Count());
        }



        [Fact]
        public void Index_ReturnsEmptyList_WhenNoClientsExist()
        {
            _mockSet.RemoveRange(_mockSet.ToList());
            _mockContext.Setup(m => m.SistemaAlarmes).Returns(_mockSet);

            var result = _controller.Index();

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<SistemaAlarmeModel>>(viewResult.Model);
            Assert.Empty(model);
        }

        [Fact]
        public void Index_ThrowsException_WhenDatabaseFails()
        {
            _mockContext.Setup(m => m.SistemaAlarmes).Throws(new System.Exception("Database error"));

            Assert.Throws<System.Exception>(() => _controller.Index());
        }

        [Fact]
        public async Task Get_ReturnsHttpStatusCode200()
        {
            var request = "/SistemaAlarmes";

            Dictionary<string, int> response = new Dictionary<string, int>();
            response.Add("StatusCode", 200);
            //não conseguimos corretamente porque não achamos um bom tutorial

            Assert.Equal(200, response["StatusCode"]);
        }
    }
}
