using AutoMapper;
using Bombones2025.Entidades.DTOs.Chocolate;
using Bombones2025.Entidades.Entidades;
using Bombones2025.Servicios.Interfaces;
using Bombones2025.Windows.Helpers;

namespace Bombones2025.Windows
{
    public partial class FrmChocolates : Form
    {
        private readonly IChocolateServicio _servicio = null!;
        private readonly IMapper _mapper;
        private List<ChocolateListDto> lista = null!;
        public FrmChocolates(IChocolateServicio servicio, IMapper mapper)
        {
            InitializeComponent();
            _servicio = servicio;
            _mapper = mapper;
        }

        private void FrmChocolates_Load(object sender, EventArgs e)
        {
            try
            {
                lista = _servicio.GetLista();
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
            foreach (var chocolate in lista)
            {
                var r = GridHelper.ConstruirFila(dgvDatos);
                GridHelper.SetearFila(r, chocolate);
                GridHelper.AgregarFila(r, dgvDatos);
            }
        }
        private void TsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TsbNuevo_Click(object sender, EventArgs e)
        {
            FrmChocolatesAE frm = new FrmChocolatesAE() { Text = "Agregar Chocolate" };
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) return;
            var chocolateDto = frm.GetChocolate();
            if (chocolateDto is null) return;
            try
            {
                if (_servicio.Guardar(chocolateDto, out var errores))
                {
                    var chocolateListDto=_mapper.Map<ChocolateListDto>(chocolateDto);
                    DataGridViewRow r = GridHelper.ConstruirFila(dgvDatos);
                    GridHelper.SetearFila(r, chocolateListDto);
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
            var chocolate = r.Tag as ChocolateListDto ;
            if (chocolate is null) return;
            DialogResult dr = MessageBox.Show($"¿Desea borrar el registro de {chocolate.Descripcion}?",
                "Confirmar Baja",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No) return;

            try
            {
                if (_servicio.Borrar(chocolate.ChocolateId, out var errores))
                {
                    GridHelper.QuitarFila(r, dgvDatos);
                    MessageBox.Show("Registro Eliminado", "Información",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

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
            var chocolateDto = r.Tag as ChocolateListDto;
            if (chocolateDto is null) return;
            var chocoEditarDto =_mapper.Map<ChocolateEditDto>(chocolateDto);
            FrmChocolatesAE frm = new FrmChocolatesAE() { Text = "Editar Chocolate" };
            frm.SetChocolate(chocoEditarDto);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) return;
            chocoEditarDto = frm.GetChocolate();
            if (chocoEditarDto is null) return;
            try
            {
                if (_servicio.Guardar(chocoEditarDto, out var errores))
                {
                    chocolateDto = _mapper.Map<ChocolateListDto>(chocoEditarDto);
                    GridHelper.SetearFila(r, chocolateDto);
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
