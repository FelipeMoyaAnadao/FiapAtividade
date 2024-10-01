using Fiap.Atividade.Models;
namespace Fiap.Atividade.Services
{
    public interface ICasaService
    {
        IEnumerable<CasaModel> ListarCasas();
        IEnumerable<CasaModel> ListarCasas(int page, int size);
        CasaModel ObterCasaPorId(int id);
        void CriarCasa(CasaModel casa);
        void AtualizarCasa(CasaModel casa);
        void DeletarCasa(int id);
    }
}