namespace WinFormsCupones.Formularios
{
    partial class FormReportes
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
            btnVerReporte = new Button();
            dvgReportes = new DataGridView();
            lblTipoReporte = new Label();
            cmbTipoReporte = new ComboBox();
            pickFechaDesde = new DateTimePicker();
            lblFechaDesde = new Label();
            lblFechaHasta = new Label();
            pickFechaHasta = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)dvgReportes).BeginInit();
            SuspendLayout();
            // 
            // btnVerReporte
            // 
            btnVerReporte.BackColor = Color.FromArgb(192, 192, 255);
            btnVerReporte.Font = new Font("Yu Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnVerReporte.ForeColor = SystemColors.ActiveCaptionText;
            btnVerReporte.Location = new Point(1007, 541);
            btnVerReporte.Name = "btnVerReporte";
            btnVerReporte.Size = new Size(192, 65);
            btnVerReporte.TabIndex = 18;
            btnVerReporte.Text = "Ver Reporte";
            btnVerReporte.UseVisualStyleBackColor = false;
            // 
            // dvgReportes
            // 
            dvgReportes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dvgReportes.GridColor = Color.White;
            dvgReportes.Location = new Point(29, 135);
            dvgReportes.Name = "dvgReportes";
            dvgReportes.RowHeadersWidth = 51;
            dvgReportes.Size = new Size(1069, 379);
            dvgReportes.TabIndex = 17;
            // 
            // lblTipoReporte
            // 
            lblTipoReporte.AutoSize = true;
            lblTipoReporte.Font = new Font("Yu Gothic", 13.8F);
            lblTipoReporte.Location = new Point(39, 21);
            lblTipoReporte.Name = "lblTipoReporte";
            lblTipoReporte.Size = new Size(311, 30);
            lblTipoReporte.TabIndex = 15;
            lblTipoReporte.Text = "Seleccione Tipo de Reporte:";
            // 
            // cmbTipoReporte
            // 
            cmbTipoReporte.Font = new Font("Microsoft JhengHei", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbTipoReporte.FormattingEnabled = true;
            cmbTipoReporte.Location = new Point(356, 21);
            cmbTipoReporte.Name = "cmbTipoReporte";
            cmbTipoReporte.Size = new Size(376, 33);
            cmbTipoReporte.TabIndex = 20;
            // 
            // pickFechaDesde
            // 
            pickFechaDesde.Location = new Point(215, 77);
            pickFechaDesde.Name = "pickFechaDesde";
            pickFechaDesde.Size = new Size(302, 27);
            pickFechaDesde.TabIndex = 21;
            // 
            // lblFechaDesde
            // 
            lblFechaDesde.AutoSize = true;
            lblFechaDesde.Font = new Font("Yu Gothic", 13.8F);
            lblFechaDesde.Location = new Point(39, 77);
            lblFechaDesde.Name = "lblFechaDesde";
            lblFechaDesde.Size = new Size(95, 30);
            lblFechaDesde.TabIndex = 22;
            lblFechaDesde.Text = "Desde: ";
            // 
            // lblFechaHasta
            // 
            lblFechaHasta.AutoSize = true;
            lblFechaHasta.Font = new Font("Yu Gothic", 13.8F);
            lblFechaHasta.Location = new Point(563, 79);
            lblFechaHasta.Name = "lblFechaHasta";
            lblFechaHasta.Size = new Size(90, 30);
            lblFechaHasta.TabIndex = 24;
            lblFechaHasta.Text = "Hasta: ";
            // 
            // pickFechaHasta
            // 
            pickFechaHasta.Location = new Point(739, 79);
            pickFechaHasta.Name = "pickFechaHasta";
            pickFechaHasta.Size = new Size(302, 27);
            pickFechaHasta.TabIndex = 23;
            // 
            // FormReportes
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1256, 629);
            Controls.Add(lblFechaHasta);
            Controls.Add(pickFechaHasta);
            Controls.Add(lblFechaDesde);
            Controls.Add(pickFechaDesde);
            Controls.Add(cmbTipoReporte);
            Controls.Add(btnVerReporte);
            Controls.Add(dvgReportes);
            Controls.Add(lblTipoReporte);
            Name = "FormReportes";
            Text = "FormReportes";
            Load += FormReportes_Load;
            ((System.ComponentModel.ISupportInitialize)dvgReportes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnVerReporte;
        private DataGridView dvgReportes;
        private Label lblTipoReporte;
        private ComboBox cmbTipoReporte;
        private DateTimePicker pickFechaDesde;
        private Label lblFechaDesde;
        private Label lblFechaHasta;
        private DateTimePicker pickFechaHasta;
    }
}