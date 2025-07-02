using Bombones2025.Entidades.DTOs.Ciudad;
using Bombones2025.Entidades.Entidades;

namespace Bombones2025.Servicios.Interfaces
{
    public interface ICiudadServicio
    {
        bool Borrar(int ciudadId, out List<string> errores);
        bool Existe(Ciudad ciudad);
        List<CiudadListDto> GetLista();
        bool Guardar(CiudadEditDto ciudadDto, out List<string> errores);
        CiudadEditDto? GetById(int ciudadId);

    }
}
