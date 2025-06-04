using Bombones2025.DatosSql.Interfaces;
using Bombones2025.Entidades.Entidades;
using Bombones2025.Servicios.Interfaces;

namespace Bombones2025.Servicios.Servicios
{
    public class ProvinciaEstadoServicio : IProvinciaEstadoServicio
    {
        private readonly IProvinciaEstadoRepositorio _provinciaRepositorio;

        public ProvinciaEstadoServicio(IProvinciaEstadoRepositorio provinciaRepositorio)
        {
            _provinciaRepositorio = provinciaRepositorio;
        }

        public List<ProvinciaEstado> GetLista(int? paisId = null, string? textoFiltro = null)
        {
            return _provinciaRepositorio.GetLista(paisId,textoFiltro);
        }
    }
}
