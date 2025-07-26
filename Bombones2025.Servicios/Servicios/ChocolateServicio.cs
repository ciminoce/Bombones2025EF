using AutoMapper;
using Bombones2025.DatosSql.Interfaces;
using Bombones2025.Entidades.DTOs.Chocolate;
using Bombones2025.Entidades.Entidades;
using Bombones2025.Servicios.Interfaces;

namespace Bombones2025.Servicios.Servicios
{
    public class ChocolateServicio : IChocolateServicio
    {
        private readonly IChocolateRepositorio? _chocolateRepositorio;
        private readonly IMapper _mapper;
        public ChocolateServicio(IChocolateRepositorio? chocolateRepositorio, IMapper mapper)
        {
            if (chocolateRepositorio == null)
            {
                throw new InvalidOperationException("El repositorio de chocolates no ha sido inicializado.");
            }
            _chocolateRepositorio = chocolateRepositorio;
            _mapper = mapper;
        }

        public bool Existe(Chocolate chocolate)
        {
            return _chocolateRepositorio!.Existe(chocolate);
        }

        public List<ChocolateListDto> ObtenerLista(string? textoFiltro = null)
        {
            var chocolates = _chocolateRepositorio!.ObtenerLista(textoFiltro);
            return _mapper.Map<List<ChocolateListDto>>(chocolates);
        }

        public bool Borrar(int chocolateId, out List<string> errores)
        {
            errores = new List<string>();
            _chocolateRepositorio!.Borrar(chocolateId);
            return true;
        }

        public bool Guardar(ChocolateEditDto chocolateDto, out List<string> errores)
        {
            errores = new List<string>();
            Chocolate chocolate = _mapper.Map<Chocolate>(chocolateDto);
            if (_chocolateRepositorio!.Existe(chocolate))
            {
                errores.Add("Chocolate existente!!!");
                return false;
            }
            if (chocolate.ChocolateId == 0)
            {
                _chocolateRepositorio.Agregar(chocolate);
                chocolateDto.ChocolateId = chocolate.ChocolateId;
                return true;

            }
            _chocolateRepositorio.Editar(chocolate);
            return true;
        }

    }
}
