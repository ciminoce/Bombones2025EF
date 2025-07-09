using Bombones2025.Entidades.DTOs.Chocolate;
using Bombones2025.Entidades.DTOs.Ciudad;
using Bombones2025.Entidades.DTOs.FrutoSeco;
using Bombones2025.Entidades.DTOs.Pais;
using Bombones2025.Entidades.DTOs.ProvinciaEstado;
using Bombones2025.Entidades.DTOs.Relleno;
using Bombones2025.Entidades.Entidades;

namespace Bombones2025.Windows.Helpers
{
    public static class GridHelper
    {
        /// <summary>
        /// Método estático para limpiar una grilla
        /// </summary>
        /// <param name="grid">Grilla que se desea limpiar</param>
        public static void LimpiarGrilla(DataGridView grid)
        {
            grid.Rows.Clear();
        }
        /// <summary>
        /// Método estático para construir una nueva fila
        /// de la grilla que me pasan
        /// </summary>
        /// <param name="grid">Grilla a la cual le creo la fila</param>
        /// <returns>Fila de la grilla resultante</returns>
        public static DataGridViewRow ConstruirFila(DataGridView grid)
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(grid);
            return r;
        }
        /// <summary>
        /// Método estático para setear la fila de la grilla
        /// con el contenido del objeto que me pasan
        /// </summary>
        /// <param name="r">Fila a popular</param>
        /// <param name="chocolate">objeto que se muestra</param>
        public static void SetearFila(DataGridViewRow r, object obj)
        {
            switch (obj)
            {
                case ChocolateListDto chocolateDto:
                    r.Cells[0].Value = chocolateDto.ChocolateId;
                    r.Cells[1].Value = chocolateDto.Descripcion;
                    break;
                case PaisListDto paisDto:
                    r.Cells[0].Value=paisDto.PaisId;
                    r.Cells[1].Value = paisDto.NombrePais;
                    break;
                case RellenoListDto rellenoDto:
                    r.Cells[0].Value = rellenoDto.RellenoId;
                    r.Cells[1].Value = rellenoDto.Descripcion;
                    break;
                case FrutoSecoListDto frutoDto:
                    r.Cells[0].Value = frutoDto.FrutoSecoId;
                    r.Cells[1].Value = frutoDto.Descripcion;
                    break;
                case ProvinciaEstadoListDto provinciaDto:
                    r.Cells[0].Value = provinciaDto.ProvinciaEstadoId;
                    r.Cells[1].Value = provinciaDto.NombreProvinciaEstado;
                    r.Cells[2].Value = provinciaDto.NombrePais;
                    break;
                case CiudadListDto ciudadDto:
                    r.Cells[0].Value = ciudadDto.CiudadId;
                    r.Cells[1].Value = ciudadDto.NombreCiudad;
                    r.Cells[2].Value = ciudadDto.NombreProvincia;
                    r.Cells[3].Value = ciudadDto.NombrePais;
                    break;

            }

            r.Tag = obj;
        }
        /// <summary>
        /// Método estático para agregar una fila a una grilla
        /// </summary>
        /// <param name="r">Fila a agregar</param>
        /// <param name="grid">Grilla en la cual se agrega la fila</param>
        public static void AgregarFila(DataGridViewRow r, DataGridView grid)
        {
            grid.Rows.Add(r);
        }
        /// <summary>
        /// Método estático para eliminar una fila a una grilla
        /// </summary>
        /// <param name="r">Fila a eliminar</param>
        /// <param name="grid">Grilla en la cual se desea quitar la fila</param>
        public static void QuitarFila(DataGridViewRow r, DataGridView grid)
        {
            grid.Rows.Remove(r);
        }
    }
}
