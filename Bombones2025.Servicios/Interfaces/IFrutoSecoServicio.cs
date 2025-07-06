using Bombones2025.Entidades.DTOs.Pais;
using Bombones2025.Entidades.Entidades;

namespace Bombones2025.Servicios.Interfaces
{
    public interface IFrutoSecoServicio
    {
        bool Borrar(int frutoId, out List<string> errores);
        bool Existe(FrutoSeco fruto);
        List<FrutoSecoListDto> GetLista(string? textoFiltro = null);
        bool Guardar(FrutoSecoEditDto frutoDto, out List<string> errores);
    }
}