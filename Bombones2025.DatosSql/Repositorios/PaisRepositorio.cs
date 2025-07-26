using Bombones2025.DatosSql.Interfaces;
using Bombones2025.Entidades.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Bombones2025.DatosSql.Repositorios
{
    public class PaisRepositorio : IPaisRepositorio
    {
        private readonly BombonesDbContext _dbContext; 

        public PaisRepositorio(BombonesDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        public void Agregar(Pais pais)
        {
            _dbContext.Paises.Add(pais);
            _dbContext.SaveChanges();
        }

        public void Borrar(int paisId)
        {
            var paisInDb = _dbContext.Paises.Find(paisId);
            if (paisInDb != null)
            {
                _dbContext.Paises.Remove(paisInDb);
                _dbContext.SaveChanges();
            }
        }

        public void Editar(Pais pais)
        {
            var paisInDb = GetPorId(pais.PaisId);
            if (paisInDb is null) return;
            paisInDb.NombrePais = pais.NombrePais;
            _dbContext.Entry(paisInDb).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public bool Existe(Pais pais)
        {
            return pais.PaisId == 0
                ? _dbContext.Paises.Any(p => p.NombrePais == pais.NombrePais)
                : _dbContext.Paises.Any(p => p.NombrePais == pais.NombrePais
                    && p.PaisId != pais.PaisId);
        }

        public List<Pais> ObtenerLista(string? textoFiltro = null)
        {
            return textoFiltro is null
                ? _dbContext.Paises.AsNoTracking().ToList()
                : _dbContext.Paises.AsNoTracking()
                .Where(p => p.NombrePais.StartsWith(textoFiltro))
                .ToList();
        }
        public int ObtenerCantidad() => _dbContext.Paises.Count();

        public bool EstaRelacionado(int paisId)
        {
            return _dbContext.ProvinciasEstados
                .Any(pe => pe.PaisId == paisId);
        }

        public Pais? GetPorId(int paisId)
        {
            return _dbContext.Paises.AsNoTracking()
                .FirstOrDefault(p => p.PaisId == paisId);
        }
    }
}
