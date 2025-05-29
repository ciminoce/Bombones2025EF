﻿using Bombones2025.DatosSql.Interfaces;
using Bombones2025.Entidades.Entidades;
using Bombones2025.Servicios.Interfaces;

namespace Bombones2025.Servicios.Servicios
{
    public class FrutoSecoServicio : IFrutoSecoServicio
    {
        private readonly IFrutoSecoRepositorio? _frutoRepositorio;
        public FrutoSecoServicio(IFrutoSecoRepositorio? frutoRepositorio)
        {
            _frutoRepositorio = frutoRepositorio;
        }

        public bool Existe(FrutoSeco fruto)
        {
            return _frutoRepositorio.Existe(fruto);
        }

        public List<FrutoSeco> GetLista(string? textoFiltro = null)
        {
            return _frutoRepositorio.GetLista(textoFiltro);
        }

        public bool Agregar(FrutoSeco fruto, out List<string> errores)
        {
            errores = new List<string>();
            if (_frutoRepositorio.Existe(fruto))
            {
                errores.Add("Fruto existente!!!");
                return false;
            }
            _frutoRepositorio.Agregar(fruto);
            return true;
        }

        public bool Editar(FrutoSeco fruto, out List<string> errores)
        {
            errores = new List<string>();
            if (_frutoRepositorio.Existe(fruto))
            {
                errores.Add("Fruto existente!!! " + Environment.NewLine + "Edición denegada");
                return false;
            }
            _frutoRepositorio.Editar(fruto);
            return true;
        }

        public bool Borrar(int frutoId, out List<string> errores)
        {
            errores = new List<string>();
            _frutoRepositorio.Borrar(frutoId);
            return true;
        }
    }
}
