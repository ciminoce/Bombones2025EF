using AutoMapper;
using Bombones2025.DatosSql.Interfaces;
using Bombones2025.Entidades.DTOs.ProvinciaEstado;
using Bombones2025.Entidades.Entidades;
using Bombones2025.Servicios.Interfaces;

namespace Bombones2025.Servicios.Servicios
{
    public class ProvinciaEstadoServicio : IProvinciaEstadoServicio
    {
        private readonly IProvinciaEstadoRepositorio _provinciaRepositorio;
        private readonly IMapper _mapper;

        public ProvinciaEstadoServicio(IProvinciaEstadoRepositorio provinciaRepositorio, IMapper mapper)
        {
            _provinciaRepositorio = provinciaRepositorio;
            _mapper = mapper;
        }

        public bool Borrar(int provinciaEstadoId, out List<string> errores)
        {
            errores=new List<string>();
            if (_provinciaRepositorio.EstaRelacionado(provinciaEstadoId))
            {
                errores.Add("Registro relacionado... Baja denegada");
                return false;
            }
            _provinciaRepositorio.Borrar(provinciaEstadoId);
            return true;
        }

        public ProvinciaEstadoEditDto? ObtenerPorId(int provinciaEstadoId)
        {
            var pe= _provinciaRepositorio.ObtenerPorId(provinciaEstadoId);
            return _mapper.Map<ProvinciaEstadoEditDto>(pe);
        }

        public List<ProvinciaEstadoListDto> ObtenerLista(int? paisId = null, string? textoFiltro = null)
        {
            var provincias= _provinciaRepositorio.ObtenerLista(paisId,textoFiltro);
            return _mapper.Map<List<ProvinciaEstadoListDto>>(provincias);
        }

        public bool Guardar(ProvinciaEstadoEditDto provinciaEstadoDto, out List<string> errores)
        {
            errores = new List<string>();
            ProvinciaEstado provinciaEstado = _mapper.Map<ProvinciaEstado>(provinciaEstadoDto);
            if (_provinciaRepositorio.Existe(provinciaEstado))
            {
                errores.Add("Provincia/Estado existente!!!");
                return false;
            }
            if (provinciaEstado.ProvinciaEstadoId == 0)
            {
                _provinciaRepositorio.Agregar(provinciaEstado);
                provinciaEstadoDto.ProvinciaEstadoId=provinciaEstado.ProvinciaEstadoId;
                return true;

            }
            _provinciaRepositorio.Editar(provinciaEstado) ;
            return true;

        }
    }
}
