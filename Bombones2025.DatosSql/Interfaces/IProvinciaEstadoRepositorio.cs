using Bombones2025.Entidades.Entidades;

namespace Bombones2025.DatosSql.Interfaces
{
    public interface IProvinciaEstadoRepositorio
    {
        List<ProvinciaEstado> GetLista(int? paisId=null, string? textoFiltro = null);
        void Agregar(ProvinciaEstado provinciaEstado);
        void Editar(ProvinciaEstado provinciaEstado);
        ProvinciaEstado? GetById(int provinciaEstadoId);
        bool Existe(ProvinciaEstado provinciaEstado);
        bool EstaRelacionado(int provinciaEstadoId);
        void Borrar(int provinciaEstadoId);
    }
}
