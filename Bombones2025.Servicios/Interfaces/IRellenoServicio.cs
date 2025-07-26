using Bombones2025.Entidades.DTOs.Relleno;
using Bombones2025.Entidades.Entidades;

namespace Bombones2025.Servicios.Interfaces
{
    public interface IRellenoServicio
    {
        bool Borrar(int rellenoId, out List<string> errores);
        bool Existe(Relleno relleno);
        List<RellenoListDto> ObtenerLista(string? textoFiltro = null);
        bool Guardar(RellenoEditDto rellenoDto, out List<string> errores);
    }
}