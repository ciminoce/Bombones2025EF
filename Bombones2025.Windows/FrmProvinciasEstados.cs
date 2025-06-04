using Bombones2025.Entidades.Entidades;
using Bombones2025.Servicios.Interfaces;
using Bombones2025.Windows.Helpers;

namespace Bombones2025.Windows
{
    public partial class FrmProvinciasEstados : Form
    {
        private readonly IProvinciaEstadoServicio _provinciaServicio;

        private List<ProvinciaEstado>? provincias;
        public FrmProvinciasEstados(IProvinciaEstadoServicio provinciaServicio)
        {
            InitializeComponent();
            _provinciaServicio = provinciaServicio;
        }

        private void TsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmProvinciasEstados_Load(object sender, EventArgs e)
        {
            try
            {
                provincias = _provinciaServicio.GetLista();
                MostrarDatosEnGrilla();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void MostrarDatosEnGrilla()
        {
            dgvDatos.Rows.Clear();
            foreach (var p in provincias!)
            {
                DataGridViewRow r = GridHelper.ConstruirFila(dgvDatos);

                GridHelper.SetearFila(r, p);
                GridHelper.AgregarFila(r, dgvDatos);
            }
        }
    }
}
