using Bombones2025.Entidades.DTOs.Ciudad;
using Bombones2025.Entidades.DTOs.Pais;
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
        }
        public CiudadEditDto GetCiudad()
        {
            throw new NotImplementedException();
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
    }
}
