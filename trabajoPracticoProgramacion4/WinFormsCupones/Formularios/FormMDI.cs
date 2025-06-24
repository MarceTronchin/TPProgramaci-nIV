using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsCupones.Formularios
{
    public partial class FormMDI : Form
    {
        public FormMDI()
        {
            InitializeComponent();
            this.Text = "Menú Principal";

            lblBienvenida.Text = $"Bienvenido, Rol: {FormLogin.RolUsuario}";

            // Mostrar u ocultar botones según rol
            if (FormLogin.RolUsuario == "Cliente")
            {
                btnVerCupones.Visible = true;
                btnUsarCupon.Visible = true;
                btnReportes.Visible = false;
            }
            else if (FormLogin.RolUsuario == "Auditor" || FormLogin.RolUsuario == "Admin")
            {
                btnVerCupones.Visible = false;
                btnUsarCupon.Visible = false;
                btnReportes.Visible = true;
            }

            // Eventos
            btnVerCupones.Click += (s, e) => new FormCuponesDisponibles().ShowDialog();
            btnUsarCupon.Click += (s, e) => new FormCuponesActivos().ShowDialog();
            btnReportes.Click += (s, e) => new FormReportes().ShowDialog();

            btnCerrarSesion.Click += (s, e) =>
            {
                FormLogin.Token = null;
                FormLogin.IdUsuario = 0;
                FormLogin.RolUsuario = null;
                this.Hide();
               // new FormLogin().Show();
                };
            }
        }
    }