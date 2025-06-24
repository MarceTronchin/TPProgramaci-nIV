using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsCupones.Formularios
{
    public partial class FormReportes : Form
    {
        private readonly HttpClient _httpClient = new HttpClient();

        public FormReportes()
        {
            InitializeComponent();
            this.Text = "Reportes";

            cmbTipoReporte.Items.Add("Cupones más usados");
            cmbTipoReporte.Items.Add("Cupones más reclamados");
            cmbTipoReporte.Items.Add("Cupones usados en rango de fechas");
            cmbTipoReporte.Items.Add("Artículos más usados");

            cmbTipoReporte.SelectedIndexChanged += cmbReportes_SelectedIndexChanged;
            btnVerReporte.Click += async (s, e) => await ObtenerReporte();
        }

        private void cmbReportes_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool rango = cmbTipoReporte.SelectedItem.ToString().Contains("rango");
            pickFechaDesde.Visible = rango;
            pickFechaHasta.Visible = rango;
        }

        private async Task ObtenerReporte()
        {
            if (cmbTipoReporte.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un tipo de reporte.");
                return;
            }

            string endpoint = "";
            switch (cmbTipoReporte.SelectedItem.ToString())
            {
                case "Cupones más usados":
                    endpoint = "/api/reportes/mas-usados";
                    break;
                case "Cupones más reclamados":
                    endpoint = "/api/reportes/mas-reclamados";
                    break;
                case "Cupones usados en rango de fechas":
                    string desde = pickFechaDesde.Value.ToString("yyyy-MM-dd");
                    string hasta = pickFechaHasta.Value.ToString("yyyy-MM-dd");
                    endpoint = $"/api/reportes/usados-rango?desde={desde}&hasta={hasta}";
                    break;
                case "Artículos más usados":
                    endpoint = "/api/reportes/articulos-mas-usados";
                    break;
            }

            try
            {
                _httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", FormLogin.Token);

                var response = await _httpClient.GetAsync("https://localhost:5001" + endpoint);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var data = JsonSerializer.Deserialize<object>(json, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    dvgReportes.DataSource = null;
                    dvgReportes.DataSource = data;
                }
                else
                {
                    MessageBox.Show("Error al obtener reporte.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de conexión: " + ex.Message);
            }
        }

        private void FormReportes_Load(object sender, EventArgs e)
        {

        }
    }
}
