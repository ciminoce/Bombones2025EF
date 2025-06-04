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
            CboPaises.Location = new Point(139, 48);
            CboPaises.Margin = new Padding(3, 4, 3, 4);
            CboPaises.Name = "CboPaises";
            CboPaises.Size = new Size(390, 28);
            CboPaises.TabIndex = 20;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(53, 49);
            label2.Name = "label2";
            label2.Size = new Size(37, 20);
            label2.TabIndex = 19;
            label2.Text = "País:";
            // 
            // BtnCancelar
            // 
            BtnCancelar.Image = Properties.Resources.Cancelar;
            BtnCancelar.Location = new Point(435, 138);
            BtnCancelar.Margin = new Padding(3, 4, 3, 4);
            BtnCancelar.Name = "BtnCancelar";
            BtnCancelar.Size = new Size(86, 69);
            BtnCancelar.TabIndex = 17;
            BtnCancelar.Text = "Cancelar";
            BtnCancelar.TextImageRelation = TextImageRelation.ImageAboveText;
            BtnCancelar.UseVisualStyleBackColor = true;
            // 
            // BtnOK
            // 
            BtnOK.Image = Properties.Resources.Aceptar1;
            BtnOK.Location = new Point(48, 138);
            BtnOK.Margin = new Padding(3, 4, 3, 4);
            BtnOK.Name = "BtnOK";
            BtnOK.Size = new Size(86, 69);
            BtnOK.TabIndex = 18;
            BtnOK.Text = "OK";
            BtnOK.TextImageRelation = TextImageRelation.ImageAboveText;
            BtnOK.UseVisualStyleBackColor = true;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // FrmFiltroPorPais
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(607, 240);
            Controls.Add(CboPaises);
            Controls.Add(label2);
            Controls.Add(BtnCancelar);
            Controls.Add(BtnOK);
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