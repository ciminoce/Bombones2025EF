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

        public void Borrar(int ciudadId)
        {
            var ciudadInDb=GetById(ciudadId);
            //Como lo traigo trackeado si existe lo remuevo
            if (ciudadInDb!=null)
            {
                _dbContext.Ciudades.Remove(ciudadInDb);
                _dbContext.SaveChanges();//confirmo el borrado
            }
        }

        public Ciudad? GetById(int ciudadId)
        {
            return _dbContext.Ciudades
                .Include(c=>c.ProvinciaEstado)
                .ThenInclude(p=>p.Pais)
                .FirstOrDefault(c=>c.CiudadId== ciudadId);

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

        public List<Ciudad> GetLista(int? paisId = null, int? provinciaId=null, string? textoFiltro=null)
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
                .ThenInclude(pe => pe!.Pais)
                .AsNoTracking();
            if(paisId != null)
            {
                query=query.Where(c=>c.ProvinciaEstado!.PaisId== paisId);
            }

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

        public void Editar(Ciudad ciudad)
        {
            //Lo traigo trackeado
            var ciudadInDb = GetById(ciudad.CiudadId);
            if (ciudadInDb == null) return;
            //lo actualizo.... por lo tanto el changetracker toma nota
            ciudadInDb.NombreCiudad = ciudad.NombreCiudad;
            ciudadInDb.ProvinciaEstadoId=ciudad.ProvinciaEstadoId;
            //confirmo y guardo los cambios
            _dbContext.SaveChanges();
        }
    }
}
