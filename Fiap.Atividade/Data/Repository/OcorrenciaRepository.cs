using Fiap.Atividade.Data.Contexts;
using Fiap.Atividade.Data.Repository;
using Fiap.Atividade.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Atividade.Data.Repository
{
    public class OcorrenciaRepository : IOcorrenciaRepository
    {
        private readonly DatabaseContext _context;
        public OcorrenciaRepository(DatabaseContext context)
        {
            _context = context;
        }
        public IEnumerable<OcorrenciaModel> GetAll() => _context.Ocorrencias.ToList();
        public IEnumerable<OcorrenciaModel> GetAll(int page, int size)
        {
            return _context.Ocorrencias.Skip((page - 1) * page).Take(size).AsNoTracking().ToList();
        }
        public IEnumerable<OcorrenciaModel> GetAllReference(int lastReference, int size)
        {
            var ocorrencias = _context.Ocorrencias.Where(c => c.OcorrenciaId > lastReference).OrderBy(c => c.OcorrenciaId).Take(size).AsNoTracking().ToList();
            return ocorrencias;
        }
        public OcorrenciaModel GetById(int id) => _context.Ocorrencias.Find(id);
        public void Add(OcorrenciaModel ocorrencia)
        {
            _context.Ocorrencias.Add(ocorrencia);
            _context.SaveChanges();
        }
        public void Update(OcorrenciaModel ocorrencia)
        {
            _context.Update(ocorrencia);
            _context.SaveChanges();
        }
        public void Delete(OcorrenciaModel ocorrencia)
        {
            _context.Ocorrencias.Remove(ocorrencia);
            _context.SaveChanges();
        }
    }
}
