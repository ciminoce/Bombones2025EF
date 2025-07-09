using Bombones2025.DatosSql.Interfaces;
using Bombones2025.Entidades.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Bombones2025.DatosSql.Repositorios
{
    public class CiudadRepositorio : ICiudadRepositorio
    {
        private BombonesDbContext _dbContext;

        public CiudadRepositorio(BombonesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Ciudad> GetLista()
        {
            /*
             * Vamos a obtener la lista de las ciudades
             * con todos sus datos incluidos los datos del país
             * y del estado
             */
            return _dbContext.Ciudades.Include(c=>c.ProvinciaEstado)
                .ThenInclude(pe=>pe.Pais)
                .AsNoTracking()
                .ToList();
        }
    }
}
