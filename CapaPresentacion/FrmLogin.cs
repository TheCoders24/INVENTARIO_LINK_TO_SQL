using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load_1(object sender, EventArgs e)
        {
            // Configuración inicial del formulario (opcional)
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = System.Drawing.Color.FromArgb(24, 30, 54);  // Fondo oscuro
            this.Size = new System.Drawing.Size(400, 350);

          
        }
        // Método que maneja el evento Click del botón Login
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Validación de usuario y contraseña
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                lblError.Text = "Please enter both username and password!";
                lblError.Visible = true;
            }
            else
            {
                // Aquí puedes verificar las credenciales en tu base de datos o lógica de autenticación
                lblError.Visible = false;
                MessageBox.Show("Login Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Método que maneja el evento Click del botón Clear
        private void btnClear_Click(object sender, EventArgs e)
        {
            // Limpiar los campos de texto
            txtUsername.Clear();
            txtPassword.Clear();
            lblError.Visible = false;  // Ocultar cualquier mensaje de error
        }

        // Método que maneja el evento Click del botón Exit
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();  // Cerrar la aplicación
        }
    }
}

