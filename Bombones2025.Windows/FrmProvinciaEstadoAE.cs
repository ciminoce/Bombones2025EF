using Bombones2025.Entidades.Entidades;
using Bombones2025.Servicios.Interfaces;
using Bombones2025.Windows.Helpers;

namespace Bombones2025.Windows
{
    public partial class FrmProvinciaEstadoAE : Form
    {
        private ProvinciaEstado? provinciaEstado;
        private readonly IPaisServicio _paisServicio;
        public FrmProvinciaEstadoAE(IPaisServicio paisServicio)
        {
            InitializeComponent();
            _paisServicio = paisServicio;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CombosHelper.CargarComboPaises(ref CboPaises, _paisServicio);
            if(provinciaEstado is not null)
            {
                TxtProvincia.Text = provinciaEstado.NombreProvinciaEstado;
                CboPaises.SelectedValue = provinciaEstado.PaisId;
            }
        }
        public ProvinciaEstado? GetProvincia()
        {
            return provinciaEstado;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (provinciaEstado is null)
                {
                    provinciaEstado = new ProvinciaEstado();
                }
                provinciaEstado.NombreProvinciaEstado = TxtProvincia.Text;
                provinciaEstado.PaisId = (int)CboPaises.SelectedValue!;
                //provinciaEstado.Pais = (Pais)CboPaises.SelectedItem!;

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
            if (string.IsNullOrEmpty(TxtProvincia.Text))
            {
                valido = false;
                errorProvider1.SetError(TxtProvincia, "El nombre es requerido");
            }
            return valido;

        }

        public void SetProvincia(ProvinciaEstado peEditar)
        {
            provinciaEstado = peEditar;
        }
    }
}
