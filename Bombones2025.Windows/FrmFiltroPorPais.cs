
using Bombones2025.Entidades.DTOs.Pais;
using Bombones2025.Entidades.Entidades;
using Bombones2025.Servicios.Interfaces;
using Bombones2025.Windows.Helpers;

namespace Bombones2025.Windows
{
    public partial class FrmFiltroPorPais : Form
    {
        private readonly IPaisServicio _paisServicio;
        private PaisListDto? paisFiltro;
        public FrmFiltroPorPais(IPaisServicio paisServicio)
        {
            InitializeComponent();
            _paisServicio = paisServicio;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CombosHelper.CargarComboPaises(ref CboPaises, _paisServicio);
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                DialogResult = DialogResult.OK;
            }
        }

        public PaisListDto? GetPais()
        {
            return paisFiltro;
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
            return valido;
        }

        private void CboPaises_SelectedIndexChanged(object sender, EventArgs e)
        {
            paisFiltro = CboPaises.SelectedIndex > 0 ? (PaisListDto)CboPaises.SelectedItem!
                : null;
        }
    }
}
