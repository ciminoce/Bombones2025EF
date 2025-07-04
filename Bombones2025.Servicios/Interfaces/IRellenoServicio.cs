﻿using Bombones2025.Entidades.Entidades;

namespace Bombones2025.Servicios.Interfaces
{
    public interface IRellenoServicio
    {
        bool Borrar(int rellenoId, out List<string> errores);
        bool Existe(Relleno relleno);
        List<Relleno> GetLista(string? textoFiltro = null);
        bool Guardar(Relleno relleno, out List<string> errores);
    }
}