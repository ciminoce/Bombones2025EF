using Bombones2025.Entidades.Entidades;

namespace Bombones2025.Servicios.Interfaces
{
    public interface IProvinciaEstadoServicio
    {
        List<ProvinciaEstado> GetLista(int? paisId=null, string? textoFiltro=null);
        bool Guardar(ProvinciaEstado provinciaEstado, out List<string> errores);

    }
}
