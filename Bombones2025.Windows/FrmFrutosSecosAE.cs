using Bombones2025.Entidades.DTOs.FrutoSeco;
using Bombones2025.Entidades.Entidades;

namespace Bombones2025.Windows
{
    public partial class FrmFrutosSecosAE : Form
    {
        private FrutoSecoEditDto? frutoDto;
        public FrmFrutosSecosAE()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (frutoDto is not null)
            {
                TxtFrutoSeco.Text = frutoDto.Descripcion;
            }
        }
        public FrutoSecoEditDto? GetFrutoSeco()
        {
            return frutoDto;
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (frutoDto is null)
                {
                    frutoDto = new FrutoSecoEditDto();
                }
                frutoDto.Descripcion = TxtFrutoSeco.Text.Trim();
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(TxtFrutoSeco.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(TxtFrutoSeco, "La descripción es requerida");
            }
            return valido;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        public void SetFruto(FrutoSecoEditDto fs)
        {
            frutoDto = fs;
        }
    }
}
