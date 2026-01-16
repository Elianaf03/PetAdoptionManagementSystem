using Controller;
using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrabajoFinalIndividual_LPOOI_ElianaFlores
{
    public partial class FormUsuario : Form
    {
        string direImagen;
        UsuarioController usuarioController = new UsuarioController();
        public FormUsuario()
        {
            InitializeComponent();
            ListarUsuarios();
        }

        private void ListarUsuarios()
        {
            if (UsuarioCache.Rol == "Voluntario")
            {
                btnReporte.Visible = false;
                cmbRol.Text = "Adoptante";
                cmbRol.Enabled = false;
                this.dgvUsuarios.DataSource = usuarioController.ListarUsuariosAdoptantes("Adoptante");
            }
            else
            {
                this.dgvUsuarios.DataSource = usuarioController.ListarUsuarios("");
            }
        }
        private void Limpiar()
        {
            this.lblIdUsuario.Text = "0";
            this.txtNombre.Text = "";
            this.txtApellido.Text = "";
            this.txtDni.Text = "";
            this.txtTelefono.Text = "";
            this.txtCorreo.Text = "";
            this.txtDireccion.Text = "";
            this.txtLoginName.Text = "";
            this.txtPassword.Text = "";
            this.cmbRol.Text = "";
            this.pbFotoUsuario.Image = global::TrabajoFinalIndividual_LPOOI_ElianaFlores.Properties.Resources.pngwing_com;
            this.btnAgregar.Enabled = true;
        }
        private void btnCambiarFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Archivos de imágen (.jpg)|*.jpg|PNG(*.png)|*.png|All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.Multiselect = true;
            DialogResult rs = openFileDialog1.ShowDialog();

            if (rs == DialogResult.OK)
            {
                this.pbFotoUsuario.BackgroundImage = null;
                direImagen = openFileDialog1.FileName.ToString();

                this.pbFotoUsuario.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                MemoryStream ms = new MemoryStream();
                if (this.pbFotoUsuario.Image != null & this.txtNombre.Text != "" & this.txtApellido.Text != "")
                {
                    this.pbFotoUsuario.Image.Save(ms, ImageFormat.Png);
                    byte[] pic = ms.ToArray();

                    Usuario usu = new Usuario();
                    usu.Nombre = this.txtNombre.Text;
                    usu.Apellido = this.txtApellido.Text;
                    usu.Dni = Convert.ToInt32(this.txtDni.Text);
                    usu.Telefono = long.Parse(this.txtTelefono.Text);
                    usu.Correo = this.txtCorreo.Text;                
                    usu.Direccion = this.txtDireccion.Text;
                    usu.LoginName = this.txtLoginName.Text;
                    usu.Password = this.txtPassword.Text;
                    usu.Rol = this.cmbRol.Text;
                    usu.Foto = pic;

                    usuarioController.AgregarUsuario(usu);
                    MessageBox.Show("Datos Guardados correctamente ", "Confirmado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ListarUsuarios();
                    Limpiar();
                }
                else
                {
                    MessageBox.Show("Verifique los datos ingresados ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("error al guardar " + ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                MemoryStream ms = new MemoryStream();/* una fomra de hacerlo*/
                if (this.pbFotoUsuario.Image != null & this.txtNombre.Text != "" & this.txtApellido.Text != "")
                {
                    this.pbFotoUsuario.Image.Save(ms, ImageFormat.Png);
                    byte[] pic = ms.ToArray();

                    Usuario usu = new Usuario();
                    usu.IdUsuario = Convert.ToInt32(this.lblIdUsuario.Text);
                    usu.Nombre = this.txtNombre.Text;
                    usu.Apellido = this.txtApellido.Text;
                    usu.Dni = Convert.ToInt32(this.txtDni.Text);
                    usu.Telefono = long.Parse(this.txtTelefono.Text);
                    usu.Correo = this.txtCorreo.Text;
                    usu.Direccion = this.txtDireccion.Text;
                    usu.LoginName = this.txtLoginName.Text;
                    usu.Password = this.txtPassword.Text;
                    usu.Rol = this.cmbRol.Text;
                    usu.Foto = pic;

                    usuarioController.EditarUsuario(usu);
                    FormCircleProgressBar form = new FormCircleProgressBar("Datos actualizados correctamente");
                    form.ShowDialog();
                    //MessageBox.Show("Datos actualizados correctamente ", "Confirmado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ListarUsuarios();
                    Limpiar();
                }
                else
                {
                    MessageBox.Show("Verifique los datos ingresados ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("error al actualizar " + ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.lblIdUsuario.Text != "0")
                {
                    usuarioController.EliminarUsuario(Convert.ToInt32(this.lblIdUsuario.Text));
                    MessageBox.Show("Usuario Eliminado correctamente ", "Confirmado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ListarUsuarios();
                    Limpiar();
                }
                else
                {
                    MessageBox.Show("Debe Seleccionar elemento a eliminar", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("error al Eliminar " + ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            FormReporteUsuarios formRU = new FormReporteUsuarios();
            formRU.ShowDialog();
        }

        private void dgvUsuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.btnAgregar.Enabled = false;
            if (this.dgvUsuarios != null)
            {
                this.lblIdUsuario.Text = this.dgvUsuarios.Rows[e.RowIndex].Cells[0].Value.ToString();
                this.txtNombre.Text = this.dgvUsuarios.Rows[e.RowIndex].Cells[1].Value.ToString();
                this.txtApellido.Text = this.dgvUsuarios.Rows[e.RowIndex].Cells[2].Value.ToString();
                this.txtDni.Text = this.dgvUsuarios.Rows[e.RowIndex].Cells[3].Value.ToString();
                this.txtTelefono.Text = this.dgvUsuarios.Rows[e.RowIndex].Cells[4].Value.ToString();
                this.txtCorreo.Text = this.dgvUsuarios.Rows[e.RowIndex].Cells[5].Value.ToString();
                this.txtDireccion.Text = this.dgvUsuarios.Rows[e.RowIndex].Cells[6].Value.ToString();
                this.txtLoginName.Text = this.dgvUsuarios.Rows[e.RowIndex].Cells[7].Value.ToString();
                this.txtPassword.Text = this.dgvUsuarios.Rows[e.RowIndex].Cells[8].Value.ToString();
                this.cmbRol.Text = this.dgvUsuarios.Rows[e.RowIndex].Cells[9].Value.ToString();
                var foto = usuarioController.ObtenerFoto(Convert.ToInt32(this.lblIdUsuario.Text));
                if (foto != null)
                {
                    using (MemoryStream ms = new MemoryStream(foto, 0, foto.Length))
                    {
                        ms.Write(foto, 0, foto.Length);
                        this.pbFotoUsuario.Image = Image.FromStream(ms, true);
                    }
                }
                else
                {
                    MessageBox.Show("No tienen imagen guardada");
                }
            }
            else
            {
                MessageBox.Show("No hay datos en la tabla", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtFiltroBuscarUsuario_TextChanged(object sender, EventArgs e)
        {
            this.dgvUsuarios.DataSource = usuarioController.ListarUsuarios(this.txtFiltroBuscarUsuario.Text);
        }

        private void txtDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        public static bool validarEmail(string email)
        {
            string expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";

            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                { return true; }
                else
                { return false; }
            }
            else
            { return false; }
        }
    }
}
