using Bombones2025.DatosSql.Interfaces;
using Bombones2025.Entidades.Entidades;

namespace Bombones2025.DatosSql.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly BombonesDbContext _dbContext;

        public UsuarioRepositorio(BombonesDbContext  dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }


        public Usuario? Login(string userName)
        {
            Usuario? usuario = _dbContext.Usuarios.FirstOrDefault(u => u.Nombre == userName);

            return usuario;
        }
    }
}
