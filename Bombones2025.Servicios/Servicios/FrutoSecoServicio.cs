using AutoMapper;
using Bombones2025.DatosSql.Interfaces;
using Bombones2025.Entidades.DTOs.FrutoSeco;
using Bombones2025.Entidades.Entidades;
using Bombones2025.Servicios.Interfaces;

namespace Bombones2025.Servicios.Servicios
{
    public class FrutoSecoServicio : IFrutoSecoServicio
    {
        private readonly IFrutoSecoRepositorio _frutoRepositorio;
        private readonly IMapper _mapper;
        public FrutoSecoServicio(IFrutoSecoRepositorio frutoRepositorio, IMapper mapper)
        {
            _frutoRepositorio = frutoRepositorio;
            _mapper = mapper;
        }

        public bool Existe(FrutoSeco fruto)
        {
            return _frutoRepositorio.Existe(fruto);
        }

        public List<FrutoSecoListDto> ObtenerLista(string? textoFiltro = null)
        {
            var frutos= _frutoRepositorio.ObtenerLista(textoFiltro);
            return _mapper.Map<List<FrutoSecoListDto>>(frutos);
        }

        public bool Guardar(FrutoSecoEditDto frutoDto, out List<string> errores)
        {
            errores = new List<string>();
            var fruto = _mapper.Map<FrutoSeco>(frutoDto);
            if (_frutoRepositorio.Existe(fruto))
            {
                errores.Add("Fruto existente!!!");
                return false;
            }
            if (fruto.FrutoSecoId==0)
            {
                _frutoRepositorio.Agregar(fruto);
                frutoDto.FrutoSecoId = fruto.FrutoSecoId;
                return true;

            }
            _frutoRepositorio.Editar(fruto);
            return true;

        }


        public bool Borrar(int frutoId, out List<string> errores)
        {
            errores = new List<string>();
            _frutoRepositorio.Borrar(frutoId);
            return true;
        }
    }
}
