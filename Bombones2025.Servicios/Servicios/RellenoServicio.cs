﻿using Bombones2025.DatosSql.Interfaces;
using Bombones2025.Entidades.Entidades;
using Bombones2025.Servicios.Interfaces;

namespace Bombones2025.Servicios.Servicios
{
    public class RellenoServicio : IRellenoServicio
    {
        private readonly IRellenoRepositorio? _rellenoRepositorio;
        public RellenoServicio(IRellenoRepositorio? rellenoRepositorio)
        {
            _rellenoRepositorio = rellenoRepositorio;
        }

        public bool Existe(Relleno relleno)
        {
            return _rellenoRepositorio.Existe(relleno);
        }

        public List<Relleno> GetLista(string? textoFiltro=null)
        {
            return _rellenoRepositorio.GetLista(textoFiltro);
        }


        public bool Borrar(int rellenoId, out List<string> errores)
        {
            errores = new List<string>();
            _rellenoRepositorio.Borrar(rellenoId);
            return true;
        }

        public bool Agregar(Relleno relleno, out List<string> errores)
        {
            errores = new List<string>();
            if (_rellenoRepositorio.Existe(relleno))
            {
                errores.Add("País existente!!!");
                return false;
            }
            _rellenoRepositorio.Agregar(relleno);
            return true;
        }

        public bool Editar(Relleno relleno, out List<string> errores)
        {
            errores = new List<string>();
            if (_rellenoRepositorio.Existe(relleno))
            {
                errores.Add("Relleno existente!!! " + Environment.NewLine + "Edición denegada");
                return false;
            }
            _rellenoRepositorio.Editar(relleno);
            return true;
        }
    }
}
