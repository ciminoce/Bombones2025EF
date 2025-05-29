using Bombones2025.DatosSql.Interfaces;
using Bombones2025.Entidades.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Bombones2025.DatosSql.Repositorios
{
    public class RellenoRepositorio : IRellenoRepositorio
    {
        private readonly BombonesDbContext? _dbContext;

        public RellenoRepositorio(BombonesDbContext? dbContext)
        {
            _dbContext = dbContext;
        }

        public void Agregar(Relleno relleno)
        {
            _dbContext.Rellenos.Add(relleno);
            _dbContext.SaveChanges();
        }

        public void Borrar(int rellenoId)
        {
            var rellenoInDb = _dbContext.Rellenos.Find(rellenoId);
            if (rellenoInDb != null)
            {
                _dbContext.Rellenos.Remove(rellenoInDb);
                _dbContext.SaveChanges();
            }
        }

        public void Editar(Relleno relleno)
        {
            _dbContext.Rellenos.Update(relleno);
            _dbContext.SaveChanges();
        }

        public bool Existe(Relleno relleno)
        {
            return relleno.RellenoId == 0
                ? _dbContext.Rellenos.Any(p => p.Descripcion == relleno.Descripcion)
                : _dbContext.Rellenos.Any(p => p.Descripcion == relleno.Descripcion
                    && p.RellenoId == relleno.RellenoId);
        }

        public List<Relleno> GetLista(string? textoFiltro = null)
        {
            return textoFiltro is null
                ? _dbContext.Rellenos.AsNoTracking().ToList()
                : _dbContext.Rellenos.AsNoTracking()
                .Where(p => p.Descripcion.StartsWith(textoFiltro))
                .ToList();
        }
        public int GetCantidad() => _dbContext.Rellenos.Count();

    }
}
