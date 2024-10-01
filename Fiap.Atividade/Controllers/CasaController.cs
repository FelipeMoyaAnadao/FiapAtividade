using Fiap.Atividade.Models;
using Microsoft.AspNetCore.Mvc;
using Fiap.Atividade.Data.Contexts;
using Fiap.Atividade.Services;
using Fiap.Atividade.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Oracle.ManagedDataAccess.Client;
using Fiap.Atividade.ViewModel;

namespace Fiap.Atividade.Controllers
{
    public class CasaController : Controller
    {
        private readonly DatabaseContext _context;
        private readonly ICasaService _casaService;
        public CasaController(DatabaseContext context, ICasaService casaService)
        {
            _context = context;
            _casaService = casaService;
        }

        public IActionResult Index()
        {
            var casas = _casaService.ListarCasas();
            return View(casas);
        }

        [HttpGet]
        public ActionResult<IEnumerable<CasaPaginacaoViewModel>> Get([FromQuery] int pagina = 1, [FromQuery] int tamanho = 10)
        {
            var casas = _casaService.ListarCasas(pagina, tamanho);
            var viewModel = new CasaPaginacaoViewModel
            {
                Casas = casas,
                CurrentPage = pagina,
                PageSize = tamanho
            };
            return Ok(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            Console.WriteLine("Executou a Action Cadastrar()");
            var viewModel = new CasaCreateViewModel { };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(CasaCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var casaModel = new CasaModel
                {
                    CasaId = viewModel.CasaId,
                    Localizacao = viewModel.Localizacao,
                };
                _casaService.CriarCasa(casaModel);
                TempData["mensagemSucesso"] = $"A casa de Localizacao '{casaModel.Localizacao}' foi cadastrado com sucesso";
                return RedirectToAction(nameof(Index));
            } else
            {
                return View();
            }
        }

        [HttpPost]
        public IActionResult Edit(CasaModel casaModel)
        {
            _casaService.AtualizarCasa(casaModel);
            TempData["mensagemSucesso"] = $"Os dados da casa de ID {casaModel.CasaId}, e localização {casaModel.Localizacao} foram alterados com sucesso";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var casa = _casaService.ObterCasaPorId(id);
            if (casa != null)
            {
                return NotFound();
            }
            return View(casa);
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            _casaService.DeletarCasa(id);
            TempData["mensagemSucesso"] = $"Os dados da casa foram removidos com sucesso";
            return RedirectToAction(nameof(Index));
        }
    }
}
