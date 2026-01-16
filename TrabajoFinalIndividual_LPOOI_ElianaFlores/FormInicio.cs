using Entities;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrabajoFinalIndividual_LPOOI_ElianaFlores
{
    public partial class FormInicio : Form
    {
        private IconButton botonActual;
        private Panel bordeIzquierdoBoton;
        private Form formularioActualHijo;
        public FormInicio()
        {
            InitializeComponent();
            bordeIzquierdoBoton = new Panel();
            bordeIzquierdoBoton.Size = new Size(7, 60);
            panelMenu.Controls.Add(bordeIzquierdoBoton);
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            cargarUsuarioActual();
            if (UsuarioCache.Rol == "Voluntario")
            {
                this.btnApadrinados.Visible = false;
            }
            else
            {
                if (UsuarioCache.Rol == "Adoptante")
                {
                    this.btnUsuarios.Visible = false;
                    btnAdopciones.Text = "Tus adopciones";
                    btnVisitas.Text = "Tus visitas";
                }
            }
        }

        private void cargarUsuarioActual()
        {
            this.lblUsuarioActual.Text = UsuarioCache.LoginName;
            this.lblRolUsuario.Text = UsuarioCache.Rol;
            this.pbFotoUsuario.Image = bytesToImage(UsuarioCache.Foto);
        }

        //Convierte Imagen a byte[]
        private byte[] imageToBytes(PictureBox pbxFoto)
        {
            MemoryStream ms = new System.IO.MemoryStream();
            pbxFoto.Image.Save(ms, ImageFormat.Png);
            byte[] imagenByte = ms.ToArray();
            return imagenByte;
        }
        //Convierte Byte a Imagen
        public Image bytesToImage(byte[] imagenByte)
        {
            MemoryStream ms = new MemoryStream(imagenByte);
            Image foto = Image.FromStream(ms);

            return foto;
        }

        private void ActivarBoton(object senderBtn)
        {
            if (senderBtn != null)
            {
                DisableBoton();
                this.botonActual = (IconButton)senderBtn;
                this.botonActual.TextAlign = ContentAlignment.MiddleCenter;
                this.botonActual.TextImageRelation = TextImageRelation.ImageBeforeText;
                this.botonActual.ImageAlign = ContentAlignment.MiddleRight;
                this.bordeIzquierdoBoton.Location = new Point(0, botonActual.Location.Y);
                this.bordeIzquierdoBoton.Visible = true;
                this.bordeIzquierdoBoton.BringToFront();

                this.iconActualHijoDeFormulario.IconChar = botonActual.IconChar;
            }
        }

        private void DisableBoton()
        {
            if (botonActual != null)
            {
                //this.botonActual.BackColor = Color.FromArgb(0, 0, 64);
                this.botonActual.ForeColor = Color.White;
                this.botonActual.TextAlign = ContentAlignment.MiddleLeft;
                this.botonActual.IconColor = Color.White;
                this.botonActual.TextImageRelation = TextImageRelation.TextBeforeImage;
                this.botonActual.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        //Metodo para colocar los formularios en el panel central
        private void AbrirFormularioHijo(Form formHijo)
        {
            if (formularioActualHijo != null)
            {
                formularioActualHijo.Close();
            }
            formularioActualHijo = formHijo;
            formHijo.TopLevel = false;
            formHijo.FormBorderStyle = FormBorderStyle.None;
            panelCentral.Controls.Add(formHijo);
            panelCentral.Tag = formHijo;
            formHijo.BringToFront();
            formHijo.Show();
            this.lblTituloDeFormularioHijo.Text = formHijo.Text;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnPrincipal_Click(object sender, EventArgs e)
        {
            ActivarBoton(sender);
            AbrirFormularioHijo(new FormPrincipal());
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            ActivarBoton(sender);
            AbrirFormularioHijo(new FormUsuario());
        }

        private void btnMascotas_Click(object sender, EventArgs e)
        {
            ActivarBoton(sender);
            AbrirFormularioHijo(new Mascotas());
        }

        private void btnAdopciones_Click(object sender, EventArgs e)
        {
            ActivarBoton(sender);
            if (UsuarioCache.Rol == "Administrador")
            {
                AbrirFormularioHijo(new FormAdopciones());
            }
            else
            {
                AbrirFormularioHijo(new FormAdopcionVyA());
            }
        }

        private void btnApadrinados_Click(object sender, EventArgs e)
        {
            ActivarBoton(sender);
            if (UsuarioCache.Rol == "Administrador")
            {
                AbrirFormularioHijo(new FormApadrinadosAdm());
            }
            else
            {
                AbrirFormularioHijo(new FormApadrinados());
            }
        }

        private void btnVisitas_Click(object sender, EventArgs e)
        {
            ActivarBoton(sender);
            AbrirFormularioHijo(new FormVisitas());
        }
    }
}
