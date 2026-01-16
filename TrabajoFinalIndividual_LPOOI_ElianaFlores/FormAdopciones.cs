using Controller;
using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrabajoFinalIndividual_LPOOI_ElianaFlores
{
    public partial class FormAdopciones : Form
    {
        MascotaController mascotaController = new MascotaController();
        UsuarioController usuarioController = new UsuarioController();
        AdopcionController adopcionController = new AdopcionController();
        public FormAdopciones()
        {
            InitializeComponent();
            cargarDGV();
        }

        private void cargarDGV()
        {
            this.dgvMascotas.DataSource = mascotaController.ListarMascotasPorEstado("Apadrinado", "Sin estado");
            this.dgvUsuarios.DataSource = usuarioController.ListarUsuariosAdoptantes("Adoptante");
            this.dgvAdopciones.DataSource = adopcionController.ListarAdopcions("");
        }

        private void Limpiar()
        {
            this.lblIdAdopcion.Text = "0";
            this.txtAdoptante.Text = "";
            this.txtMascota.Text = "";
            this.cmbEstado.Text = "";
            this.txtComentario.Text = "";
            this.btnAgregar.Enabled = true;
            this.btnAgregar.Visible = true;
            this.btnReporte.Visible = false;
        }

        int idMascotaParaAdopcion;
        string estado;
        private void dgvMascotas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.idMascotaParaAdopcion = Convert.ToInt32(this.dgvMascotas.CurrentRow.Cells[0].Value.ToString());
                if (this.dgvMascotas.CurrentRow != null)
                {
                    string mascotitaSeleccionada;
                    string id = this.dgvMascotas.CurrentRow.Cells[0].Value.ToString();
                    string nombre = this.dgvMascotas.CurrentRow.Cells[1].Value.ToString();
                    string especie = this.dgvMascotas.CurrentRow.Cells[2].Value.ToString();
                    estado = this.dgvMascotas.CurrentRow.Cells[8].Value.ToString();
                    mascotitaSeleccionada = id + ". " + nombre + " ("+ especie+")";
                    this.lblMascotaSeleccionada.Text = id;
                    this.txtMascota.Text = mascotitaSeleccionada;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Cargar DataGrid " + ex, "Error");
            }
        }
        int idAdoptante;
        private void dgvUsuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.idAdoptante = Convert.ToInt32(this.dgvUsuarios.CurrentRow.Cells[0].Value.ToString());
                if (this.dgvUsuarios.CurrentRow != null)
                {
                    string adoptanteSeleccionada;
                    string id = this.dgvUsuarios.CurrentRow.Cells[0].Value.ToString();
                    string nombre = this.dgvUsuarios.CurrentRow.Cells[1].Value.ToString();
                    string apellido = this.dgvUsuarios.CurrentRow.Cells[2].Value.ToString();
                    adoptanteSeleccionada = id + ". " + nombre + " "+ apellido;
                    this.lblAdoptanteSeleccionado.Text = id;
                    this.txtAdoptante.Text = adoptanteSeleccionada;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Cargar DataGrid " + ex, "Error");
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtMascota.Text != "" & this.txtAdoptante.Text != "")
                {
                    Adopcion adopcion = new Adopcion();
                    adopcion.IdMascota = idMascotaParaAdopcion;
                    adopcion.IdUsuario = idAdoptante;
                    adopcion.Estado = this.cmbEstado.Text;
                    adopcion.Comentario = this.txtComentario.Text;
                    
                    adopcionController.AgregarAdopcion(adopcion);
                    if (this.cmbEstado.Text=="En espera")
                    {
                        mascotaController.EditarEstadoDeMascota(idMascotaParaAdopcion, "Solicitado");
                    }
                    else
                    {
                        if (this.cmbEstado.Text == "Aceptada")
                        {
                            mascotaController.EditarEstadoDeMascota(idMascotaParaAdopcion, "Adoptado");
                        }
                        else
                        {
                            mascotaController.EditarEstadoDeMascota(idMascotaParaAdopcion, estado);
                        }
                    }
                    
                    MessageBox.Show("Datos Guardados correctamente ", "Confirmado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargarDGV();
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
                if (this.txtMascota.Text != "" & this.txtAdoptante.Text != "")
                {
                    Adopcion adopcion = new Adopcion();
                    adopcion.IdAdopcion = int.Parse(this.lblIdAdopcion.Text);
                    adopcion.IdMascota = idMascotaParaAdopcion;
                    adopcion.IdUsuario = idAdoptante;
                    adopcion.Estado = this.cmbEstado.Text;
                    adopcion.Comentario = this.txtComentario.Text;

                    adopcionController.EditarAdopcion(adopcion);
                    if (this.cmbEstado.Text == "En espera")
                    {
                        mascotaController.EditarEstadoDeMascota(idMascotaParaAdopcion, "Solicitado");
                    }
                    else
                    {
                        if (this.cmbEstado.Text == "Aceptada")
                        {
                            mascotaController.EditarEstadoDeMascota(idMascotaParaAdopcion, "Adoptado");
                        }
                        else
                        {
                            mascotaController.EditarEstadoDeMascota(idMascotaParaAdopcion, estado);
                        }
                    }
                    MessageBox.Show("Datos actualizados correctamente ", "Confirmado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargarDGV();
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.lblIdAdopcion.Text != "0")
                {
                    adopcionController.EliminarAdopcion(Convert.ToInt32(this.lblIdAdopcion.Text));
                    mascotaController.EditarEstadoDeMascota(idMascotaParaAdopcion, estado);
                    MessageBox.Show("Adopcion Eliminada correctamente ", "Confirmado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargarDGV();
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

        private void dgvAdopciones_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.btnAgregar.Enabled = false;
            this.btnAgregar.Visible = false;
            this.btnReporte.Visible = true;
            if (this.dgvAdopciones != null)
            {
                this.lblIdAdopcion.Text = this.dgvAdopciones.Rows[e.RowIndex].Cells[0].Value.ToString();
                this.txtAdoptante.Text = this.dgvAdopciones.Rows[e.RowIndex].Cells[1].Value.ToString()+". "+ this.dgvAdopciones.Rows[e.RowIndex].Cells[6].Value.ToString();
                this.txtMascota.Text = this.dgvAdopciones.Rows[e.RowIndex].Cells[2].Value.ToString() + ". " + this.dgvAdopciones.Rows[e.RowIndex].Cells[7].Value.ToString();
                this.dtpFecha.Value = (DateTime)(this.dgvAdopciones.Rows[e.RowIndex].Cells[3].Value);
                this.cmbEstado.Text = this.dgvAdopciones.Rows[e.RowIndex].Cells[4].Value.ToString();
                this.txtComentario.Text = this.dgvAdopciones.Rows[e.RowIndex].Cells[5].Value.ToString();

            }
            else
            {
                MessageBox.Show("No hay datos en la tabla", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void chAceptadas_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chAceptadas.Checked == true)
            {
                this.chAceptadas.ForeColor = Color.White;
                this.dgvAdopciones.DataSource = adopcionController.ListarAdopcions("Aceptada");
                this.chbEnEspera.Enabled = false;
                this.chbRechazadas.Enabled = false;
            }
            else
            {
                this.chAceptadas.ForeColor = Color.FromArgb(192, 64, 0);
                this.dgvAdopciones.DataSource = adopcionController.ListarAdopcions("");
                this.chbEnEspera.Enabled = true;
                this.chbRechazadas.Enabled = true;
            }
        }

        private void chbEnEspera_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chbEnEspera.Checked == true)
            {
                this.chbEnEspera.ForeColor = Color.White;
                this.dgvAdopciones.DataSource = adopcionController.ListarAdopcions("En espera");
                this.chAceptadas.Enabled = false;
                this.chbRechazadas.Enabled = false;
            }
            else
            {
                this.chbEnEspera.ForeColor = Color.FromArgb(192, 64, 0);
                this.dgvAdopciones.DataSource = adopcionController.ListarAdopcions("");
                this.chAceptadas.Enabled = true;
                this.chbRechazadas.Enabled = true;
            }
        }

        private void chbRechazadas_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chbRechazadas.Checked == true)
            {
                this.chbRechazadas.ForeColor = Color.White;
                this.dgvAdopciones.DataSource = adopcionController.ListarAdopcions("Rechazada");
                this.chAceptadas.Enabled = false;
                this.chbEnEspera.Enabled = false;

            }
            else
            {
                this.chbRechazadas.ForeColor = Color.FromArgb(192, 64, 0);
                this.dgvAdopciones.DataSource = adopcionController.ListarAdopcions("");
                this.chAceptadas.Enabled = true;
                this.chbEnEspera.Enabled = true;
            }
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            FormReporteAdopcion formReporteAdopcion = new FormReporteAdopcion();
            formReporteAdopcion.IdAdopcion = int.Parse(this.lblIdAdopcion.Text);
            formReporteAdopcion.ShowDialog();
        }
    }
}
