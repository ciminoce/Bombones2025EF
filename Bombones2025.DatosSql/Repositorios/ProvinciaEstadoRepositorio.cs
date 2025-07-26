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
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public void Agregar(ProvinciaEstado provinciaEstado)
        {
            
            _dbContext.ProvinciasEstados.Add(provinciaEstado);
            _dbContext.SaveChanges();
        }

        public void Borrar(int provinciaEstadoId)
        {
            var peEnDb = ObtenerPorId(provinciaEstadoId);
            if (peEnDb is not null)
            {
                _dbContext.Entry(peEnDb).State = EntityState.Deleted;
                _dbContext.SaveChanges();
            }
            //var peEnDb = _dbContext.ProvinciasEstados.Find(provinciaEstadoId);
            //if (peEnDb is not null)
            //{
            //    _dbContext.ProvinciasEstados.Remove(peEnDb);
            //    _dbContext.SaveChanges();
            //}
        }

        public void Editar(ProvinciaEstado provinciaEstado)
        {
            //TODO: Ver otra forma
            var peEnDb = ObtenerPorId(provinciaEstado.ProvinciaEstadoId);
            if(peEnDb is not null)
            {
                peEnDb.NombreProvinciaEstado = provinciaEstado.NombreProvinciaEstado;
                peEnDb.PaisId=provinciaEstado.PaisId;
                peEnDb.Pais = null;

                _dbContext.Entry(peEnDb).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
        }

        public bool EstaRelacionado(int provinciaEstadoId)
        {
            //TODO: Implementar correctamente cuando la entidad esté relacionada
            return false;
        }

        public bool Existe(ProvinciaEstado provinciaEstado)
        {
            return provinciaEstado.ProvinciaEstadoId == 0
                ? _dbContext.ProvinciasEstados.Any(pe => pe.NombreProvinciaEstado == provinciaEstado.NombreProvinciaEstado)
                : _dbContext.ProvinciasEstados.Any(pe => pe.NombreProvinciaEstado == provinciaEstado.NombreProvinciaEstado
                    && pe.ProvinciaEstadoId != provinciaEstado.ProvinciaEstadoId);
                
        }

        public ProvinciaEstado? ObtenerPorId(int provinciaEstadoId)
        {
            return _dbContext.ProvinciasEstados
                .Include(pe=>pe.Pais)
                .AsNoTracking()
                .FirstOrDefault(pe=>
                pe.ProvinciaEstadoId==provinciaEstadoId);
        }

        public List<ProvinciaEstado> ObtenerLista(int? paisId = null, string? textoFiltro=null)
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
