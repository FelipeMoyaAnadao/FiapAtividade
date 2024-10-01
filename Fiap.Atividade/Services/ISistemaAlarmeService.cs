using Fiap.Atividade.Models;

namespace Fiap.Atividade.Services
{
    public interface ISistemaAlarmeService
    {
        IEnumerable<SistemaAlarmeModel> ListarSistemaAlarmes();
        IEnumerable<SistemaAlarmeModel> ListarSistemaAlarmes(int page, int size);
        SistemaAlarmeModel ObterSistemaAlarmePorId(int id);
        void CriarSistemaAlarme(SistemaAlarmeModel sistemaAlarme);
        void AtualizarSistemaAlarme(SistemaAlarmeModel sistemaAlarme);
        void DeletarSistemaAlarme(int id);
    }
}
