using Fiap.Atividade.Data.Contexts;
using Fiap.Atividade.Data.Repository;
using Fiap.Atividade.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Atividade.Data.Repository
{
    public class CasaRepository : ICasaRepository
    {
        private readonly DatabaseContext _context;
        public CasaRepository(DatabaseContext context)
        {
            _context = context;
        }
        public IEnumerable<CasaModel> GetAll() => _context.Casas.ToList();
        public IEnumerable<CasaModel> GetAll(int page, int size)
        {
            return _context.Casas.Skip( (page - 1) * page).Take(size).AsNoTracking().ToList();
        }
        public IEnumerable<CasaModel> GetAllReference(int lastReference, int size)
        {
            var casas = _context.Casas.Where(c => c.CasaId > lastReference).OrderBy(c => c.CasaId).Take(size).AsNoTracking().ToList();
            return casas;
        }
        public CasaModel GetById(int id) => _context.Casas.Find(id);
        public void Add(CasaModel casa)
        {
            _context.Casas.Add(casa);
            _context.SaveChanges();
        }
        public void Update(CasaModel casa)
        {
            _context.Update(casa);
            _context.SaveChanges();
        }
        public void Delete(CasaModel casa)
        {
            _context.Casas.Remove(casa);
            _context.SaveChanges();
        }
    }
}