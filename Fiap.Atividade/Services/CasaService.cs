using Fiap.Atividade.Data.Repository;
using Fiap.Atividade.Models;
namespace Fiap.Atividade.Services
{
    public class CasaService : ICasaService
    {
        private readonly ICasaRepository _repository;

        public CasaService(ICasaRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<CasaModel> ListarCasas() => _repository.GetAll();

        public IEnumerable<CasaModel> ListarCasas(int page, int size) => _repository.GetAll(page, size);

        public CasaModel ObterCasaPorId(int id) => _repository.GetById(id);

        public void CriarCasa(CasaModel casa) => _repository.Add(casa);

        public void AtualizarCasa(CasaModel casa) => _repository.Update(casa);

        public void DeletarCasa(int id)
        {
            var casa = _repository.GetById(id);
            if (casa != null)
            {
                _repository.Delete(casa);
            }
        }
    }
}
