using Bombones2025.DatosSql.Interfaces;
using Bombones2025.Entidades.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Bombones2025.DatosSql.Repositorios
{
    public class ProvinciaEstadoRepositorio : IProvinciaEstadoRepositorio
    {
        private readonly BombonesDbContext _dbContext;

        public ProvinciaEstadoRepositorio(BombonesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<ProvinciaEstado> GetLista(int? paisId = null, string? textoFiltro=null)
        {
            IQueryable<ProvinciaEstado> query = _dbContext.ProvinciasEstados
                .Include(p => p.Pais).AsNoTracking();

            if (paisId.HasValue)
            {
                query = query
                .Where(p => p.PaisId == paisId.Value);
            }
            if (!string.IsNullOrEmpty(textoFiltro))
            {
                query = query.Where(
                    p => p.Pais!.NombrePais.Contains(textoFiltro) ||
                    p.NombreProvinciaEstado.Contains(textoFiltro));
            }
            return query.ToList();
        }
    }
}
