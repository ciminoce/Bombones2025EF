using Bombones2025.DatosSql.Interfaces;
using Bombones2025.Entidades.Entidades;

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
            throw new NotImplementedException();
        }

        public void Borrar(int ciudadId)
        {
            throw new NotImplementedException();
        }

        public void Editar(Ciudad ciudad)
        {
            throw new NotImplementedException();
        }

        public bool EstaRelacionado(int ciudadId)
        {
            throw new NotImplementedException();
        }

        public Ciudad GetById(int ciudadId)
        {
            throw new NotImplementedException();
        }

        public List<Ciudad> GetLista()
        {
            throw new NotImplementedException();
        }
    }
}
