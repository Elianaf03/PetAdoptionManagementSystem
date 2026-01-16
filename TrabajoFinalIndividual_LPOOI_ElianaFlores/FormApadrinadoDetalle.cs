using Controller;
using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrabajoFinalIndividual_LPOOI_ElianaFlores
{
    public partial class FormApadrinadoDetalle : Form
    {
        ApadrinadoController apadrionadoController = new ApadrinadoController();
        MascotaController mascotaController = new MascotaController();
        UsuarioController usuarioController = new UsuarioController();
        public FormApadrinadoDetalle()
        {
            InitializeComponent();
        }
        public FormApadrinadoDetalle(int id)
        {
            InitializeComponent();
            cargarDatos(id);
            if (UsuarioCache.Rol == "Adoptante")
            {
                btnConfirmar.Visible = false;
            }
        }

        private void cargarDatos(int id)
        {
            this.dgvListaMascotas.DataSource = mascotaController.ApadrinadosPorId(id);

            Apadrinado a = apadrionadoController.ListarApadrinadoPorId(id);
            this.lblIdApadrinado.Text = a.IdApadrinado.ToString();
            this.lblAdoptante.Text = usuarioController.NombreUsuario(a.IdUsuario);
            this.lblFechaApadrinado.Text = a.Fecha.ToShortDateString();
            this.lblMonto.Text = a.Monto.ToString();
            if (a.Estado.ToString() == "CONFIRMADA")
            {
                this.lblEstado.ForeColor = Color.Green;
                this.btnConfirmar.Visible = false;
            }
            else
            {
                this.lblEstado.ForeColor = Color.Orange;
                this.btnConfirmar.Visible = true;
            }
            this.lblEstado.Text = a.Estado.ToString();
            this.cmbEstado.Text = a.Estado.ToString();
            this.txtComentario.Text = a.Comentario.ToString();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                int idDonacion = Convert.ToInt32(this.lblIdApadrinado.Text);
                apadrionadoController.cambiarEstadoDeApadrinado(idDonacion, cmbEstado.Text);

                foreach (DataGridViewRow dr in dgvListaMascotas.Rows)
                {
                    mascotaController.EditarEstadoDeMascota(Int32.Parse(dr.Cells[0].Value.ToString()), "Apadrinado");
                }
                MessageBox.Show("Estado cambiado a " + cmbEstado.Text);
                //Limpiar();
                cargarDatos(int.Parse(lblIdApadrinado.Text));
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error" + ex, "Error");
            }
        }

        private void dgvListaMascotas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = int.Parse(this.dgvListaMascotas.CurrentRow.Cells[0].Value.ToString());
            try
            {
                // se debe modificar el procedimiento almacenado en la columna con "Ver Funciones" as op
                if (e.RowIndex < 0 || e.ColumnIndex != dgvListaMascotas.Columns["Detalle"].Index)
                {
                    return;
                }
                else
                {

                    if (this.dgvListaMascotas.CurrentRow != null)
                    {
                        Mascota m = mascotaController.MascotaPorId(id);
                        this.lblNombre.Text = m.Nombre.ToString();
                        this.lblEspecie.Text = m.Especie.ToString();
                        this.lblSexo.Text = m.Sexo.ToString();
                        this.lblEdad.Text = m.Edad.ToString();
                        if (m.Castrado.ToString() == "False")
                        {
                            this.lblCastrado.Text = "NO";
                        }
                        else
                        {
                            this.lblCastrado.Text = "SI";
                        }
                        this.txtDescripcion.Text = m.Descripcion.ToString();
                        this.txtSituacion.Text = m.Situacion.ToString();
                        this.lblEstadoMascota.Text = m.Estado.ToString();
                        this.lblFechaIngreso.Text = m.FechaIngreso.ToShortDateString();
                        var foto = mascotaController.ObtenerFotoMascota(m.IdMascota);
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


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Cargar DataGrid Lista Libros " + ex, "Error");
            }
        }
    }
}
