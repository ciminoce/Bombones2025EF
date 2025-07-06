using Bombones2025.Entidades.DTOs.Chocolate;
using Bombones2025.Entidades.Entidades;

namespace Bombones2025.Windows
{
    public partial class FrmChocolatesAE : Form
    {
        public FrmChocolatesAE()
        {
            InitializeComponent();
        }
        private ChocolateEditDto? chocolate;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (chocolate is not null)
            {
                TxtChocolate.Text = chocolate.Descripcion;
            }
        }
        public ChocolateEditDto? GetChocolate()
        {
            return chocolate;
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (chocolate is null)
                {
                    chocolate = new ChocolateEditDto();
                }
                chocolate.Descripcion = TxtChocolate.Text.Trim();
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(TxtChocolate.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(TxtChocolate, "La descripción es requerida");
            }
            return valido;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        public void SetChocolate(ChocolateEditDto chocolate)
        {
            this.chocolate = chocolate;
        }

    }
}
