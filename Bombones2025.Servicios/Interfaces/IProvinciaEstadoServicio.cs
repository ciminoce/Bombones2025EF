using Bombones2025.Entidades.DTOs.ProvinciaEstado;
using Bombones2025.Entidades.Entidades;

namespace Bombones2025.Servicios.Interfaces
{
    public interface IProvinciaEstadoServicio
    {
        bool Borrar(int provinciaEstadoId, out List<string> errores);
        ProvinciaEstado? GetById(int provinciaEstadoId);
        List<ProvinciaEstadoListDto> GetLista(int? paisId=null, string? textoFiltro=null);
        bool Guardar(ProvinciaEstado provinciaEstado, out List<string> errores);

    }
}
