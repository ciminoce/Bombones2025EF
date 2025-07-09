using AutoMapper;
using Bombones2025.DatosSql.Interfaces;
using Bombones2025.Entidades.DTOs.Ciudad;
using Bombones2025.Entidades.Entidades;
using Bombones2025.Servicios.Interfaces;

namespace Bombones2025.Servicios.Servicios
{
    public class CiudadServicio : ICiudadServicio
    {
        private readonly ICiudadRepositorio _ciudadRepositorio;
        private readonly IMapper _mapper;

        public CiudadServicio(ICiudadRepositorio ciudadRepositorio,
            IMapper mapper)
        {
            _ciudadRepositorio = ciudadRepositorio;
            _mapper = mapper;
        }

        public List<CiudadListDto> GetLista()
        {
            var ciudades=_ciudadRepositorio.GetLista();
            /*
             * Muestro cómo se haría para mandar la lista de dtos
             * sin utilizar Automapper, utilizando Select de linq
             * 
             * Esto me lo ahorro de hacer porque lo hace automapper
             * luego lo muestro
             */
            //return ciudades.Select(c=>new CiudadListDto
            //{
            //    CiudadId=c.CiudadId,
            //    NombreCiudad=c.NombreCiudad,
            //    NombreProvincia=c.ProvinciaEstado!.NombreProvinciaEstado,
            //    NombrePais=c.ProvinciaEstado.Pais!.NombrePais
            //}).ToList();
            /*
             * Ahora lo hacemos con Automapper
             */
            return _mapper.Map<List<CiudadListDto>>(ciudades);
        }
    }
}
