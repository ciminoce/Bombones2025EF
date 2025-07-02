using Bombones2025.DatosSql.Interfaces;
using Bombones2025.Entidades.DTOs.Ciudad;
using Bombones2025.Entidades.Entidades;
using Bombones2025.Servicios.Interfaces;

namespace Bombones2025.Servicios.Servicios
{
    public class CiudadServicio : ICiudadServicio
    {
        private readonly ICiudadRepositorio _ciudadRepositorio;

        public CiudadServicio(ICiudadRepositorio ciudadRepositorio)
        {
            _ciudadRepositorio = ciudadRepositorio;
        }

        public bool Borrar(int ciudadId, out List<string> errores)
        {
            throw new NotImplementedException();
        }

        public bool Existe(Ciudad ciudad)
        {
            throw new NotImplementedException();
        }

        public CiudadEditDto? GetById(int ciudadId)
        {
            throw new NotImplementedException();
        }

        public List<CiudadListDto> GetLista()
        {
            throw new NotImplementedException();
        }

        public bool Guardar(CiudadEditDto ciudadDto, out List<string> errores)
        {
            throw new NotImplementedException();
        }
    }
}
