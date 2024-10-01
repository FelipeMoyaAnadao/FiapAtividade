using Fiap.Atividade.Data.Repository;
using Fiap.Atividade.Models;

namespace Fiap.Atividade.Services
{
    public class SistemaAlarmeService : ISistemaAlarmeService
    {
        private readonly ISistemaAlarmeRepository _repository;

        public SistemaAlarmeService(ISistemaAlarmeRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<SistemaAlarmeModel> ListarSistemaAlarmes() => _repository.GetAll();
        public IEnumerable<SistemaAlarmeModel> ListarSistemaAlarmes(int page, int size) => _repository.GetAll(page, size);

        public SistemaAlarmeModel ObterSistemaAlarmePorId(int id) => _repository.GetById(id);

        public void CriarSistemaAlarme(SistemaAlarmeModel sistemaAlarme) => _repository.Add(sistemaAlarme);

        public void AtualizarSistemaAlarme(SistemaAlarmeModel sistemaAlarme) => _repository.Update(sistemaAlarme);

        public void DeletarSistemaAlarme(int id)
        {
            var sistemaAlarme = _repository.GetById(id);
            if (sistemaAlarme != null)
            {
                _repository.Delete(sistemaAlarme);
            }
        }
    }
}
