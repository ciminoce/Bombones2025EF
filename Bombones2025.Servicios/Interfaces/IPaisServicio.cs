using Bombones2025.Entidades.Entidades;

namespace Bombones2025.Servicios.Interfaces
{
    public interface IPaisServicio
    {
        bool Borrar(int paisId, out List<string> errores);
        bool Existe(Pais pais);
        List<Pais> GetLista(string? textoFiltro = null);
        bool Guardar(Pais pais, out List<string> errores);
        //bool EstaRelacionado(int paisId);
    }
}