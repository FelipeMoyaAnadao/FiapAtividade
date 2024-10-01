using Fiap.Atividade.Data.Repository;
using Fiap.Atividade.Services;
using Fiap.Atividade.Models;

namespace Fiap.Atividade.Services
{
    public class OcorrenciaService : IOcorrenciaService
    {
        private readonly IOcorrenciaRepository _repository;

        public OcorrenciaService(IOcorrenciaRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<OcorrenciaModel> ListarOcorrencias() => _repository.GetAll();

        public IEnumerable<OcorrenciaModel> ListarOcorrencias(int page, int size) => _repository.GetAll(page, size);

        public OcorrenciaModel ObterOcorrenciaPorId(int id) => _repository.GetById(id);

        public void CriarOcorrencia(OcorrenciaModel ocorrencia) => _repository.Add(ocorrencia);

        public void AtualizarOcorrencia(OcorrenciaModel ocorrencia) => _repository.Update(ocorrencia);

        public void DeletarOcorrencia(int id)
        {
            var ocorrencia = _repository.GetById(id);
            if (ocorrencia != null)
            {
                _repository.Delete(ocorrencia);
            }
        }
    }
}
