using AutoMapper;
using Bombones2025.Entidades.DTOs.Chocolate;
using Bombones2025.Entidades.DTOs.FrutoSeco;
using Bombones2025.Entidades.DTOs.Pais;
using Bombones2025.Entidades.DTOs.ProvinciaEstado;
using Bombones2025.Entidades.DTOs.Relleno;
using Bombones2025.Entidades.Entidades;

namespace Bombones2025.Windows.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            LoadPaisMapping();
            LoadProvinciaEstadoMapping();
            LoadFrutoSecoMapping();
            LoadChocolateMapping();
            LoadRellenoMapping();

        }

        private void LoadRellenoMapping()
        {
            CreateMap<Relleno, RellenoListDto>();
            CreateMap<Relleno, RellenoEditDto>().ReverseMap();
            CreateMap<RellenoEditDto, RellenoListDto>().ReverseMap();
        }

        private void LoadChocolateMapping()
        {
            CreateMap<Chocolate, ChocolateListDto>();
            CreateMap<Chocolate, ChocolateEditDto>().ReverseMap();
            CreateMap<ChocolateEditDto, ChocolateListDto>().ReverseMap();
        }

        private void LoadFrutoSecoMapping()
        {
            CreateMap<FrutoSeco, FrutoSecoListDto>();
            CreateMap<FrutoSeco, FrutoSecoEditDto>().ReverseMap();
            CreateMap<FrutoSecoEditDto, FrutoSecoListDto>().ReverseMap();
        }

        private void LoadProvinciaEstadoMapping()
        {
            CreateMap<ProvinciaEstado, ProvinciaEstadoListDto>()
                .ForMember(p => p.NombrePais, opt => opt.MapFrom(src => src.Pais!.NombrePais));
            CreateMap<ProvinciaEstado, ProvinciaEstadoEditDto>().ReverseMap();
            CreateMap<ProvinciaEstadoEditDto, ProvinciaEstadoListDto>();
        }

        private void LoadPaisMapping()
        {
            CreateMap<Pais, PaisListDto>();
            CreateMap<Pais, PaisEditDto>().ReverseMap();
            CreateMap<PaisEditDto, PaisListDto>().ReverseMap();
        }
    }
}
