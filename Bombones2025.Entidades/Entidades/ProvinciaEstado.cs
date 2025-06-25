
namespace Bombones2025.Entidades.Entidades
{
    public class ProvinciaEstado
    {
        public int ProvinciaEstadoId { get; set; }
        public string NombreProvinciaEstado { get; set; } = null!;
        public int PaisId { get; set; }
        public Pais? Pais { get; set; }//Navegacion

        public ProvinciaEstado? Clonar()
        {
            return new ProvinciaEstado
            {
                ProvinciaEstadoId = ProvinciaEstadoId,
                NombreProvinciaEstado = NombreProvinciaEstado,
                PaisId = PaisId
            };
        }

        public override string ToString()
        {
            return $"{NombreProvinciaEstado}";
        }
    }
}
