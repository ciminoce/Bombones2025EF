using Bombones2025.Entidades.Entidades;

namespace Bombones2025.DatosSql.Interfaces
{
    public interface IProvinciaEstadoRepositorio
    {
        List<ProvinciaEstado> GetLista(int? paisId=null, string? textoFiltro = null);
        void Agregar(ProvinciaEstado provinciaEstado);
    }
}
