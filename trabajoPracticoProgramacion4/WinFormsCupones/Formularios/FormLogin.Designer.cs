namespace WinFormsCupones
{
    partial class FormLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblUsuario = new Label();
            textBox1 = new TextBox();
            btnIngresar = new Button();
            textBox2 = new TextBox();
            lblContrasena = new Label();
            SuspendLayout();
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new Font("Yu Gothic", 13.8F);
            lblUsuario.Location = new Point(129, 77);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(95, 30);
            lblUsuario.TabIndex = 0;
            lblUsuario.Text = "Usuario";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Yu Gothic", 13.8F);
            textBox1.Location = new Point(302, 74);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(280, 44);
            textBox1.TabIndex = 1;
            // 
            // btnIngresar
            // 
            btnIngresar.BackColor = Color.FromArgb(192, 192, 255);
            btnIngresar.Font = new Font("Yu Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnIngresar.ForeColor = SystemColors.ActiveCaptionText;
            btnIngresar.Location = new Point(241, 289);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(192, 65);
            btnIngresar.TabIndex = 2;
            btnIngresar.Text = "Ingresar";
            btnIngresar.UseVisualStyleBackColor = false;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Yu Gothic", 13.8F);
            textBox2.Location = new Point(302, 162);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(280, 44);
            textBox2.TabIndex = 4;
            // 
            // lblContrasena
            // 
            lblContrasena.AutoSize = true;
            lblContrasena.Font = new Font("Yu Gothic", 13.8F);
            lblContrasena.Location = new Point(129, 165);
            lblContrasena.Name = "lblContrasena";
            lblContrasena.Size = new Size(135, 30);
            lblContrasena.TabIndex = 3;
            lblContrasena.Text = "Contraseña";
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(textBox2);
            Controls.Add(lblContrasena);
            Controls.Add(btnIngresar);
            Controls.Add(textBox1);
            Controls.Add(lblUsuario);
            Name = "FormLogin";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblUsuario;
        private TextBox textBox1;
        private Button btnIngresar;
        private TextBox textBox2;
        private Label lblContrasena;
    }
}
