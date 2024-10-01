using Fiap.Atividade.Models;

namespace Fiap.Atividade.Data.Repository
{
    public interface IOcorrenciaRepository
    {
        IEnumerable<OcorrenciaModel> GetAll();
        IEnumerable<OcorrenciaModel> GetAll(int page, int size);
        OcorrenciaModel GetById(int id);
        void Add(OcorrenciaModel ocorrencia);
        void Update(OcorrenciaModel ocorrencia);
        void Delete(OcorrenciaModel ocorrencia);
    }
}
