using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsCupones.Formularios
{
    public partial class FormRegistro : Form
    {
        private readonly HttpClient _httpClient = new HttpClient();

        public FormRegistro()
        {
            InitializeComponent();
            this.Text = "Registro de Usuario";
        }


        private async void btnAltaUsuario_Click(object sender, EventArgs e)
        {
            // Obtener los datos del formulario
            var username = txtNombre.Text.Trim();
            var password = txtPassword.Text;
            var nombre = txtNombreUsuario.Text.Trim();
            var apellido = txtApellido.Text.Trim();
            var dni = txtDNI.Text.Trim();
            var email = txtMail.Text.Trim();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(apellido) ||
                string.IsNullOrWhiteSpace(dni) || string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Todos los campos son requeridos.");
                return;
            }

            var nuevoUsuario = new
            {
                User_Name = username,
                Password = password,
                Nombre = nombre,
                Apellido = apellido,
                Dni = dni,
                Email = email,
                Estado = true,
                Id_Rol = 2 // cliente
            };

            var json = JsonSerializer.Serialize(nuevoUsuario);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = await _httpClient.PostAsync("https://localhost:5001/api/auth/registro", content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Registro exitoso. Ahora puede iniciar sesión.", "Éxito");
                    this.Close();
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    MessageBox.Show("Error en el registro: " + error, "Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de conexión: " + ex.Message, "Error");
            }
        }

    }
}
