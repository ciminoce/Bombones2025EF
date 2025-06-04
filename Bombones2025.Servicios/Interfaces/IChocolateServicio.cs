using Bombones2025.Entidades.Entidades;

namespace Bombones2025.Servicios.Interfaces
{
    public interface IChocolateServicio
    {
        bool Borrar(int chocolateId, out List<string> errores);
        bool Existe(Chocolate chocolate);
        List<Chocolate> GetLista(string? textoFiltro=null);
        bool Guardar(Chocolate chocolate, out List<string> errores);
    }
}