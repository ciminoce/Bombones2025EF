﻿using Bombones2025.Entidades.DTOs.ProvinciaEstado;

namespace Bombones2025.Servicios.Interfaces
{
    public interface IProvinciaEstadoServicio
    {
        bool Borrar(int provinciaEstadoId, out List<string> errores);
        ProvinciaEstadoEditDto? ObtenerPorId(int provinciaEstadoId);
        List<ProvinciaEstadoListDto> ObtenerLista(int? paisId = null, string? textoFiltro = null);
        bool Guardar(ProvinciaEstadoEditDto provinciaEstadoDto, out List<string> errores);

    }
}
