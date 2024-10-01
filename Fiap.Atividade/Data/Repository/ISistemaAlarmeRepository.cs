using Fiap.Atividade.Models;

namespace Fiap.Atividade.Data.Repository
{
    public interface ISistemaAlarmeRepository
    {
        IEnumerable<SistemaAlarmeModel> GetAll();
        IEnumerable<SistemaAlarmeModel> GetAll(int page, int size);
        SistemaAlarmeModel GetById(int id);
        void Add(SistemaAlarmeModel sistemaAlarme);
        void Update(SistemaAlarmeModel sistemaAlarme);
        void Delete(SistemaAlarmeModel sistemaAlarme);
    }
}
