using Bombones2025.Entidades.DTOs.Pais;
using Bombones2025.Entidades.Entidades;
using Bombones2025.Servicios.Interfaces;
using Bombones2025.Windows.Helpers;
using Bombones2025.Windows.Properties;

namespace Bombones2025.Windows
{
    public partial class FrmPaises : Form
    {
        private readonly IPaisServicio _paisServicio;

        private List<PaisListDto> _paises = new();

        private bool filterOn = false;
        public FrmPaises(IPaisServicio paisServicio)
        {
            InitializeComponent();
            _paisServicio = paisServicio;
        }

        private void FrmPaises_Load(object sender, EventArgs e)
        {
            try
            {
                _paises = _paisServicio.GetLista();
                MostrarDatosEnGrilla();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void MostrarDatosEnGrilla()
        {
            GridHelper.LimpiarGrilla(dgvDatos);
            foreach (PaisListDto pais in _paises)
            {
                DataGridViewRow r = GridHelper.ConstruirFila(dgvDatos);
                GridHelper.SetearFila(r, pais);
                GridHelper.AgregarFila(r, dgvDatos);
            }
        }

        private void TsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TsbNuevo_Click(object sender, EventArgs e)
        {
            FrmPaisesAE frm = new FrmPaisesAE() { Text = "Nuevo País" };
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) return;
            PaisEditDto? paisEditDto = frm.GetPais();
            if (paisEditDto == null) return;
            try
            {
                if (_paisServicio.Guardar(paisEditDto, out var errores))
                {
                    DataGridViewRow r = GridHelper.ConstruirFila(dgvDatos);
                    GridHelper.SetearFila(r, paisEditDto);
                    GridHelper.AgregarFila(r, dgvDatos);
                    MessageBox.Show("Pais agregado", "Mensaje",
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

        private void TsbBorrar_Click(object sender, EventArgs e)
        {
            //TODO:OJO Ver esto JODER
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];
            Pais paisBorrar = (Pais)r.Tag!;
            DialogResult dr = MessageBox.Show($"¿Desea borrar el pais {paisBorrar}?",
                "Confirmar Eliminación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No) return;
            try
            {
                if(_paisServicio.Borrar(paisBorrar.PaisId, out var errores))
                {
                    GridHelper.QuitarFila(r, dgvDatos);
                    MessageBox.Show("País eliminado");

                }
                else
                {
                    MessageBox.Show(errores.First(), "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void TsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];
            PaisEditDto? paisEditDto = (PaisEditDto)r.Tag!;
            if (paisEditDto == null) return;
            //Pais? paisEditar = paisEditDto.Clonar();
            FrmPaisesAE frm = new FrmPaisesAE() { Text = "Editar País" };
            frm.SetPais(paisEditDto);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) return;
            paisEditDto = frm.GetPais();
            if (paisEditDto == null) return;
            try
            {
                if (_paisServicio.Guardar(paisEditDto, out var errores))
                {
                    GridHelper.SetearFila(r, paisEditDto);

                    MessageBox.Show("Pais editado", "Mensaje",
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

        private void TsbFiltrar_Click(object sender, EventArgs e)
        {
            if (!filterOn)
            {
                FrmFiltro frm = new FrmFiltro() { Text = "Filtrar Paises" };
                DialogResult dr = frm.ShowDialog(this);
                string? textoParaFiltrar = frm.GetTexto();
                if (textoParaFiltrar is null) return;
                try
                {
                    _paises = _paisServicio.GetLista(textoParaFiltrar);
                    MostrarDatosEnGrilla();
                    TsbFiltrar.Image = Resources.filter_intense_40px;
                    filterOn = true;
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                _paises = _paisServicio.GetLista();
                MostrarDatosEnGrilla();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
