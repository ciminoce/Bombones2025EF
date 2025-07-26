using AutoMapper;
using Bombones2025.DatosSql.Interfaces;
using Bombones2025.Entidades.DTOs.Relleno;
using Bombones2025.Entidades.Entidades;
using Bombones2025.Servicios.Interfaces;

namespace Bombones2025.Servicios.Servicios
{
    public class RellenoServicio : IRellenoServicio
    {
        private readonly IRellenoRepositorio _rellenoRepositorio;
        private readonly IMapper _mapper;
        public RellenoServicio(IRellenoRepositorio rellenoRepositorio, IMapper mapper)
        {
            _rellenoRepositorio = rellenoRepositorio;
            _mapper = mapper;
        }

        public bool Existe(Relleno relleno)
        {
            return _rellenoRepositorio.Existe(relleno);
        }

        public List<RellenoListDto> ObtenerLista(string? textoFiltro=null)
        {
            var rellenos= _rellenoRepositorio.ObtenerLista(textoFiltro);
            return _mapper.Map<List<RellenoListDto>>(rellenos);
        }


        public bool Borrar(int rellenoId, out List<string> errores)
        {
            errores = new List<string>();
            _rellenoRepositorio.Borrar(rellenoId);
            return true;
        }

        public bool Guardar(RellenoEditDto rellenoDto, out List<string> errores)
        {
            errores = new List<string>();
            Relleno relleno = _mapper.Map<Relleno>(rellenoDto);
            if (_rellenoRepositorio.Existe(relleno))
            {
                errores.Add("País existente!!!");
                return false;
            }
            if (relleno.RellenoId==0)
            {
                _rellenoRepositorio.Agregar(relleno);
                rellenoDto.RellenoId=relleno.RellenoId;
                return true;

            }
            _rellenoRepositorio.Editar(relleno);
            return true;

        }

    }
}
