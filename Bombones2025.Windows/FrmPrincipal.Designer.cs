namespace Bombones2025.Windows
{
    partial class FrmPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            BtnPaises = new Button();
            BtnFrutosSecos = new Button();
            BtnRellenos = new Button();
            BtnChocolates = new Button();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            LblUsuario = new ToolStripStatusLabel();
            BtnSalir = new Button();
            BtnProvincias = new Button();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // BtnPaises
            // 
            BtnPaises.Location = new Point(46, 61);
            BtnPaises.Margin = new Padding(3, 4, 3, 4);
            BtnPaises.Name = "BtnPaises";
            BtnPaises.Size = new Size(99, 72);
            BtnPaises.TabIndex = 0;
            BtnPaises.Text = "Países";
            BtnPaises.UseVisualStyleBackColor = true;
            BtnPaises.Click += BtnPaises_Click;
            // 
            // BtnFrutosSecos
            // 
            BtnFrutosSecos.Location = new Point(175, 61);
            BtnFrutosSecos.Margin = new Padding(3, 4, 3, 4);
            BtnFrutosSecos.Name = "BtnFrutosSecos";
            BtnFrutosSecos.Size = new Size(99, 72);
            BtnFrutosSecos.TabIndex = 0;
            BtnFrutosSecos.Text = "Frutos Secos";
            BtnFrutosSecos.UseVisualStyleBackColor = true;
            BtnFrutosSecos.Click += BtnFrutosSecos_Click;
            // 
            // BtnRellenos
            // 
            BtnRellenos.Location = new Point(303, 61);
            BtnRellenos.Margin = new Padding(3, 4, 3, 4);
            BtnRellenos.Name = "BtnRellenos";
            BtnRellenos.Size = new Size(99, 72);
            BtnRellenos.TabIndex = 0;
            BtnRellenos.Text = "Rellenos";
            BtnRellenos.UseVisualStyleBackColor = true;
            BtnRellenos.Click += BtnRellenos_Click;
            // 
            // BtnChocolates
            // 
            BtnChocolates.Location = new Point(434, 61);
            BtnChocolates.Margin = new Padding(3, 4, 3, 4);
            BtnChocolates.Name = "BtnChocolates";
            BtnChocolates.Size = new Size(99, 72);
            BtnChocolates.TabIndex = 0;
            BtnChocolates.Text = "Chocolates";
            BtnChocolates.UseVisualStyleBackColor = true;
            BtnChocolates.Click += BtnChocolates_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, LblUsuario });
            statusStrip1.Location = new Point(0, 574);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new Padding(1, 0, 16, 0);
            statusStrip1.Size = new Size(914, 26);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(62, 20);
            toolStripStatusLabel1.Text = "Usuario:";
            // 
            // LblUsuario
            // 
            LblUsuario.Name = "LblUsuario";
            LblUsuario.Size = new Size(151, 20);
            LblUsuario.Text = "toolStripStatusLabel2";
            // 
            // BtnSalir
            // 
            BtnSalir.Location = new Point(786, 477);
            BtnSalir.Margin = new Padding(3, 4, 3, 4);
            BtnSalir.Name = "BtnSalir";
            BtnSalir.Size = new Size(99, 72);
            BtnSalir.TabIndex = 0;
            BtnSalir.Text = "Salir";
            BtnSalir.UseVisualStyleBackColor = true;
            BtnSalir.Click += BtnSalir_Click;
            // 
            // BtnProvincias
            // 
            BtnProvincias.Location = new Point(46, 165);
            BtnProvincias.Margin = new Padding(3, 4, 3, 4);
            BtnProvincias.Name = "BtnProvincias";
            BtnProvincias.Size = new Size(99, 72);
            BtnProvincias.TabIndex = 0;
            BtnProvincias.Text = "Provincias";
            BtnProvincias.UseVisualStyleBackColor = true;
            // 
            // FrmPrincipal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(statusStrip1);
            Controls.Add(BtnSalir);
            Controls.Add(BtnChocolates);
            Controls.Add(BtnRellenos);
            Controls.Add(BtnFrutosSecos);
            Controls.Add(BtnProvincias);
            Controls.Add(BtnPaises);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmPrincipal";
            Text = "FrmPrincipal";
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BtnPaises;
        private Button BtnFrutosSecos;
        private Button BtnRellenos;
        private Button BtnChocolates;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel LblUsuario;
        private Button BtnSalir;
        private Button BtnProvincias;
    }
}