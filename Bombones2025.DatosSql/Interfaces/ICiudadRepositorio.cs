using Bombones2025.Entidades.Entidades;

namespace Bombones2025.DatosSql.Interfaces
{
    public interface ICiudadRepositorio
    {
        void Agregar(Ciudad ciudad);
        bool Existe(Ciudad ciudad);
        void Editar(Ciudad ciudad);
        void Borrar(int ciudadId);
        Ciudad? GetById(int ciudadId);
        //bool EstaRelacionado(int ciudadId);
        List<Ciudad> GetLista(int? paisId=null, int? provinciaId=null, string? textoFiltro=null);
    }
}
