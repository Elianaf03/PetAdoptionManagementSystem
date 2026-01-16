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
    public partial class FormVisitas : Form
    {
        VisitaController visitaController = new VisitaController();
        public FormVisitas()
        {
            InitializeComponent();
            ListarVisitas();
            this.lblHora.Text = DateTime.Now.ToString("HH:mm");
        }

        private void ListarVisitas()
        {
            if (UsuarioCache.Rol == "Adoptante")
            {
                this.dgvVisitas.DataSource = visitaController.VisitasPorAdoptante(UsuarioCache.Dni);
                btnAgregar.Visible = false;
                btnEditar.Visible = false;
                btnEliminar.Visible = false;
                btnLimpiar.Visible = false;
            }
            else
            {
                this.dgvVisitas.DataSource = visitaController.ListarVisitas();
            }
            
        }
        private void Limpiar()
        {
            this.lblIdVisita.Text = "0";
            this.txtNombre.Text = "";
            this.txtApellido.Text = "";
            this.txtDni.Text = "";
            this.txtDescripcion.Text = "";
            this.txtMotivo.Text = "";
            this.dtpFecha.Value = DateTime.Now;
            this.lblHora.Text = DateTime.Now.ToString("HH:mm");
            this.btnAgregar.Enabled = true;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtNombre.Text != "" & this.txtApellido.Text != "")
                {
                    Visita visita = new Visita();
                    visita.IdUsuario = UsuarioCache.IdUsuario;
                    visita.Nombre = this.txtNombre.Text;
                    visita.Apellido = this.txtApellido.Text;
                    visita.Dni = int.Parse(this.txtDni.Text);
                    visita.Motivo = this.txtMotivo.Text;
                    visita.Descripcion = this.txtDescripcion.Text;

                    visitaController.AgregarVisita(visita);
                    MessageBox.Show("Datos Guardados correctamente ", "Confirmado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ListarVisitas();
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
                if (this.txtNombre.Text != "" & this.txtApellido.Text != "")
                {
                    Visita visita = new Visita();
                    visita.IdVisita = int.Parse(this.lblIdVisita.Text);
                    visita.IdUsuario = UsuarioCache.IdUsuario;
                    visita.Nombre = this.txtNombre.Text;
                    visita.Apellido = this.txtApellido.Text;
                    visita.Dni = int.Parse(this.txtDni.Text);
                    visita.Motivo = this.txtMotivo.Text;
                    visita.Descripcion = this.txtDescripcion.Text;

                    visitaController.EditarVisita(visita);
                    MessageBox.Show("Datos actualizados correctamente ", "Confirmado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ListarVisitas();
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
                if (this.lblIdVisita.Text != "0")
                {
                    visitaController.EliminarVisita(Convert.ToInt32(this.lblIdVisita.Text));
                    MessageBox.Show("Visita Eliminado correctamente ", "Confirmado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ListarVisitas();
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

        private void dgvVisitas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.btnAgregar.Enabled = false;
            if (this.dgvVisitas != null)
            {
                this.lblIdVisita.Text = this.dgvVisitas.Rows[e.RowIndex].Cells[0].Value.ToString();
                this.txtNombre.Text = this.dgvVisitas.Rows[e.RowIndex].Cells[2].Value.ToString();
                this.txtApellido.Text = this.dgvVisitas.Rows[e.RowIndex].Cells[3].Value.ToString();
                this.txtDni.Text = this.dgvVisitas.Rows[e.RowIndex].Cells[4].Value.ToString();
                this.txtMotivo.Text = this.dgvVisitas.Rows[e.RowIndex].Cells[5].Value.ToString();
                this.dtpFecha.Value = (DateTime)(this.dgvVisitas.Rows[e.RowIndex].Cells[6].Value);
                this.lblHora.Text = this.dgvVisitas.Rows[e.RowIndex].Cells[7].Value.ToString();
                this.txtDescripcion.Text = this.dgvVisitas.Rows[e.RowIndex].Cells[8].Value.ToString();
                
            }
            else
            {
                MessageBox.Show("No hay datos en la tabla", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
