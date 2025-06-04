namespace Bombones2025.Windows
{
    partial class FrmFiltroPorPais
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
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // CboPaises
            // 
            CboPaises.DropDownStyle = ComboBoxStyle.DropDownList;
            CboPaises.FormattingEnabled = true;
            CboPaises.Location = new Point(122, 36);
            CboPaises.Name = "CboPaises";
            CboPaises.Size = new Size(342, 23);
            CboPaises.TabIndex = 20;
            CboPaises.SelectedIndexChanged += CboPaises_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(46, 37);
            label2.Name = "label2";
            label2.Size = new Size(31, 15);
            label2.TabIndex = 19;
            label2.Text = "País:";
            // 
            // BtnCancelar
            // 
            BtnCancelar.Image = Properties.Resources.Cancelar;
            BtnCancelar.Location = new Point(381, 104);
            BtnCancelar.Name = "BtnCancelar";
            BtnCancelar.Size = new Size(75, 52);
            BtnCancelar.TabIndex = 17;
            BtnCancelar.Text = "Cancelar";
            BtnCancelar.TextImageRelation = TextImageRelation.ImageAboveText;
            BtnCancelar.UseVisualStyleBackColor = true;
            BtnCancelar.Click += BtnCancelar_Click;
            // 
            // BtnOK
            // 
            BtnOK.Image = Properties.Resources.Aceptar1;
            BtnOK.Location = new Point(42, 104);
            BtnOK.Name = "BtnOK";
            BtnOK.Size = new Size(75, 52);
            BtnOK.TabIndex = 18;
            BtnOK.Text = "OK";
            BtnOK.TextImageRelation = TextImageRelation.ImageAboveText;
            BtnOK.UseVisualStyleBackColor = true;
            BtnOK.Click += BtnOK_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // FrmFiltroPorPais
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(531, 180);
            Controls.Add(CboPaises);
            Controls.Add(label2);
            Controls.Add(BtnCancelar);
            Controls.Add(BtnOK);
            Margin = new Padding(3, 2, 3, 2);
            Name = "FrmFiltroPorPais";
            Text = "FrmFiltroPorPais";
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox CboPaises;
        private Label label2;
        private Button BtnCancelar;
        private Button BtnOK;
        private ErrorProvider errorProvider1;
    }
}