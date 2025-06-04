using Bombones2025.DatosSql.Interfaces;
using Bombones2025.Entidades.Entidades;

namespace Bombones2025.DatosSql.Repositorios
{
    public class ProvinciaEstadoRepositorio : IProvinciaEstadoRepositorio
    {
        private readonly BombonesDbContext _dbContext;

        public ProvinciaEstadoRepositorio(BombonesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<ProvinciaEstado> GetLista()
        {
            return _dbContext.ProvinciasEstados.ToList();
        }
    }
}
