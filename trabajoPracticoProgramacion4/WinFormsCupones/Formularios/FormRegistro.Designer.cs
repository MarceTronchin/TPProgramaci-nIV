namespace WinFormsCupones.Formularios
{
    partial class FormRegistro
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
            txtPassword = new TextBox();
            lblContrasena = new Label();
            btnAltaUsuario = new Button();
            txtNombreUsuario = new TextBox();
            lblNombreUsuario = new Label();
            txtApellido = new TextBox();
            lblApellido = new Label();
            txtNombre = new TextBox();
            label2 = new Label();
            txtMail = new TextBox();
            lblEmail = new Label();
            txtDNI = new TextBox();
            lblDni = new Label();
            SuspendLayout();
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Yu Gothic", 13.8F);
            txtPassword.Location = new Point(254, 129);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(280, 44);
            txtPassword.TabIndex = 9;
            // 
            // lblContrasena
            // 
            lblContrasena.AutoSize = true;
            lblContrasena.Font = new Font("Yu Gothic", 13.8F);
            lblContrasena.Location = new Point(102, 132);
            lblContrasena.Name = "lblContrasena";
            lblContrasena.Size = new Size(135, 30);
            lblContrasena.TabIndex = 8;
            lblContrasena.Text = "Contraseña";
            // 
            // btnAltaUsuario
            // 
            btnAltaUsuario.BackColor = Color.FromArgb(192, 192, 255);
            btnAltaUsuario.Font = new Font("Yu Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAltaUsuario.ForeColor = SystemColors.ActiveCaptionText;
            btnAltaUsuario.Location = new Point(572, 471);
            btnAltaUsuario.Name = "btnAltaUsuario";
            btnAltaUsuario.Size = new Size(281, 65);
            btnAltaUsuario.TabIndex = 7;
            btnAltaUsuario.Text = "Alta Nuevo Usuario";
            btnAltaUsuario.UseVisualStyleBackColor = false;
            btnAltaUsuario.Click += btnAltaUsuario_Click;
            // 
            // txtNombreUsuario
            // 
            txtNombreUsuario.Font = new Font("Yu Gothic", 13.8F);
            txtNombreUsuario.Location = new Point(254, 65);
            txtNombreUsuario.Name = "txtNombreUsuario";
            txtNombreUsuario.Size = new Size(280, 44);
            txtNombreUsuario.TabIndex = 6;
            // 
            // lblNombreUsuario
            // 
            lblNombreUsuario.AutoSize = true;
            lblNombreUsuario.Font = new Font("Yu Gothic", 13.8F);
            lblNombreUsuario.Location = new Point(51, 68);
            lblNombreUsuario.Name = "lblNombreUsuario";
            lblNombreUsuario.Size = new Size(186, 30);
            lblNombreUsuario.TabIndex = 5;
            lblNombreUsuario.Text = "Nombre Usuario";
            // 
            // txtApellido
            // 
            txtApellido.Font = new Font("Yu Gothic", 13.8F);
            txtApellido.Location = new Point(254, 264);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(280, 44);
            txtApellido.TabIndex = 13;
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Font = new Font("Yu Gothic", 13.8F);
            lblApellido.Location = new Point(139, 267);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(98, 30);
            lblApellido.TabIndex = 12;
            lblApellido.Text = "Apellido";
            // 
            // txtNombre
            // 
            txtNombre.Font = new Font("Yu Gothic", 13.8F);
            txtNombre.Location = new Point(254, 194);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(280, 44);
            txtNombre.TabIndex = 11;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Yu Gothic", 13.8F);
            label2.Location = new Point(140, 197);
            label2.Name = "label2";
            label2.Size = new Size(97, 30);
            label2.TabIndex = 10;
            label2.Text = "Nombre";
            // 
            // txtMail
            // 
            txtMail.Font = new Font("Yu Gothic", 13.8F);
            txtMail.Location = new Point(254, 405);
            txtMail.Name = "txtMail";
            txtMail.Size = new Size(280, 44);
            txtMail.TabIndex = 17;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Yu Gothic", 13.8F);
            lblEmail.Location = new Point(165, 408);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(72, 30);
            lblEmail.TabIndex = 16;
            lblEmail.Text = "Email";
            // 
            // txtDNI
            // 
            txtDNI.Font = new Font("Yu Gothic", 13.8F);
            txtDNI.Location = new Point(254, 335);
            txtDNI.Name = "txtDNI";
            txtDNI.Size = new Size(280, 44);
            txtDNI.TabIndex = 15;
            // 
            // lblDni
            // 
            lblDni.AutoSize = true;
            lblDni.Font = new Font("Yu Gothic", 13.8F);
            lblDni.Location = new Point(183, 338);
            lblDni.Name = "lblDni";
            lblDni.Size = new Size(54, 30);
            lblDni.TabIndex = 14;
            lblDni.Text = "DNI";
            // 
            // FormRegistro
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(940, 591);
            Controls.Add(txtMail);
            Controls.Add(lblEmail);
            Controls.Add(txtDNI);
            Controls.Add(lblDni);
            Controls.Add(txtApellido);
            Controls.Add(lblApellido);
            Controls.Add(txtNombre);
            Controls.Add(label2);
            Controls.Add(txtPassword);
            Controls.Add(lblContrasena);
            Controls.Add(btnAltaUsuario);
            Controls.Add(txtNombreUsuario);
            Controls.Add(lblNombreUsuario);
            Name = "FormRegistro";
            Text = "FormRegistro";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtPassword;
        private Label lblContrasena;
        private Button btnAltaUsuario;
        private TextBox txtNombreUsuario;
        private Label lblNombreUsuario;
        private TextBox txtApellido;
        private Label lblApellido;
        private TextBox txtNombre;
        private Label label2;
        private TextBox txtMail;
        private Label lblEmail;
        private TextBox txtDNI;
        private Label lblDni;
    }
}