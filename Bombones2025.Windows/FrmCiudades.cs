using AutoMapper;
using Bombones2025.Entidades.DTOs.Ciudad;
using Bombones2025.Servicios.Interfaces;
using Bombones2025.Windows.Helpers;
using Bombones2025.Windows.Properties;

namespace Bombones2025.Windows
{
    public partial class FrmCiudades : Form
    {
        private readonly ICiudadServicio _ciudadServicio;
        private readonly IPaisServicio _paisServicio;
        private readonly IProvinciaEstadoServicio _provinciaServicio;
        private readonly IMapper _mapper;

        private bool filterOn = false;

        private List<CiudadListDto>? ciudades;

        public FrmCiudades(ICiudadServicio ciudadServicio,
            IProvinciaEstadoServicio provinciaServicio,
            IPaisServicio paisServicio, IMapper mapper)
        {
            InitializeComponent();

            _ciudadServicio = ciudadServicio;
            _paisServicio = paisServicio;
            _mapper = mapper;
            _provinciaServicio = provinciaServicio;
        }

        private void FrmCiudades_Load(object sender, EventArgs e)
        {
            try
            {
                ciudades = _ciudadServicio.GetLista();
                MostrarDatosEnGrilla();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void TsbNuevo_Click(object sender, EventArgs e)
        {
            //FrmCiudadesAE frm = new FrmCiudadesAE(_ciudadServicio) { Text = "Agregar Fruto Seco" };
            //DialogResult dr = frm.ShowDialog(this);
            //if (dr == DialogResult.Cancel) return;
            //var ciudadEditDto = frm.GetCiudad();
            //if (ciudadEditDto is null) return;
            //try
            //{
            //    if (_ciudadServicio.Guardar(ciudadEditDto, out var errores))
            //    {

            //        DataGridViewRow r = GridHelper.ConstruirFila(dgvDatos);
            //        GridHelper.SetearFila(r, ciudadDto!);
            //        GridHelper.AgregarFila(r, dgvDatos);
            //        MessageBox.Show("Registro Agregado", "Información",
            //            MessageBoxButtons.OK, MessageBoxIcon.Information);

            //    }

            //    else
            //    {
            //        MessageBox.Show(errores.First(), "Error",
            //            MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show(ex.Message, "Error",
            //        MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

        }

        private void TsbBorrar_Click(object sender, EventArgs e)
        {
            //if (dgvDatos.SelectedRows.Count == 0) return;
            //DataGridViewRow r = dgvDatos.SelectedRows[0];
            //var pe = r.Tag as ProvinciaEstadoListDto;
            //if (pe is null) return;
            //DialogResult dr = MessageBox.Show($"¿Desea borrar el registro de {pe.NombreProvinciaEstado}?",
            //    "Confirmar Baja",
            //    MessageBoxButtons.YesNo, MessageBoxIcon.Question,
            //    MessageBoxDefaultButton.Button2);
            //if (dr == DialogResult.No) return;
            //try
            //{
            //    if (_provinciaServicio.Borrar(pe.ProvinciaEstadoId, out var errores))
            //    {
            //        GridHelper.QuitarFila(r, dgvDatos);
            //        MessageBox.Show("Registro Eliminado", "Información",
            //                MessageBoxButtons.OK, MessageBoxIcon.Information);

            //    }
            //    else
            //    {
            //        MessageBox.Show(errores.First(), "Error",
            //            MessageBoxButtons.OK, MessageBoxIcon.Error);

            //    }

            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show(ex.Message, "Error",
            //        MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

        }

        private void TsbEditar_Click(object sender, EventArgs e)
        {
            //if (dgvDatos.SelectedRows.Count == 0) return;
            //DataGridViewRow r = dgvDatos.SelectedRows[0];
            //var pe = r.Tag as ProvinciaEstadoListDto;
            //if (pe is null) return;
            //var peEditar = _provinciaServicio.GetById(pe.ProvinciaEstadoId);
            //if (peEditar is null) return;
            //FrmProvinciaEstadoAE frm = new FrmProvinciaEstadoAE(_paisServicio) { Text = "Editar Fruto Seco" };
            //frm.SetProvincia(peEditar);
            //DialogResult dr = frm.ShowDialog(this);
            //if (dr == DialogResult.Cancel) return;
            //peEditar = frm.GetProvincia();
            //if (peEditar is null) return;
            //try
            //{
            //    if (_provinciaServicio.Guardar(peEditar, out var errores))
            //    {
            //        var peEditadoDto = _mapper.Map<ProvinciaEstadoListDto>(peEditar);
            //        var paisDto = _paisServicio.GetById(peEditar.PaisId);
            //        peEditadoDto.NombrePais = paisDto!.NombrePais;
            //        GridHelper.SetearFila(r, peEditadoDto!);
            //        MessageBox.Show("Registro Editado", "Información",
            //            MessageBoxButtons.OK, MessageBoxIcon.Information);

            //    }
            //    else
            //    {
            //        MessageBox.Show(errores.First(), "Error",
            //            MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show(ex.Message, "Error",
            //        MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

        }

        private void TsbActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                filterOn = false;
                TsbFiltrar.Image = Resources.filter_40px;
                ciudades = _ciudadServicio.GetLista();
                MostrarDatosEnGrilla();

            }
            catch (Exception)
            {

                throw;
            }

        }

        private void MostrarDatosEnGrilla()
        {
            GridHelper.LimpiarGrilla(dgvDatos);
            foreach (var ciudad in ciudades!)
            {
                var r = GridHelper.ConstruirFila(dgvDatos);
                GridHelper.SetearFila(r, ciudad);
                GridHelper.AgregarFila(r, dgvDatos);
            }
        }

        private void TsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
