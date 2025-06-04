using Bombones2025.DatosSql.Interfaces;
using Bombones2025.Entidades.Entidades;
using Bombones2025.Servicios.Interfaces;

namespace Bombones2025.Servicios.Servicios
{
    public class PaisServicio : IPaisServicio
    {
        private readonly IPaisRepositorio? _paisRepositorio;
        public PaisServicio(IPaisRepositorio? paisRepositorio)
        {
            _paisRepositorio = paisRepositorio;
        }

        public bool Guardar(Pais pais, out List<string> errores)
        {
            errores = new List<string>();
            if (_paisRepositorio.Existe(pais))
            {
                errores.Add("País existente!!!");
                return false;
            }
            if (pais.PaisId==0)
            {
                _paisRepositorio.Agregar(pais);
                return true;

            }
            _paisRepositorio.Editar(pais);
            return true;

        }

        public bool Borrar(int paisId, out List<string> errores)
        {
            errores = new List<string>();
            if (_paisRepositorio.EstaRelacionado(paisId))
            {
                errores.Add("País con registros relacionados");
                return false;
            }
            _paisRepositorio.Borrar(paisId);
            return true;
        }


        public bool Existe(Pais pais)
        {
            return _paisRepositorio.Existe(pais);
        }


        public List<Pais> GetLista(string? textoFiltro = null)
        {
            return _paisRepositorio.GetLista(textoFiltro);
        }

        public bool EstaRelacionado(int paisId)
        {
            throw new NotImplementedException();
        }
    }
}
