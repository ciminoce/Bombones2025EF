using AutoMapper;
using Bombones2025.Entidades.DTOs.Relleno;
using Bombones2025.Entidades.Entidades;
using Bombones2025.Servicios.Interfaces;
using Bombones2025.Windows.Helpers;

namespace Bombones2025.Windows
{
    public partial class FrmRellenos : Form
    {
        private readonly IRellenoServicio _servicio = null!;
        private readonly IMapper _mapper;
        private List<RellenoListDto> lista = null!;
        public FrmRellenos(IRellenoServicio servicio, IMapper mapper)
        {
            InitializeComponent();
            _servicio = servicio;
            _mapper = mapper;
        }

        private void FrmRellenos_Load(object sender, EventArgs e)
        {
            try
            {
                lista = _servicio.ObtenerLista();
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
            foreach (var relleno in lista)
            {
                DataGridViewRow r = GridHelper.ConstruirFila(dgvDatos);
                GridHelper.SetearFila(r, relleno);
                GridHelper.AgregarFila(r,dgvDatos);
            }
        }


        private void TsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TsbNuevo_Click(object sender, EventArgs e)
        {
            FrmRellenosAE frm = new FrmRellenosAE() { Text = "Agregar Relleno" };
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) return;
            var rellenoDto = frm.GetRelleno();
            if (rellenoDto is null) return;
            try
            {
                if (_servicio.Guardar(rellenoDto, out var errores))
                {
                    var rellenoListDto=_mapper.Map<RellenoListDto>(rellenoDto);
                    DataGridViewRow r = GridHelper.ConstruirFila(dgvDatos);
                    GridHelper.SetearFila(r, rellenoListDto);
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


        private void TsbBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0) return;
            DataGridViewRow r = dgvDatos.SelectedRows[0];
            var relleno = r.Tag as RellenoListDto;
            if (relleno is null) return;
            DialogResult dr = MessageBox.Show($"¿Desea borrar el registro de {relleno.Descripcion}?",
                "Confirmar Baja",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No) return;
            try
            {
                if(_servicio.Borrar(relleno.RellenoId, out var errores))
                {
                    GridHelper.QuitarFila(r,dgvDatos);
                    MessageBox.Show("Registro Eliminado", "Información",
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


        private void TsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0) return;
            DataGridViewRow r = dgvDatos.SelectedRows[0];
            var rellenoDto = r.Tag as RellenoListDto;
            if (rellenoDto is null) return;
            var rellenoEditar = _mapper.Map<RellenoEditDto>(rellenoDto);
            FrmRellenosAE frm = new FrmRellenosAE() { Text = "Editar Relleno" };
            frm.SetRelleno(rellenoEditar);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) return;
            rellenoEditar = frm.GetRelleno();
            if (rellenoEditar is null) return;
            try
            {
                if (_servicio.Guardar(rellenoEditar, out var errores))
                {
                    rellenoDto = _mapper.Map<RellenoListDto>(rellenoEditar); ;
                    GridHelper.SetearFila(r, rellenoDto);
                    MessageBox.Show("Registro Editado", "Información",
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
