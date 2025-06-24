using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsCupones.Formularios
{
    public partial class FormCuponesActivos : Form
    {
        private readonly HttpClient _httpClient = new HttpClient();

        public FormCuponesActivos()
        {
            InitializeComponent();
            this.Text = "Cupones Activos Reclamados";
        }



        private async void CuponesActivosForm_Load(object sender, EventArgs e)
        {
            await CargarCuponesActivos();
        }

        private async Task CargarCuponesActivos()
        {
             try
             {
                 _httpClient.DefaultRequestHeaders.Authorization =
                 new AuthenticationHeaderValue("Bearer", FormLogin.Token);

                var response = await _httpClient.GetAsync($"https://localhost:5001/api/cuponcliente/activos/{FormLogin.IdUsuario}");

                    if (response.IsSuccessStatusCode)
                    {
                        var json = await response.Content.ReadAsStringAsync();
                        var cupones = JsonSerializer.Deserialize<List<CuponClienteDto>>(json,
                            new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                    dvgCuponesActivos.DataSource = cupones;

                    }
                    else
                    {
                        MessageBox.Show("Error al obtener cupones activos.", "Error");
                    }
                }
                    catch (Exception ex)
                {
                    MessageBox.Show("Error de conexión: " + ex.Message);
                }
             }

            private async void btnUsarCupon_Click(object sender, EventArgs e)
            {
                if (dvgCuponesActivos.CurrentRow == null)
                {
                    MessageBox.Show("Seleccione un cupón para usar.");
                    return;
                }

                int idCupon = Convert.ToInt32(dvgCuponesActivos.CurrentRow.Cells["Id_Cupon"].Value);
                string nroCupon = dvgCuponesActivos.CurrentRow.Cells["NroCupon"].Value.ToString();

                var dto = new
                {
                    IdUsuario = FormLogin.IdUsuario,
                    Id_Cupon = idCupon,
                    NroCupon = nroCupon
                };

                var json = JsonSerializer.Serialize(dto);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                try
                {
                    _httpClient.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", FormLogin.Token);

                    var response = await _httpClient.PostAsync("https://localhost:5001/api/cuponhistorial", content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Cupón usado correctamente.");
                        await CargarCuponesActivos();
                    }
                    else
                    {
                        var error = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Error al usar cupón: " + error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error de conexión: " + ex.Message);
                }
            }

            private async void btnActualizar_Click(object sender, EventArgs e)
            {
                await CargarCuponesActivos();
            }
        }

    // DTO local para mostrar cupones activos reclamados
        public class CuponClienteDto
        {
            public int Id_Cupon { get; set; }
            public string NroCupon { get; set; }
            public string Nombre { get; set; }
            public string Descripcion { get; set; }
            public DateTime FechaInicio { get; set; }
            public DateTime FechaFin { get; set; }
        }
}

