using Bombones2025.Entidades.DTOs.Ciudad;
using Bombones2025.Entidades.DTOs.Pais;
using Bombones2025.Entidades.DTOs.ProvinciaEstado;
using Bombones2025.Servicios.Interfaces;
using Bombones2025.Windows.Helpers;

namespace Bombones2025.Windows
{
    public partial class FrmCiudadesAE : Form
    {
        private CiudadEditDto? ciudadDto;
        private IPaisServicio _paisServicio;
        private IProvinciaEstadoServicio _provinciaEstadoServicio;
        private PaisListDto? paisSeleccionado;
        private ProvinciaEstadoListDto? provinciaSeleccionada;
        public FrmCiudadesAE(IPaisServicio paisServicio,
            IProvinciaEstadoServicio provinciaEstadoServicio)
        {
            InitializeComponent();
            _paisServicio = paisServicio;
            _provinciaEstadoServicio = provinciaEstadoServicio;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CombosHelper.CargarComboPaises(ref CboPaises, _paisServicio);
            if (ciudadDto != null)
            {

                var provincia = _provinciaEstadoServicio.ObtenerPorId(ciudadDto.ProvinciaEstadoId);
                CboPaises.SelectedValue = provincia!.PaisId;
                //ACA HAY QUE CARGAR EL COMBO DE LAS PROVINCIAS!!!
                CombosHelper.CargarComboProvincias(ref CboProvEstados, 
                    provincia.PaisId, _provinciaEstadoServicio);
                CboProvEstados.SelectedValue = ciudadDto.ProvinciaEstadoId;
                TxtCiudad.Text = ciudadDto.NombreCiudad;
                //wait.... to check
            }
        }
        public CiudadEditDto? GetCiudad()
        {
            //FUCK!!!
            return ciudadDto;
        }

        private void CboPaises_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
             * cuando cambia el índice del combo, si este no es 0, entonces
             * se puede cargar el combo de las provincias de acuerdo
             * con el país seleccionado... vamos a por ello.
             */
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

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (ciudadDto is null)
                {
                    ciudadDto = new CiudadEditDto();

                }
                ciudadDto.NombreCiudad = TxtCiudad.Text;
                ciudadDto.ProvinciaEstadoId = provinciaSeleccionada!.ProvinciaEstadoId;
                
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
            if (string.IsNullOrEmpty(TxtCiudad.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(TxtCiudad, "El nombre es requerido");
            }
            return valido;
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

        public void SetCiudad(CiudadEditDto ciudadEditar)
        {
            this.ciudadDto=ciudadEditar;
        }
    }
}
