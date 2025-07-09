using Bombones2025.Entidades.DTOs.Pais;
using Bombones2025.Entidades.DTOs.ProvinciaEstado;
using Bombones2025.Servicios.Interfaces;
using Bombones2025.Windows.Helpers;

namespace Bombones2025.Windows
{
    public partial class FrmProvinciaFiltro : Form
    {
        private ProvinciaEstadoListDto? provinciaSeleccionada;
        private PaisListDto? paisSeleccionado;
        private readonly IPaisServicio _paisServicio;
        private readonly IProvinciaEstadoServicio _provinciaEstadoServicio;

        public FrmProvinciaFiltro(IPaisServicio paisServicio, IProvinciaEstadoServicio provinciaEstadoServicio)
        {
            _paisServicio = paisServicio;
            _provinciaEstadoServicio = provinciaEstadoServicio;
            InitializeComponent();

        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void CboPaises_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CboPaises.SelectedIndex > 0)
            {
                paisSeleccionado = (PaisListDto)CboPaises.SelectedItem!;
                CombosHelper.CargarComboProvincias(ref CboProvEstados,
                    paisSeleccionado.PaisId, _provinciaEstadoServicio);
            }
            else
            {
                /*
                 * Si no hay país seleccionado se tiene que 
                 * limpiar el combo de provincias!!!
                 */
                paisSeleccionado = null;
                CboProvEstados.DataSource = null;
            }

        }

        private void FrmProvinciaFiltro_Load(object sender, EventArgs e)
        {
            CombosHelper.CargarComboPaises(ref CboPaises, _paisServicio);

        }

        private void CboProvEstados_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CboProvEstados.SelectedIndex > 0)
            {
                provinciaSeleccionada = (ProvinciaEstadoListDto)CboProvEstados.SelectedItem!;
            }
            else
            {
                provinciaSeleccionada = null;
            }

        }

        public ProvinciaEstadoListDto? GetProvincia()
        {
            return provinciaSeleccionada;
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (CboPaises.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(CboPaises, "Debe seleccionar un país");
            }
            if (CboProvEstados.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(CboProvEstados, "Debe seleccionar un estado");
            }
            return valido;

        }
    }
}
