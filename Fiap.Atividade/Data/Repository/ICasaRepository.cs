using Fiap.Atividade.Models;
namespace Fiap.Atividade.Data.Repository
{
    public interface ICasaRepository
    {
        IEnumerable<CasaModel> GetAll();
        IEnumerable<CasaModel> GetAll(int page, int size);
        CasaModel GetById(int id);
        void Add(CasaModel casa);
        void Update(CasaModel casa);
        void Delete(CasaModel casa);
    }
}