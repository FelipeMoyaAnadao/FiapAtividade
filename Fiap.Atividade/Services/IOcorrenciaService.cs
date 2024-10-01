using Fiap.Atividade.Models;

namespace Fiap.Atividade.Services
{
    public interface IOcorrenciaService
    {
        public IEnumerable<OcorrenciaModel> ListarOcorrencias();
        IEnumerable<OcorrenciaModel> ListarOcorrencias(int page, int size);
        OcorrenciaModel ObterOcorrenciaPorId(int id);
        void CriarOcorrencia(OcorrenciaModel ocorrencia);
        void AtualizarOcorrencia(OcorrenciaModel ocorrencia);
        void DeletarOcorrencia(int id);
    }
}
