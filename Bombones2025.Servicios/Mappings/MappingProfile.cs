using AutoMapper;
using Bombones2025.Entidades.DTOs.Pais;
using Bombones2025.Entidades.Entidades;

namespace Bombones2025.Servicios.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            LoadPaisMapping();
        }

        private void LoadPaisMapping()
        {
            CreateMap<Pais, PaisListDto>();
            CreateMap<Pais, PaisEditDto>().ReverseMap();
        }
    }
}
