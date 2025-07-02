namespace Bombones2025.Entidades.Entidades
{
    public class Ciudad
    {
        public int CiudadId { get; set; }
        public string NombreCiudad { get; set; } = null!;
        public int ProvinciaEstadoId { get; set; }
        public ProvinciaEstado? ProvinciaEstado { get; set; }
    }
}
