﻿using AutoMapper;
using Bombones2025.Entidades.Entidades;
using Bombones2025.Infraestructura;
using Bombones2025.Servicios.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Bombones2025.Windows
{
    public partial class FrmPrincipal : Form
    {
        private Usuario usuario = null!;
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void BtnPaises_Click(object sender, EventArgs e)
        {
            try
            {
                IPaisServicio servicio = AppServices.ServiceProvider!
                    .GetRequiredService<IPaisServicio>();
                IMapper mapper = AppServices.ServiceProvider!
                    .GetRequiredService<IMapper>();
                FrmPaises frm = new FrmPaises(servicio, mapper) { Text = "Listado de Paises" };
                frm.ShowDialog(this);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void BtnFrutosSecos_Click(object sender, EventArgs e)
        {
            try
            {
                IFrutoSecoServicio servicio = AppServices.ServiceProvider!
                    .GetRequiredService<IFrutoSecoServicio>();
                IMapper mapper = AppServices.ServiceProvider!
                    .GetRequiredService<IMapper>();

                FrmFrutosSecos frm = new FrmFrutosSecos(servicio, mapper) { Text = "Listado de Frutos Secos" };
                frm.ShowDialog(this);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

        }

        private void BtnRellenos_Click(object sender, EventArgs e)
        {
            try
            {
                IRellenoServicio servicio = AppServices.ServiceProvider!
                    .GetRequiredService<IRellenoServicio>();
                IMapper mapper = AppServices.ServiceProvider!
                    .GetRequiredService<IMapper>();

                FrmRellenos frm = new FrmRellenos(servicio, mapper) { Text = "Listado de Rellenos" };
                frm.ShowDialog(this);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

        }

        private void BtnChocolates_Click(object sender, EventArgs e)
        {
            try
            {
                IChocolateServicio servicio = AppServices.ServiceProvider!
                    .GetRequiredService<IChocolateServicio>();
                IMapper mapper = AppServices.ServiceProvider!
                    .GetRequiredService<IMapper>();

                FrmChocolates frm = new FrmChocolates(servicio, mapper) { Text = "Listado de Chocolates" };
                frm.ShowDialog(this);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

        }

        public void SetUsuario(Usuario usuarioLogueado)
        {
            LblUsuario.Text = usuarioLogueado.Nombre;
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnProvincias_Click(object sender, EventArgs e)
        {
            IProvinciaEstadoServicio provinciaServicio = AppServices.ServiceProvider!
                    .GetRequiredService<IProvinciaEstadoServicio>();
            IPaisServicio paisServicio = AppServices.ServiceProvider!
                    .GetRequiredService<IPaisServicio>();
            IMapper mapper = AppServices.ServiceProvider!.GetRequiredService<IMapper>();
            FrmProvinciasEstados frm = new FrmProvinciasEstados(
                provinciaServicio,
                paisServicio,
                mapper)
            { Text = "Listado de Provincias/Estados" };
            frm.ShowDialog(this);

        }

        private void BtnCiudades_Click(object sender, EventArgs e)
        {
            //no tenemos registrado el servicio en el inyector!!! joder!!!
            ICiudadServicio ciudadServicio=AppServices.ServiceProvider!
                .GetRequiredService<ICiudadServicio>();
            IProvinciaEstadoServicio provinciaServicio = AppServices.ServiceProvider!
                .GetRequiredService<IProvinciaEstadoServicio>();
            IPaisServicio paisServicio = AppServices.ServiceProvider!
                    .GetRequiredService<IPaisServicio>();
            IMapper mapper = AppServices.ServiceProvider!.GetRequiredService<IMapper>();
            FrmCiudades frm = new FrmCiudades(
                ciudadServicio,
                provinciaServicio,
                paisServicio,
                mapper)
            { Text = "Listado de Ciudades" };
            frm.ShowDialog(this);

        }
    }
}
