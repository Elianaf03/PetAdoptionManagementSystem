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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrabajoFinalIndividual_LPOOI_ElianaFlores
{
    public partial class Mascotas : Form
    {
        string direImagen;
        MascotaController mascotaController = new MascotaController();
        public Mascotas()
        {
            InitializeComponent();
            ListarMascotas();
            if (UsuarioCache.Rol == "Adoptante")
            {
                btnAgregar.Visible = false;
                btnEditar.Visible = false;
                btnEliminar.Visible = false;
                btnCambiarFoto.Visible = false;
                btnLimpiar.Visible = false;
                btnReporte.Visible = false;
            }
        }

        private void ListarMascotas()
        {
            this.dgvMascotas.DataSource = mascotaController.ListarMascotas("");
        }
        private void Limpiar()
        {
            this.lblIdMascota.Text = "0";
            this.txtNombre.Text = "";
            this.txtEspecie.Text = "";
            this.cmbSexo.Text = "";
            this.txtEdad.Text = "";
            this.cmbEstado.Text = "";
            this.txtDescripcion.Text = "";
            this.txtSituacion.Text = "";
            this.chbCastrado.Checked = false;
            this.chbCastrado.Text = "...";
            this.pbFotoMascota.Image = global::TrabajoFinalIndividual_LPOOI_ElianaFlores.Properties.Resources.cat_footprintpx;
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
                this.pbFotoMascota.BackgroundImage = null;
                direImagen = openFileDialog1.FileName.ToString();

                this.pbFotoMascota.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            FormReporteMascotas formRM = new FormReporteMascotas();
            formRM.ShowDialog();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                MemoryStream ms = new MemoryStream();/* una fomra de hacerlo*/
                if (this.pbFotoMascota.Image != null & this.txtNombre.Text != "" & this.txtEspecie.Text != "")
                {
                    this.pbFotoMascota.Image.Save(ms, ImageFormat.Png);
                    byte[] pic = ms.ToArray();

                    Mascota mas = new Mascota();
                    mas.Nombre = this.txtNombre.Text;
                    mas.Especie = this.txtEspecie.Text;
                    mas.Sexo = this.cmbSexo.Text;
                    mas.Edad = this.txtEdad.Text;
                    mas.Estado = this.cmbEstado.Text;
                    mas.Descripcion = this.txtDescripcion.Text;
                    mas.Situacion = this.txtSituacion.Text;
                    mas.Castrado = this.chbCastrado.Checked;
                    mas.FechaIngreso = this.dtpFecha.Value;
                    mas.Foto = pic;

                    mascotaController.AgregarMascota(mas);
                    MessageBox.Show("Datos Guardados correctamente ", "Confirmado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ListarMascotas();
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
                if (this.pbFotoMascota.Image != null & this.txtNombre.Text != "" & this.txtEspecie.Text != "")
                {
                    this.pbFotoMascota.Image.Save(ms, ImageFormat.Png);
                    byte[] pic = ms.ToArray();

                    Mascota mas = new Mascota();
                    mas.IdMascota = Convert.ToInt32(this.lblIdMascota.Text);
                    mas.Nombre = this.txtNombre.Text;
                    mas.Especie = this.txtEspecie.Text;
                    mas.Sexo = this.cmbSexo.Text;
                    mas.Edad = this.txtEdad.Text;
                    mas.Estado = this.cmbEstado.Text;
                    mas.Descripcion = this.txtDescripcion.Text;
                    mas.Situacion = this.txtSituacion.Text;
                    mas.Castrado = this.chbCastrado.Checked;
                    mas.FechaIngreso = this.dtpFecha.Value;
                    mas.Foto = pic;

                    mascotaController.EditarMascota(mas);
                    MessageBox.Show("Datos actualizados correctamente ", "Confirmado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ListarMascotas();
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
                if (this.lblIdMascota.Text != "0")
                {
                    mascotaController.EliminarMascota(Convert.ToInt32(this.lblIdMascota.Text));
                    MessageBox.Show("Mascota Eliminado correctamente ", "Confirmado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ListarMascotas();
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
        
        private void dgvMascotas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.btnAgregar.Enabled = false;
            if (this.dgvMascotas != null)
            {
                this.lblIdMascota.Text = this.dgvMascotas.Rows[e.RowIndex].Cells[0].Value.ToString();
                this.txtNombre.Text = this.dgvMascotas.Rows[e.RowIndex].Cells[1].Value.ToString();
                this.txtEspecie.Text = this.dgvMascotas.Rows[e.RowIndex].Cells[2].Value.ToString();
                this.cmbSexo.Text = this.dgvMascotas.Rows[e.RowIndex].Cells[3].Value.ToString();
                this.txtEdad.Text = this.dgvMascotas.Rows[e.RowIndex].Cells[4].Value.ToString();
                this.chbCastrado.Checked = (bool)this.dgvMascotas.Rows[e.RowIndex].Cells[5].Value;
                this.txtDescripcion.Text = this.dgvMascotas.Rows[e.RowIndex].Cells[6].Value.ToString();
                this.txtSituacion.Text = this.dgvMascotas.Rows[e.RowIndex].Cells[7].Value.ToString();
                this.cmbEstado.Text = this.dgvMascotas.Rows[e.RowIndex].Cells[8].Value.ToString();
                this.dtpFecha.Value = (DateTime)(this.dgvMascotas.Rows[e.RowIndex].Cells[9].Value);
                var foto = mascotaController.ObtenerFotoMascota(Convert.ToInt32(this.lblIdMascota.Text));
                if (foto != null)
                {
                    using (MemoryStream ms = new MemoryStream(foto, 0, foto.Length))
                    {
                        ms.Write(foto, 0, foto.Length);
                        this.pbFotoMascota.Image = Image.FromStream(ms, true);
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

        string especie = "";
        private void chbPerro_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chbPerro.Checked == true)
            {
                this.chbPerro.ForeColor = Color.White;
                especie = "Perro";
                this.dgvMascotas.DataSource = mascotaController.BuscarMascotaPorNombreOEspecie(this.txtFiltroBuscar.Text, especie);
            }
            else
            {
                this.chbPerro.ForeColor = Color.FromArgb(192, 64, 0);
                especie = "";
                this.dgvMascotas.DataSource = mascotaController.BuscarMascotaPorNombreOEspecie(this.txtFiltroBuscar.Text, especie);
            }
        }

        private void chbGato_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chbGato.Checked == true)
            {
                this.chbGato.ForeColor = Color.White;
                especie = "Gato";
                this.dgvMascotas.DataSource = mascotaController.BuscarMascotaPorNombreOEspecie(this.txtFiltroBuscar.Text, especie);
            }
            else
            {
                this.chbGato.ForeColor = Color.FromArgb(192, 64, 0);
                especie = "";
                this.dgvMascotas.DataSource = mascotaController.BuscarMascotaPorNombreOEspecie(this.txtFiltroBuscar.Text, especie);
            }
        }

        private void txtFiltroBuscar_TextChanged(object sender, EventArgs e)
        {
            this.dgvMascotas.DataSource = mascotaController.BuscarMascotaPorNombreOEspecie(this.txtFiltroBuscar.Text, especie);
        }

        private void chbCastrado_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chbCastrado.Checked == false)
            {
                this.chbCastrado.Text = "NO";
                this.chbCastrado.ForeColor = Color.Red;
            }
            else
            {
                this.chbCastrado.Text = "SI";
                this.chbCastrado.ForeColor = Color.Green;
            }
        }
    }
}
