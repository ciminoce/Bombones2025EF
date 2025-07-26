using Bombones2025.Entidades.DTOs.Pais;
using Bombones2025.Entidades.Entidades;

namespace Bombones2025.Servicios.Interfaces
{
    public interface IPaisServicio
    {
        bool Borrar(int paisId, out List<string> errores);
        bool Existe(Pais pais);
        List<PaisListDto> ObtenerLista(string? textoFiltro = null);
        bool Guardar(PaisEditDto paisDto, out List<string> errores);
        PaisEditDto? ObtenerPorId(int paisId);
        //bool EstaRelacionado(int paisId);
    }
}