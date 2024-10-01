using Fiap.Atividade.Models;
using Microsoft.EntityFrameworkCore;
namespace Fiap.Atividade.Data.Contexts
{
    public class DatabaseContext : DbContext
    {
        public virtual DbSet<CasaModel> Casas { get; set; }
        public virtual DbSet<OcorrenciaModel> Ocorrencias { get; set; }
        public virtual DbSet<SistemaAlarmeModel> SistemaAlarmes { get; set; }
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }
        protected DatabaseContext()
        {
        }
    }
}
