using Bombones2025.Entidades.DTOs.Relleno;
using Bombones2025.Entidades.Entidades;

namespace Bombones2025.Windows
{
    public partial class FrmRellenosAE : Form
    {
        public FrmRellenosAE()
        {
            InitializeComponent();
        }
        private RellenoEditDto? relleno;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (relleno is not null)
            {
                TxtRelleno.Text = relleno.Descripcion;
            }
        }
        public RellenoEditDto? GetRelleno()
        {
            return relleno;
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (relleno is null)
                {
                    relleno = new RellenoEditDto();
                }
                relleno.Descripcion = TxtRelleno.Text.Trim();
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(TxtRelleno.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(TxtRelleno, "La descripción es requerida");
            }
            return valido;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        public void SetRelleno(RellenoEditDto relleno)
        {
            this.relleno = relleno;
        }


    }
}
