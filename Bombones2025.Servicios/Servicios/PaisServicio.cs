using AutoMapper;
using Bombones2025.DatosSql.Interfaces;
using Bombones2025.Entidades.DTOs.Pais;
using Bombones2025.Entidades.Entidades;
using Bombones2025.Servicios.Interfaces;

namespace Bombones2025.Servicios.Servicios
{
    public class PaisServicio : IPaisServicio
    {
        private readonly IPaisRepositorio _paisRepositorio;
        private readonly IMapper _mapper;
        public PaisServicio(IPaisRepositorio paisRepositorio, IMapper mapper)
        {
            _paisRepositorio = paisRepositorio;
            _mapper = mapper;
        }

        public bool Guardar(PaisEditDto paisDto, out List<string> errores)
        {
            errores = new List<string>();
            Pais pais = _mapper.Map<Pais>(paisDto);
            if (_paisRepositorio.Existe(pais))
            {
                errores.Add("País existente!!!");
                return false;
            }
            if (pais.PaisId==0)
            {
                _paisRepositorio.Agregar(pais);
                return true;

            }
            _paisRepositorio.Editar(pais);
            return true;

        }

        public bool Borrar(int paisId, out List<string> errores)
        {
            errores = new List<string>();
            if (_paisRepositorio.EstaRelacionado(paisId))
            {
                errores.Add("País con registros relacionados");
                return false;
            }
            _paisRepositorio.Borrar(paisId);
            return true;
        }


        public bool Existe(Pais pais)
        {
            return _paisRepositorio.Existe(pais);
        }


        public List<PaisListDto> GetLista(string? textoFiltro = null)
        {
            var paises= _paisRepositorio.GetLista(textoFiltro);
            return _mapper.Map<List<PaisListDto>>(paises);
        }

        public bool EstaRelacionado(int paisId)
        {
            throw new NotImplementedException();
        }

        public PaisEditDto? GetById(int paisId)
        {
            Pais? pais= _paisRepositorio.GetPorId(paisId);
            if (pais is null) return null;
            return _mapper.Map<PaisEditDto>(pais);
        }
    }
}
