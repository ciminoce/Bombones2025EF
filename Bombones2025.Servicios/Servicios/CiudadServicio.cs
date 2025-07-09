using AutoMapper;
using Bombones2025.DatosSql.Interfaces;
using Bombones2025.Entidades.DTOs.Ciudad;
using Bombones2025.Entidades.Entidades;
using Bombones2025.Servicios.Interfaces;
using System.Globalization;

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

        public bool Borrar(int ciudadId, out List<string> errores)
        {
            errores= new List<string>();
            Ciudad? ciudad = _ciudadRepositorio.GetById(ciudadId);
            if(ciudad == null)
            {
                errores.Add("Ciudad inexistente!!!");
                return false;   

            }
            _ciudadRepositorio.Borrar(ciudadId);
            return true;
        }

        public bool Existe(Ciudad ciudad)
        {
            return _ciudadRepositorio.Existe(ciudad);
        }

        public CiudadEditDto? GetById(int ciudadId)
        {
            var ciudad= _ciudadRepositorio.GetById(ciudadId);
            return _mapper.Map<CiudadEditDto>(ciudad);
        }

        public List<CiudadListDto> GetLista(int? provinciaId=null, string? textoFiltro=null)
        {
            var ciudades = _ciudadRepositorio.GetLista(provinciaId,textoFiltro);
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

        public bool Guardar(CiudadEditDto ciudadDto, out List<string> errores)
        {
            errores= new List<string>();
            Ciudad ciudad=_mapper.Map<Ciudad>(ciudadDto);
            if (_ciudadRepositorio.Existe(ciudad))
            {
                errores.Add("Ciudad Existente!!!");
                return false;
            }
            if (ciudad.CiudadId == 0)
            {
                _ciudadRepositorio.Agregar(ciudad);
                ciudadDto.CiudadId=ciudad.CiudadId;//guardo el Id generado en el dto
                return true;
            }
            _ciudadRepositorio.Editar(ciudad);
            return true;
        }
    }
}
