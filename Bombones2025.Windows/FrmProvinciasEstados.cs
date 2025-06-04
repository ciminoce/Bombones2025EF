using Bombones2025.Entidades.Entidades;
using Bombones2025.Servicios.Interfaces;
using Bombones2025.Windows.Helpers;
using Bombones2025.Windows.Properties;

namespace Bombones2025.Windows
{
    public partial class FrmProvinciasEstados : Form
    {
        private readonly IProvinciaEstadoServicio _provinciaServicio;
        private readonly IPaisServicio _paisServicio;
        private bool filterOn = false;

        private List<ProvinciaEstado>? provincias;
        public FrmProvinciasEstados(IProvinciaEstadoServicio provinciaServicio, IPaisServicio paisServicio)
        {
            InitializeComponent();
            _provinciaServicio = provinciaServicio;
            _paisServicio = paisServicio;
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

        private void paísToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!filterOn)
            {
                FrmFiltroPorPais frm = new FrmFiltroPorPais(_paisServicio);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.Cancel) return;
                Pais? paisFiltro = frm.GetPais();
                if (paisFiltro is null) return;
                try
                {
                    provincias = _provinciaServicio.GetLista(paisFiltro.PaisId);
                    MostrarDatosEnGrilla();
                    TsbFiltrar.Image = Resources.filter_intense_40px;
                    filterOn = true;
                }
                catch (Exception)
                {

                    throw;
                }

            }
            else
            {
                MessageBox.Show("Quitar el filtro!!!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void TsbActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                filterOn = false;
                TsbFiltrar.Image = Resources.filter_40px;
                provincias = _provinciaServicio.GetLista();
                MostrarDatosEnGrilla();

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void textoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!filterOn)
            {
                FrmFiltro frm = new FrmFiltro() { Text = "Texto para filtrar Provincia/Estado" };
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.Cancel) return;
                string? textoFiltro = frm.GetTexto();
                if (textoFiltro is null) return;
                try
                {
                    provincias = _provinciaServicio.GetLista(null, textoFiltro);
                    MostrarDatosEnGrilla();
                    TsbFiltrar.Image = Resources.filter_intense_40px;
                    filterOn = true;

                }
                catch (Exception)
                {

                    throw;
                }

            }
            else
            {
                MessageBox.Show("Quitar el filtro!!!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TsbNuevo_Click(object sender, EventArgs e)
        {
            FrmProvinciaEstadoAE frm = new FrmProvinciaEstadoAE(_paisServicio) { Text = "Agregar Fruto Seco" };
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) return;
            ProvinciaEstado? provEstado = frm.GetProvincia();
            if (provEstado is null) return;
            try
            {
                if (_provinciaServicio.Guardar(provEstado, out var errores))
                {
                    DataGridViewRow r = GridHelper.ConstruirFila(dgvDatos);
                    GridHelper.SetearFila(r, provEstado);
                    GridHelper.AgregarFila(r, dgvDatos);
                    MessageBox.Show("Registro Agregado", "Información",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

                else
                {
                    MessageBox.Show(errores.First(), "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
