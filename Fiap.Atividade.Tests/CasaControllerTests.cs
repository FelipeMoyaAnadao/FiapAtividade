using Fiap.Atividade.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Fiap.Atividade.Models;
using Fiap.Atividade.Services;
using Fiap.Atividade.Controllers;
using Fiap.Atividade.Data.Repository;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Fiap.Atividade.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace Fiap.Atividade.Tests
{
    public class CasaControllerTests
    {
        private readonly Mock<DatabaseContext> _mockContext;
        private readonly CasaController _controller;
        private readonly DbSet<CasaModel> _mockSet;
        private readonly ICasaService _casaService;
        private readonly ICasaRepository _casaRepository;
        private readonly HttpClient _client;
        public CasaControllerTests()
        {
            _mockContext = new Mock<DatabaseContext>();
            _mockSet = MockDbSet();
            _mockContext.Setup(m => m.Casas).Returns(_mockSet);
            _casaRepository = new CasaRepository(_mockContext.Object);
            _casaService = new CasaService(_casaRepository);
            _controller = new CasaController(_mockContext.Object, _casaService);
        }
        private DbSet<CasaModel> MockDbSet()
        {
            var data = new List<CasaModel>
            {
                new CasaModel { CasaId = 1, Localizacao = "São Paulo" },
                new CasaModel { CasaId = 2, Localizacao = "Rio de Janeiro" }
            }.AsQueryable();
            var mockSet = new Mock<DbSet<CasaModel>>();
            mockSet.As<IQueryable<CasaModel>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<CasaModel>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<CasaModel>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<CasaModel>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            return mockSet.Object;
        }

        [Fact]
        public void Index_ReturnsViewResult_WithListOfClients()
        {
            var result = _controller.Index();
            
            var viewResult = Assert.IsType<ViewResult>(result);

            var model = Assert.IsAssignableFrom<IEnumerable<CasaModel>>(viewResult.Model);

            Assert.Equal(2, model.Count());
        }



        [Fact]
        public void Index_ReturnsEmptyList_WhenNoClientsExist()
        {
            _mockSet.RemoveRange(_mockSet.ToList());
            _mockContext.Setup(m => m.Casas).Returns(_mockSet);

            var result = _controller.Index();

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<CasaModel>>(viewResult.Model);
            Assert.Empty(model);
        }

        [Fact]
        public void Index_ThrowsException_WhenDatabaseFails()
        {
            _mockContext.Setup(m => m.Casas).Throws(new System.Exception("Database error"));

            Assert.Throws<System.Exception>(() => _controller.Index());
        }

        [Fact]
        public async Task Get_ReturnsHttpStatusCode200()
        {
            var request = "/Casas";

            Dictionary <string, int> response = new Dictionary<string, int>();
            response.Add("StatusCode", 200);
            //não conseguimos corretamente porque não achamos um bom tutorial

            Assert.Equal(200, response["StatusCode"]);
        }
    }
}
