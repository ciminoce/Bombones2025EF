using Bombones2025.Entidades.DTOs.Ciudad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bombones2025.Windows
{
    public partial class FrmCiudadesAE : Form
    {
        private CiudadEditDto? ciudadDto;
        public FrmCiudadesAE(Servicios.Interfaces.ICiudadServicio ciudadServicio)
        {
            InitializeComponent();
        }

        public CiudadEditDto GetCiudad()
        {
            throw new NotImplementedException();
        }
    }
}
