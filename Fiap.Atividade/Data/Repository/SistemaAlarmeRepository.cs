using Fiap.Atividade.Data.Contexts;
using Fiap.Atividade.Data.Repository;
using Fiap.Atividade.Models;
using Microsoft.EntityFrameworkCore;
namespace Fiap.Atividade.Data.Repository
{
    public class SistemaAlarmeRepository : ISistemaAlarmeRepository
    {
        private readonly DatabaseContext _context;
        public SistemaAlarmeRepository(DatabaseContext context)
        {
            _context = context;
        }
        public IEnumerable<SistemaAlarmeModel> GetAll() => _context.SistemaAlarmes.ToList();
        public IEnumerable<SistemaAlarmeModel> GetAll(int page, int size)
        {
            return _context.SistemaAlarmes.Skip((page - 1) * page).Take(size).AsNoTracking().ToList();
        }
        public IEnumerable<SistemaAlarmeModel> GetAllReference(int lastReference, int size)
        {
            var sistemaAlarmes = _context.SistemaAlarmes.Where(c => c.SistemaAlarmeId > lastReference).OrderBy(c => c.SistemaAlarmeId).Take(size).AsNoTracking().ToList();
            return sistemaAlarmes;
        }
        public SistemaAlarmeModel GetById(int id) => _context.SistemaAlarmes.Find(id);
        public void Add(SistemaAlarmeModel sistemaAlarme)
        {
            _context.SistemaAlarmes.Add(sistemaAlarme);
            _context.SaveChanges();
        }
        public void Update(SistemaAlarmeModel sistemaAlarme)
        {
            _context.Update(sistemaAlarme);
            _context.SaveChanges();
        }
        public void Delete(SistemaAlarmeModel sistemaAlarme)
        {
            _context.SistemaAlarmes.Remove(sistemaAlarme);
            _context.SaveChanges();
        }
    }
}
