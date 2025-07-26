using Bombones2025.Entidades.DTOs.FrutoSeco;
using Bombones2025.Entidades.Entidades;

namespace Bombones2025.Servicios.Interfaces
{
    public interface IFrutoSecoServicio
    {
        bool Borrar(int frutoId, out List<string> errores);
        bool Existe(FrutoSeco fruto);
        List<FrutoSecoListDto> ObtenerLista(string? textoFiltro = null);
        bool Guardar(FrutoSecoEditDto frutoDto, out List<string> errores);
    }
}