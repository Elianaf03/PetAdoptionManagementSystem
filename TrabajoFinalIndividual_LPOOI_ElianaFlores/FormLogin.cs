using Controller;
using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrabajoFinalIndividual_LPOOI_ElianaFlores
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Logout(object sender, FormClosedEventArgs e)
        {
            this.txtUsuario.Text = "";
            this.txtPassword.Text = "";
            this.txtPassword.UseSystemPasswordChar = false;
            this.lblMsjError.Visible = false;
            this.Show();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUsuario.Text != "" && txtUsuario.Text.Length > 2)
                {
                    if (txtPassword.Text != "")
                    {
                        UsuarioController login = new UsuarioController();

                        bool validarLogin = login.Login(this.txtUsuario.Text, this.txtPassword.Text);
                        if (validarLogin)
                        {
                            FormInicio fi = new FormInicio();
                            FormCircleProgressBar progressBar = new FormCircleProgressBar("Bienvenido " + UsuarioCache.Nombre + " " + UsuarioCache.Apellido);
                            progressBar.ShowDialog();
                            fi.Show();

                            fi.FormClosed += Logout;
                            this.Hide();
                        }
                        else
                        {
                            lblMsjError.Visible = true;
                        }
                    }
                    else
                    {
                        lblMsjError.Text = "Debe ingresar Contraseña";
                        lblMsjError.Visible = true;
                    }
                }
                else
                {
                    lblMsjError.Text = "Debe ingresar Usuario y Contraseña";
                    lblMsjError.Visible = true;
                }
            }
            catch (Exception er)
            {

                MessageBox.Show("Error " + er.Message, "Atencion",
                     MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void chbMostrarContraseña_CheckedChanged(object sender, EventArgs e)
        {
            if (chbMostrarContraseña.Checked == true)
            {
                this.txtPassword.UseSystemPasswordChar = false;
                this.chbMostrarContraseña.Text = "Ocultar contraseña";
            }
            else
            {
                this.txtPassword.UseSystemPasswordChar = true;
                this.chbMostrarContraseña.Text = "Mostrar contraseña";
            }
        }

        // agregamos las librerias necesarias para poder mover la ventana
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")] private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")] private extern static void SendMessage(System.IntPtr hwnd, int wmsj, int wparm, int lparm);

        private void gunaGradientPanel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
