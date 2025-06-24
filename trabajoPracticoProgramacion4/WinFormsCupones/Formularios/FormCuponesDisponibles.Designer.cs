namespace WinFormsCupones.Formularios
{
    partial class FormCuponesDisponibles
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
            btnReclamar = new Button();
            dgvDiponibles = new DataGridView();
            btnActualizar = new Button();
            lblCuponesDispo = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvDiponibles).BeginInit();
            SuspendLayout();
            // 
            // btnReclamar
            // 
            btnReclamar.BackColor = Color.FromArgb(192, 192, 255);
            btnReclamar.Font = new Font("Yu Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReclamar.ForeColor = SystemColors.ActiveCaptionText;
            btnReclamar.Location = new Point(242, 477);
            btnReclamar.Name = "btnReclamar";
            btnReclamar.Size = new Size(192, 65);
            btnReclamar.TabIndex = 7;
            btnReclamar.Text = "Reclamar";
            btnReclamar.UseVisualStyleBackColor = false;
            btnReclamar.Click += btnReclamar_Click;
            // 
            // dgvDiponibles
            // 
            dgvDiponibles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDiponibles.GridColor = Color.White;
            dgvDiponibles.Location = new Point(27, 77);
            dgvDiponibles.Name = "dgvDiponibles";
            dgvDiponibles.RowHeadersWidth = 51;
            dgvDiponibles.Size = new Size(1069, 379);
            dgvDiponibles.TabIndex = 9;
            dgvDiponibles.CellContentClick += this.dvgCupones_CellContentClick;
            // 
            // btnActualizar
            // 
            btnActualizar.BackColor = Color.FromArgb(192, 192, 255);
            btnActualizar.Font = new Font("Yu Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnActualizar.ForeColor = SystemColors.ActiveCaptionText;
            btnActualizar.Location = new Point(634, 477);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(192, 65);
            btnActualizar.TabIndex = 10;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = false;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // lblCuponesDispo
            // 
            lblCuponesDispo.AutoSize = true;
            lblCuponesDispo.Font = new Font("Yu Gothic", 13.8F);
            lblCuponesDispo.Location = new Point(27, 44);
            lblCuponesDispo.Name = "lblCuponesDispo";
            lblCuponesDispo.Size = new Size(251, 30);
            lblCuponesDispo.TabIndex = 5;
            lblCuponesDispo.Text = "Cupones Disponibles: ";
            lblCuponesDispo.Click += lblCuponesDispo_Click;
            // 
            // FormCuponesDisponibles
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1122, 602);
            Controls.Add(btnActualizar);
            Controls.Add(dgvDiponibles);
            Controls.Add(btnReclamar);
            Controls.Add(lblCuponesDispo);
            Name = "FormCuponesDisponibles";
            Text = "FormCuponesDisponibles";
            Load += FormCuponesDisponibles_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDiponibles).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnReclamar;
        private DataGridView dgvDiponibles;
        private Button btnActualizar;
        private Label lblCuponesDispo;
    }
}