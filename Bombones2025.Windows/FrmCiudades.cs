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
            FrmCiudadesAE frm = new FrmCiudadesAE(_paisServicio, _provinciaServicio) { Text = "Agregar Fruto Seco" };
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) return;
            var ciudadEditDto = frm.GetCiudad();
            if (ciudadEditDto is null) return;
            try
            {
                if (_ciudadServicio.Guardar(ciudadEditDto, out var errores))
                {
                    //Tengo que generar un CiudadListDto para mostrarlo en la grilla
                    CiudadListDto ciudadDto = _mapper.Map<CiudadListDto>(ciudadEditDto);
                    //Tengo que obtener los datos que me faltan!!!
                    var provinciaDto = _provinciaServicio.GetById(ciudadEditDto.ProvinciaEstadoId);
                    ciudadDto.NombreProvincia = provinciaDto.NombreProvinciaEstado;
                    var paisDto = _paisServicio.GetById(provinciaDto.PaisId);
                    ciudadDto.NombrePais = paisDto.NombrePais;
                    //Joya ya tengo todos los datos... ahora lo muestro
                    DataGridViewRow r = GridHelper.ConstruirFila(dgvDatos);
                    GridHelper.SetearFila(r, ciudadDto!);
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
            var ciudadDto = r.Tag as CiudadListDto;
            if (ciudadDto is null) return;
            DialogResult dr = MessageBox.Show($"¿Desea borrar el registro de {ciudadDto.NombreCiudad}?",
                "Confirmar Baja",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No) return;
            try
            {
                if (_ciudadServicio.Borrar(ciudadDto.CiudadId, out var errores))
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
            var ciudadDto = r.Tag as CiudadListDto;
            if (ciudadDto is null) return;
            var ciudadEditar = _ciudadServicio.GetById(ciudadDto.CiudadId);
            if (ciudadEditar is null) return;
            FrmCiudadesAE frm = new FrmCiudadesAE(_paisServicio, _provinciaServicio) { Text = "Editar Fruto Seco" };
            frm.SetCiudad(ciudadEditar);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) return;
            ciudadEditar = frm.GetCiudad();
            if (ciudadEditar is null) return;
            try
            {
                if (_ciudadServicio.Guardar(ciudadEditar, out var errores))
                {
                    var ceEditadoDto = _mapper.Map<CiudadListDto>(ciudadEditar);
                    var provDto = _provinciaServicio.GetById(ciudadEditar.ProvinciaEstadoId);

                    var paisDto = _paisServicio.GetById(provDto!.PaisId);

                    ceEditadoDto.NombrePais = paisDto!.NombrePais;
                    ceEditadoDto.NombreProvincia = provDto.NombreProvinciaEstado;
                    GridHelper.SetearFila(r, ceEditadoDto!);
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

        private void textoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmFiltro frm = new FrmFiltro() { Text = "Filtrar por texto" };
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) return;
            var textoFiltro = frm.GetTexto();
            if (textoFiltro == null) return;
            try
            {
                ciudades = _ciudadServicio.GetLista(null, null, textoFiltro);
                MostrarDatosEnGrilla();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void paísToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmFiltroPorPais frm = new FrmFiltroPorPais(_paisServicio) { Text = "Seleccionar País a Filtrar" };
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) return;
            var paisFiltrar = frm.GetPais();
            if (paisFiltrar == null) return;
            try
            {
                ciudades = _ciudadServicio.GetLista(paisFiltrar.PaisId);
                MostrarDatosEnGrilla();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void provinciaEstadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProvinciaFiltro frm = new FrmProvinciaFiltro(_paisServicio,_provinciaServicio) { Text = "Seleccionar País y Provincia a Filtrar" };
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) return;
            var provinciaFiltrar = frm.GetProvincia();
            if (provinciaFiltrar == null) return;
            try
            {
                ciudades = _ciudadServicio.GetLista(null, provinciaFiltrar.ProvinciaEstadoId);
                MostrarDatosEnGrilla();
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
