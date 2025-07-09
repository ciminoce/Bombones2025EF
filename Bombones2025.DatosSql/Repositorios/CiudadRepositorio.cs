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

        public void Agregar(Ciudad ciudad)
        {
            _dbContext.Ciudades.Add(ciudad);
            _dbContext.SaveChanges();
        }

        public bool Existe(Ciudad ciudad)
        {
            return ciudad.CiudadId == 0 ? _dbContext.Ciudades.Any(
                    c => c.NombreCiudad == ciudad.NombreCiudad &&
                    c.ProvinciaEstadoId == ciudad.ProvinciaEstadoId) :
                    _dbContext.Ciudades.Any(
                    c => c.NombreCiudad == ciudad.NombreCiudad &&
                    c.ProvinciaEstadoId == ciudad.ProvinciaEstadoId &&
                    c.CiudadId != ciudad.CiudadId); 
        }

        public List<Ciudad> GetLista(int? provinciaId=null, string? textoFiltro=null)
        {
            /*
             * Vamos a obtener la lista de las ciudades
             * con todos sus datos incluidos los datos del país
             * y del estado
             */
            //return _dbContext.Ciudades.Include(c=>c.ProvinciaEstado)
            //    .ThenInclude(pe=>pe.Pais)
            //    .AsNoTracking()
            //    .ToList();
            IQueryable<Ciudad> query = _dbContext.Ciudades
                .Include(c => c.ProvinciaEstado)
                .ThenInclude(pe => pe.Pais)
                .AsNoTracking();
            if (provinciaId != null)
            {
                query=query.Where(c=>c.ProvinciaEstadoId==provinciaId);
            }
            if(textoFiltro != null)
            {
                query = query.Where(c => c.NombreCiudad.Contains(textoFiltro));
            }
            return query.ToList();
        }
    }
}
