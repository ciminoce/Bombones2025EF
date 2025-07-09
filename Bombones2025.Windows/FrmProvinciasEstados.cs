using AutoMapper;
using Bombones2025.Entidades.DTOs.ProvinciaEstado;
using Bombones2025.Servicios.Interfaces;
using Bombones2025.Windows.Helpers;
using Bombones2025.Windows.Properties;

namespace Bombones2025.Windows
{
    public partial class FrmProvinciasEstados : Form
    {
        private readonly IProvinciaEstadoServicio _provinciaServicio;
        private readonly IPaisServicio _paisServicio;
        private readonly IMapper _mapper;
        private bool filterOn = false;

        private List<ProvinciaEstadoListDto>? provincias;
        public FrmProvinciasEstados(IProvinciaEstadoServicio provinciaServicio, IPaisServicio paisServicio, IMapper mapper)
        {
            InitializeComponent();
            _provinciaServicio = provinciaServicio;
            _paisServicio = paisServicio;
            _mapper = mapper;
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
                var paisFiltro = frm.GetPais();
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
            var provEstado = frm.GetProvincia();
            if (provEstado is null) return;
            try
            {
                if (_provinciaServicio.Guardar(provEstado, out var errores))
                {
                    //var peAgregadoDto = _provinciaServicio.GetById(provEstado.ProvinciaEstadoId);
                    var peListDto = _mapper.Map<ProvinciaEstadoListDto>(provEstado);
                    var paisDto = _paisServicio.GetById(provEstado!.PaisId);
                    peListDto.NombrePais = paisDto!.NombrePais;
                    DataGridViewRow r = GridHelper.ConstruirFila(dgvDatos);
                    GridHelper.SetearFila(r, peListDto!);
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
            var pe = r.Tag as ProvinciaEstadoListDto;
            if (pe is null) return;
            DialogResult dr = MessageBox.Show($"¿Desea borrar el registro de {pe.NombreProvinciaEstado}?",
                "Confirmar Baja",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No) return;
            try
            {
                if (_provinciaServicio.Borrar(pe.ProvinciaEstadoId, out var errores))
                {
                    GridHelper.QuitarFila(r, dgvDatos);
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
            var pe = r.Tag as ProvinciaEstadoListDto;
            if (pe is null) return;
            var peEditar = _provinciaServicio.GetById(pe.ProvinciaEstadoId);
            if (peEditar is null) return;
            FrmProvinciaEstadoAE frm = new FrmProvinciaEstadoAE(_paisServicio) { Text = "Editar Fruto Seco" };
            frm.SetProvincia(peEditar);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) return;
            peEditar = frm.GetProvincia();
            if (peEditar is null) return;
            try
            {
                if (_provinciaServicio.Guardar(peEditar, out var errores))
                {
                    var peEditadoDto = _mapper.Map<ProvinciaEstadoListDto>(peEditar);
                    var paisDto = _paisServicio.GetById(peEditar.PaisId);
                    peEditadoDto.NombrePais = paisDto!.NombrePais;
                    GridHelper.SetearFila(r, peEditadoDto!);
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
