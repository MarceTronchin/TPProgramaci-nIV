using System;
using System.Windows.Forms;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;
using WinFormsCupones.Formularios;

namespace WinFormsCupones
{
    public partial class FormLogin : Form
    {

        private readonly HttpClient _httpClient;

        public static string Token { get; set; }
        public static int IdUsuario { get; set; }
        public static string RolUsuario { get; set; }


        public FormLogin(HttpClient httpClient)
        {
            InitializeComponent();
            this._httpClient = httpClient;
        }

        /* private void Form1_Load(object sender, EventArgs e)
         {
             btnIngresar.Enabled = true;
         }*/
        private async void btnIngresar_Click(object sender, EventArgs e)
        {
            var nombreUsuario = textBox1.Text;
            var contrasena = textBox2.Text;

            if (string.IsNullOrWhiteSpace(nombreUsuario) || string.IsNullOrWhiteSpace(contrasena))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            var loginDatos = new
            {
                User_Name = nombreUsuario,
                Password = contrasena
            };

            var json = JsonSerializer.Serialize(loginDatos);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                // Realizar la solicitud POST al endpoint de autenticación
                var response = await _httpClient.PostAsync("https://localhost:44324/api/Auth/Login", content);

                if (response.IsSuccessStatusCode)
                {
                    // Leer la respuesta y extraer el token
                    var responseContent = await response.Content.ReadAsStringAsync();

                    /////////////
                    using var doc = JsonDocument.Parse(responseContent);
                    Token = doc.RootElement.GetProperty("token").GetString();
                    IdUsuario = doc.RootElement.GetProperty("idUsuario").GetInt32();
                    RolUsuario = doc.RootElement.GetProperty("rolUsuario").GetString();

                    MessageBox.Show("Inicio de sesión exitoso.");

                    //ya logueado voy al menú principal

                    var menuPrincipal = new FormMenuPrincipal();
                    menuPrincipal.Show(); // Mostrar el formulario del menú principal
                    this.Hide(); // Ocultar el formulario de inicio de sesión sin cerrar
                }
                else
                {
                    MessageBox.Show("Error al iniciar sesión. Verifique sus credenciales.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de conexión al servidor. Por favor, intente más tarde." + ex.Message);
            }
        }

    }
}
