using AutoMapper;
using Bombones2025.Entidades.DTOs.Pais;
using Bombones2025.Entidades.DTOs.ProvinciaEstado;
using Bombones2025.Entidades.Entidades;

namespace Bombones2025.Windows.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            LoadPaisMapping();
            LoadProvinciaEstadoMapping();
        }

        private void LoadProvinciaEstadoMapping()
        {
            CreateMap<ProvinciaEstado, ProvinciaEstadoListDto>()
                .ForMember(p => p.NombrePais, opt => opt.MapFrom(src => src.Pais!.NombrePais));
        }

        private void LoadPaisMapping()
        {
            CreateMap<Pais, PaisListDto>();
            CreateMap<Pais, PaisEditDto>().ReverseMap();
            CreateMap<PaisEditDto, PaisListDto>();
        }
    }
}
