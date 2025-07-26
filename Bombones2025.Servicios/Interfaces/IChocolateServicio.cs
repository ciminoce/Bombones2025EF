using Bombones2025.Entidades.DTOs.Chocolate;
using Bombones2025.Entidades.Entidades;

namespace Bombones2025.Servicios.Interfaces
{
    public interface IChocolateServicio
    {
        bool Borrar(int chocolateId, out List<string> errores);
        bool Existe(Chocolate chocolate);
        List<ChocolateListDto> ObtenerLista(string? textoFiltro=null);
        bool Guardar(ChocolateEditDto chocolate, out List<string> errores);
    }
}