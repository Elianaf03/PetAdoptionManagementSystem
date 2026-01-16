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
    public partial class FormApadrinados : Form
    {
        MascotaController mascotaController = new MascotaController();
        ApadrinadoController apadrinadoController = new ApadrinadoController();
        
        public FormApadrinados()
        {
            InitializeComponent();
            cargarDGV();
            this.txtAdoptante.Text = UsuarioCache.Nombre + " " + UsuarioCache.Apellido;
        }

        private void cargarDGV()
        {
            this.dgvMascotas.DataSource = mascotaController.ListarMascotasPorEstado("Solicitado", "Sin estado");
            this.dgvApadrinados.DataSource = apadrinadoController.ListarApadrinadosPorIdUsuario(UsuarioCache.IdUsuario);
        }

        private void Limpiar()
        {
            this.dgvListaMascotas.Rows.Clear();
            this.lblIdApadrinado.Text = "0";
            this.txtAdoptante.Text = "";
            this.txtMonto.Text = "";
            //this.cmbEstado.Text = "";
            this.txtComentario.Text = "";
            this.btnDonar.Enabled = true;
        }

        int idMascotaSeleccionada;
        int rowIndex;
        private void dgvMascotas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.idMascotaSeleccionada = int.Parse(this.dgvMascotas.CurrentRow.Cells[0].Value.ToString());
                if (this.dgvMascotas.CurrentRow != null)
                {
                    string IdMascota = this.dgvMascotas.CurrentRow.Cells[0].Value.ToString();
                    string Nombre = this.dgvMascotas.CurrentRow.Cells[1].Value.ToString() ;
                    string Especie = this.dgvMascotas.CurrentRow.Cells[2].Value.ToString();

                    this.dgvListaMascotas.Rows.Add(new object[] { IdMascota, Nombre, Especie, "Eliminar" });
                    
                    this.lblMascotaSeleccionada.Text = IdMascota;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error en Seleccionar Libro del DataGrid " + ex, "Error");
            }
        }

        private void btnDonar_Click(object sender, EventArgs e)
        {
            try
            {
                List<ApadrinadoDetalle> lst = new List<ApadrinadoDetalle>();

                foreach (DataGridViewRow dr in dgvListaMascotas.Rows)
                {
                    ApadrinadoDetalle ad = new ApadrinadoDetalle();
                    ad.IdMascota = Int32.Parse(dr.Cells[0].Value.ToString());
                    lst.Add(ad);
                    //mascotaController.EditarEstadoDeMascota(ad.IdMascota, "Apadrinado");
                }
                Apadrinado apadrinado = new Apadrinado();
                apadrinado.IdUsuario = UsuarioCache.IdUsuario;
                apadrinado.Monto = decimal.Parse(this.txtMonto.Text);
                apadrinado.Estado = this.lblEstado.Text;
                apadrinado.Comentario = this.txtComentario.Text;
                apadrinadoController.AgregarApadrinado(apadrinado, lst);
                //MessageBox.Show("Apadrinado Registrada con Exito");
                this.gbAvisoDonacion.Visible = true;
                this.gbDatosApadrinado.Visible = false;
                this.gbListaMascota.Visible = false;
                this.gbListaApadrinados.Visible = false;

                Limpiar();
                cargarDGV();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error en Registrar Apadrinado " + ex, "Error");
            }
        }

        private void dgvListaMascotas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != dgvListaMascotas.Columns["Op"].Index)
            {
                return;
            }
            else
            {
                dgvListaMascotas.Rows.RemoveAt(e.RowIndex);
                //dgvMascotas.Rows.Add(rowIndex);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void dgvApadrinados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != dgvApadrinados.Columns["Detalle"].Index)
            {
                return;
            }
            else
            {

                int id = int.Parse(this.dgvApadrinados.CurrentRow.Cells[1].Value.ToString());
                FormApadrinadoDetalle formrDetalle = new FormApadrinadoDetalle(id);
                formrDetalle.ShowDialog();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.gbAvisoDonacion.Visible = false;
            this.gbDatosApadrinado.Visible = true;
            this.gbListaMascota.Visible = true;
            this.gbListaApadrinados.Visible = true;
        }
    }
}
