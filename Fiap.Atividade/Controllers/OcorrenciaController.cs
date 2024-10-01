using Fiap.Atividade.Data.Contexts;
using Fiap.Atividade.Models;
using Fiap.Atividade.Services;
using Fiap.Atividade.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Fiap.Atividade.Controllers
{
    public class OcorrenciaController : Controller
    {
        private readonly DatabaseContext _context;
        private readonly IOcorrenciaService _ocorrenciaService;
        public IList<string> tipos { get; set; }
        public OcorrenciaController(DatabaseContext context, IOcorrenciaService ocorrenciaService)
        {
            _context = context;
            _ocorrenciaService = ocorrenciaService;
            tipos = new List<string> { "Leve", "Média", "Grave" };
        }

        public IActionResult Index()
        {
            var ocorrencias = _ocorrenciaService.ListarOcorrencias();
            return View(ocorrencias);
        }

        [HttpGet]
        public ActionResult<IEnumerable<CasaPaginacaoViewModel>> Get([FromQuery] int pagina = 1, [FromQuery] int tamanho = 10)
        {
            var ocorrencias = _ocorrenciaService.ListarOcorrencias(pagina, tamanho);
            var viewModel = new OcorrenciaPaginacaoViewModel
            {
                Ocorrencias = ocorrencias,
                CurrentPage = pagina,
                PageSize = tamanho
            };
            return Ok(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            Console.WriteLine("Executou a Action Cadastrar()");
            var viewModel = new OcorrenciaCreateViewModel
            {
                Tipo = new SelectList(tipos)
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(OcorrenciaCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var ocorrenciaModel = new OcorrenciaModel
                {
                    OcorrenciaId = viewModel.OcorrenciaId,
                    DiaOcorrencia = viewModel.DiaOcorrencia,
                    Descricao = viewModel.Descricao
                };
                _ocorrenciaService.CriarOcorrencia(ocorrenciaModel);
                TempData["mensagemSucesso"] = $"A ocorrência com descrição '{ocorrenciaModel.Descricao}' foi cadastrada com sucesso";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                viewModel.Tipo = new SelectList(tipos);
                return View(viewModel);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _ocorrenciaService.DeletarOcorrencia(id);
            TempData["mensagemSucesso"] = $"Os dados da ocorrencia foram removidos com sucesso";
            return RedirectToAction(nameof(Index));
        }
    }
}
