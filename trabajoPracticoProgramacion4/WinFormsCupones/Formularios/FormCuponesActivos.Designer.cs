namespace WinFormsCupones.Formularios
{
    partial class FormCuponesActivos
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
            btnDispoActualizar = new Button();
            dvgCuponesActivos = new DataGridView();
            btnUsarCupon = new Button();
            lblCuponesActivos = new Label();
            ((System.ComponentModel.ISupportInitialize)dvgCuponesActivos).BeginInit();
            SuspendLayout();
            // 
            // btnDispoActualizar
            // 
            btnDispoActualizar.BackColor = Color.FromArgb(192, 192, 255);
            btnDispoActualizar.Font = new Font("Yu Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDispoActualizar.ForeColor = SystemColors.ActiveCaptionText;
            btnDispoActualizar.Location = new Point(649, 479);
            btnDispoActualizar.Name = "btnDispoActualizar";
            btnDispoActualizar.Size = new Size(192, 65);
            btnDispoActualizar.TabIndex = 14;
            btnDispoActualizar.Text = "Actualizar";
            btnDispoActualizar.UseVisualStyleBackColor = false;
            // 
            // dvgCuponesActivos
            // 
            dvgCuponesActivos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dvgCuponesActivos.GridColor = Color.White;
            dvgCuponesActivos.Location = new Point(42, 79);
            dvgCuponesActivos.Name = "dvgCuponesActivos";
            dvgCuponesActivos.RowHeadersWidth = 51;
            dvgCuponesActivos.Size = new Size(1069, 379);
            dvgCuponesActivos.TabIndex = 13;
            // 
            // btnUsarCupon
            // 
            btnUsarCupon.BackColor = Color.FromArgb(192, 192, 255);
            btnUsarCupon.Font = new Font("Yu Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUsarCupon.ForeColor = SystemColors.ActiveCaptionText;
            btnUsarCupon.Location = new Point(257, 479);
            btnUsarCupon.Name = "btnUsarCupon";
            btnUsarCupon.Size = new Size(192, 65);
            btnUsarCupon.TabIndex = 12;
            btnUsarCupon.Text = "Usar Cupón";
            btnUsarCupon.UseVisualStyleBackColor = false;
            btnUsarCupon.Click += btnUsarCupon_Click;
            // 
            // lblCuponesActivos
            // 
            lblCuponesActivos.AutoSize = true;
            lblCuponesActivos.Font = new Font("Yu Gothic", 13.8F);
            lblCuponesActivos.Location = new Point(42, 46);
            lblCuponesActivos.Name = "lblCuponesActivos";
            lblCuponesActivos.Size = new Size(204, 30);
            lblCuponesActivos.TabIndex = 11;
            lblCuponesActivos.Text = "Cupones Activos: ";
            // 
            // FormCuponesActivos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1255, 631);
            Controls.Add(btnDispoActualizar);
            Controls.Add(dvgCuponesActivos);
            Controls.Add(btnUsarCupon);
            Controls.Add(lblCuponesActivos);
            Name = "FormCuponesActivos";
            Text = "FormCuponesActivos";
            ((System.ComponentModel.ISupportInitialize)dvgCuponesActivos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnDispoActualizar;
        private DataGridView dvgCuponesActivos;
        private Button btnUsarCupon;
        private Label lblCuponesActivos;
    }
}