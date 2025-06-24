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
    public partial class FormCuponesDisponibles : Form
    {
        private readonly HttpClient _httpClient = new HttpClient();

        public FormCuponesDisponibles()
        {
            InitializeComponent();
            this.Text = "Cupones Disponibles";
        }


        private async void CuponesDisponiblesForm_Load(object sender, EventArgs e)
        {
            await CargarCupones();
        }

        private async Task CargarCupones()
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization =
                       new AuthenticationHeaderValue("Bearer", FormLogin.Token);

                var response = await _httpClient.GetAsync($"https://localhost:5001/api/cupon/disponibles/{FormLogin.IdUsuario}");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var cupones = JsonSerializer.Deserialize<List<CuponDto>>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                    dgvDiponibles.DataSource = cupones;
                }
                else
                {
                    MessageBox.Show("Error al obtener los cupones.", "Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de conexión: " + ex.Message);
            }
        }

        private async void btnReclamar_Click(object sender, EventArgs e)
        {
            if (dgvDiponibles.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un cupón para reclamar.");
                return;
            }
            string nroCupon = dgvDiponibles.CurrentRow.Cells["NroCupon"].Value.ToString();

            var dto = new
            {
                IdUsuario = FormLogin.IdUsuario,
                NroCupon = nroCupon
            };

            var json = JsonSerializer.Serialize(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", FormLogin.Token);

                var response = await _httpClient.PostAsync("https://localhost:5001/api/cupon/reclamar", content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Cupón reclamado correctamente.");
                    await CargarCupones(); // recargar lista
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    MessageBox.Show("Error al reclamar: " + error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de conexión: " + ex.Message);
            }
        }

        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            await CargarCupones();
        }

        // DTO local para mostrar cupones
        public class CuponDto
        {
            public string NroCupon { get; set; }
            public string Nombre { get; set; }
            public string Descripcion { get; set; }
            public decimal? PorcentajeDto { get; set; }
            public decimal? ImportePromo { get; set; }
            public DateTime FechaInicio { get; set; }
            public DateTime FechaFin { get; set; }
        }

        private void FormCuponesDisponibles_Load(object sender, EventArgs e)
        {

        }

        private void lblCuponesDispo_Click(object sender, EventArgs e)
        {

        }
    }
}

