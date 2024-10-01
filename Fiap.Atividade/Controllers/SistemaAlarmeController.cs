using Fiap.Atividade.Data.Contexts;
using Fiap.Atividade.Models;
using Fiap.Atividade.Services;
using Fiap.Atividade.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Fiap.Atividade.Controllers
{
    [Authorize]
    public class SistemaAlarmeController : Controller
    {
        public IList<string> tipos { get; set; }

        private readonly DatabaseContext _context;
        private readonly ISistemaAlarmeService _sistemaAlarmeService;
        public SistemaAlarmeController(DatabaseContext context, ISistemaAlarmeService sistemaAlarmeService)
        {
            _context = context;
            _sistemaAlarmeService = sistemaAlarmeService;
            tipos = new List<string> { "Básico", "Médio", "Profissional" };
        }
        public IActionResult Index()
        {
            var sistemaAlarmes = _sistemaAlarmeService.ListarSistemaAlarmes();
            return View(sistemaAlarmes);
        }

        [HttpGet]
        public ActionResult<IEnumerable<CasaPaginacaoViewModel>> Get([FromQuery] int pagina = 1, [FromQuery] int tamanho = 10)
        {
            var sistemaAlarmes = _sistemaAlarmeService.ListarSistemaAlarmes(pagina, tamanho);
            var viewModel = new SistemaAlarmePaginacaoViewModel
            {
                SistemaAlarmes = sistemaAlarmes,
                CurrentPage = pagina,
                PageSize = tamanho
            };
            return Ok(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var viewModel = new SistemaAlarmeCreateViewModel
            {
                Tipo = new SelectList(tipos)
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(SistemaAlarmeCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var sistemaAlarmeModel = new SistemaAlarmeModel
                {
                    SistemaAlarmeId = viewModel.SistemaAlarmeId,
                    Localizacao = viewModel.Localizacao,
                    Nome = viewModel.Nome,
                };
                _sistemaAlarmeService.CriarSistemaAlarme(sistemaAlarmeModel);
                TempData["mensagemSucesso"] = $"O Sistema de Alarme com nome '{sistemaAlarmeModel.Nome}' foi cadastrado com sucesso";
                return RedirectToAction(nameof(Index));
            } else
            {        
                viewModel.Tipo = new SelectList(tipos);
                return View(viewModel);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            
            _sistemaAlarmeService.DeletarSistemaAlarme(id);
            //var sistemaAlarmeConsultado = sistemasAlarmes.Where(c => c.SistemaAlarmeId == id).FirstOrDefault();
            TempData["mensagemSucesso"] = $"Os dados do Sistema de Alarme foram removidos com sucesso";
            return RedirectToAction(nameof(Index));
        }
    }
}
