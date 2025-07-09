namespace Bombones2025.Windows
{
    partial class FrmCiudadesAE
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
            components = new System.ComponentModel.Container();
            CboPaises = new ComboBox();
            label2 = new Label();
            BtnCancelar = new Button();
            BtnOK = new Button();
            TxtCiudad = new TextBox();
            label1 = new Label();
            label3 = new Label();
            CboProvEstados = new ComboBox();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // CboPaises
            // 
            CboPaises.DropDownStyle = ComboBoxStyle.DropDownList;
            CboPaises.FormattingEnabled = true;
            CboPaises.Location = new Point(151, 29);
            CboPaises.Name = "CboPaises";
            CboPaises.Size = new Size(342, 23);
            CboPaises.TabIndex = 22;
            CboPaises.SelectedIndexChanged += CboPaises_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(75, 30);
            label2.Name = "label2";
            label2.Size = new Size(31, 15);
            label2.TabIndex = 21;
            label2.Text = "País:";
            // 
            // BtnCancelar
            // 
            BtnCancelar.Image = Properties.Resources.Cancelar;
            BtnCancelar.Location = new Point(418, 162);
            BtnCancelar.Name = "BtnCancelar";
            BtnCancelar.Size = new Size(75, 52);
            BtnCancelar.TabIndex = 19;
            BtnCancelar.Text = "Cancelar";
            BtnCancelar.TextImageRelation = TextImageRelation.ImageAboveText;
            BtnCancelar.UseVisualStyleBackColor = true;
            // 
            // BtnOK
            // 
            BtnOK.Image = Properties.Resources.Aceptar1;
            BtnOK.Location = new Point(79, 162);
            BtnOK.Name = "BtnOK";
            BtnOK.Size = new Size(75, 52);
            BtnOK.TabIndex = 20;
            BtnOK.Text = "OK";
            BtnOK.TextImageRelation = TextImageRelation.ImageAboveText;
            BtnOK.UseVisualStyleBackColor = true;
            // 
            // TxtCiudad
            // 
            TxtCiudad.Location = new Point(151, 116);
            TxtCiudad.MaxLength = 100;
            TxtCiudad.Name = "TxtCiudad";
            TxtCiudad.Size = new Size(342, 23);
            TxtCiudad.TabIndex = 18;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(71, 119);
            label1.Name = "label1";
            label1.Size = new Size(48, 15);
            label1.TabIndex = 17;
            label1.Text = "Ciudad:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(75, 75);
            label3.Name = "label3";
            label3.Size = new Size(74, 15);
            label3.TabIndex = 21;
            label3.Text = "Prov/Estado:";
            // 
            // CboProvEstados
            // 
            CboProvEstados.DropDownStyle = ComboBoxStyle.DropDownList;
            CboProvEstados.FormattingEnabled = true;
            CboProvEstados.Location = new Point(151, 72);
            CboProvEstados.Name = "CboProvEstados";
            CboProvEstados.Size = new Size(342, 23);
            CboProvEstados.TabIndex = 22;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // FrmCiudadesAE
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(565, 241);
            Controls.Add(CboProvEstados);
            Controls.Add(label3);
            Controls.Add(CboPaises);
            Controls.Add(label2);
            Controls.Add(BtnCancelar);
            Controls.Add(BtnOK);
            Controls.Add(TxtCiudad);
            Controls.Add(label1);
            MaximumSize = new Size(581, 280);
            MinimumSize = new Size(581, 280);
            Name = "FrmCiudadesAE";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmCiudadesAE";
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox CboPaises;
        private Label label2;
        private Button BtnCancelar;
        private Button BtnOK;
        private TextBox TxtCiudad;
        private Label label1;
        private Label label3;
        private ComboBox CboProvEstados;
        private ErrorProvider errorProvider1;
    }
}