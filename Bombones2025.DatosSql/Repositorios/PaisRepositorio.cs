using Bombones2025.DatosSql.Interfaces;
using Bombones2025.Entidades.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Bombones2025.DatosSql.Repositorios
{
    public class PaisRepositorio : IPaisRepositorio
    {
        private readonly BombonesDbContext? _dbContext;

        public PaisRepositorio(BombonesDbContext? dbContext)
        {
            _dbContext = dbContext;
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
            _dbContext.Paises.Update(pais);
            _dbContext.SaveChanges();
        }

        public bool Existe(Pais pais)
        {
            return pais.PaisId == 0
                ? _dbContext.Paises.Any(p => p.NombrePais == pais.NombrePais)
                : _dbContext.Paises.Any(p => p.NombrePais == pais.NombrePais
                    && p.PaisId == pais.PaisId);
        }

        public List<Pais> GetLista(string? textoFiltro = null)
        {
            return textoFiltro is null
                ? _dbContext.Paises.AsNoTracking().ToList()
                : _dbContext.Paises.AsNoTracking()
                .Where(p => p.NombrePais.StartsWith(textoFiltro))
                .ToList();
        }
        public int GetCantidad() => _dbContext.Paises.Count();
    }
}
