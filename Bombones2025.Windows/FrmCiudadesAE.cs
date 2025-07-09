using Bombones2025.Entidades.DTOs.Ciudad;
using Bombones2025.Servicios.Interfaces;
using Bombones2025.Windows.Helpers;

namespace Bombones2025.Windows
{
    public partial class FrmCiudadesAE : Form
    {
        private CiudadEditDto? ciudadDto;
        private IPaisServicio _paisServicio;
        public FrmCiudadesAE(IPaisServicio paisServicio)
        {
            InitializeComponent();
            _paisServicio = paisServicio;
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
    }
}
