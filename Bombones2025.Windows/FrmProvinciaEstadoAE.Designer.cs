namespace Bombones2025.Windows
{
    partial class FrmProvinciaEstadoAE
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
            BtnCancelar = new Button();
            BtnOK = new Button();
            TxtProvincia = new TextBox();
            label1 = new Label();
            label2 = new Label();
            CboPaises = new ComboBox();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // BtnCancelar
            // 
            BtnCancelar.Image = Properties.Resources.Cancelar;
            BtnCancelar.Location = new Point(459, 185);
            BtnCancelar.Margin = new Padding(3, 4, 3, 4);
            BtnCancelar.Name = "BtnCancelar";
            BtnCancelar.Size = new Size(86, 69);
            BtnCancelar.TabIndex = 13;
            BtnCancelar.Text = "Cancelar";
            BtnCancelar.TextImageRelation = TextImageRelation.ImageAboveText;
            BtnCancelar.UseVisualStyleBackColor = true;
            // 
            // BtnOK
            // 
            BtnOK.Image = Properties.Resources.Aceptar1;
            BtnOK.Location = new Point(72, 185);
            BtnOK.Margin = new Padding(3, 4, 3, 4);
            BtnOK.Name = "BtnOK";
            BtnOK.Size = new Size(86, 69);
            BtnOK.TabIndex = 14;
            BtnOK.Text = "OK";
            BtnOK.TextImageRelation = TextImageRelation.ImageAboveText;
            BtnOK.UseVisualStyleBackColor = true;
            // 
            // TxtProvincia
            // 
            TxtProvincia.Location = new Point(163, 36);
            TxtProvincia.Margin = new Padding(3, 4, 3, 4);
            TxtProvincia.MaxLength = 100;
            TxtProvincia.Name = "TxtProvincia";
            TxtProvincia.Size = new Size(390, 27);
            TxtProvincia.TabIndex = 12;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(72, 40);
            label1.Name = "label1";
            label1.Size = new Size(92, 20);
            label1.TabIndex = 11;
            label1.Text = "Prov/Estado:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(77, 96);
            label2.Name = "label2";
            label2.Size = new Size(37, 20);
            label2.TabIndex = 15;
            label2.Text = "País:";
            // 
            // CboPaises
            // 
            CboPaises.DropDownStyle = ComboBoxStyle.DropDownList;
            CboPaises.FormattingEnabled = true;
            CboPaises.Location = new Point(163, 95);
            CboPaises.Margin = new Padding(3, 4, 3, 4);
            CboPaises.Name = "CboPaises";
            CboPaises.Size = new Size(390, 28);
            CboPaises.TabIndex = 16;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // FrmProvinciaEstadoAE
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(627, 289);
            Controls.Add(CboPaises);
            Controls.Add(label2);
            Controls.Add(BtnCancelar);
            Controls.Add(BtnOK);
            Controls.Add(TxtProvincia);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
            MaximumSize = new Size(645, 336);
            MinimumSize = new Size(645, 336);
            Name = "FrmProvinciaEstadoAE";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmProvinciaEstadoAE";
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BtnCancelar;
        private Button BtnOK;
        private TextBox TxtProvincia;
        private Label label1;
        private Label label2;
        private ComboBox CboPaises;
        private ErrorProvider errorProvider1;
    }
}