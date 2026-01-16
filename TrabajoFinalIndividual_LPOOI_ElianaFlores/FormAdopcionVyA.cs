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
    public partial class FormAdopcionVyA : Form
    {
        MascotaController mascotaController = new MascotaController();
        UsuarioController usuarioController = new UsuarioController();
        AdopcionController adopcionController = new AdopcionController();
        public FormAdopcionVyA()
        {
            InitializeComponent();
            cargarDGV();
        }
        private void cargarDGV()
        {
            if (UsuarioCache.Rol == "Voluntario")
            {
              this.dgvAdopciones.DataSource = adopcionController.ListarAdopcionesVoluntarios();
            }
            else
            {
                this.dgvAdopciones.DataSource = adopcionController.ListarAdopcionPorIdUsuario(UsuarioCache.IdUsuario);
            }
        }

        private void Limpiar()
        {
            //this.lblIdAdopcion.Text = "0";
            //this.txtAdoptante.Text = "";
            //this.txtMascota.Text = "";
            //this.cmbEstado.Text = "";
            //this.txtComentario.Text = "";
            //this.btnAgregar.Enabled = true;
        }

        private void dgvAdopciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = int.Parse(this.dgvAdopciones.CurrentRow.Cells[0].Value.ToString());
            int idAdoptante = int.Parse(this.dgvAdopciones.CurrentRow.Cells[1].Value.ToString());
            int idMascota = int.Parse(this.dgvAdopciones.CurrentRow.Cells[2].Value.ToString());
            try
            {
                // se debe modificar el procedimiento almacenado en la columna con "Ver Funciones" as op
                if (e.RowIndex < 0 || e.ColumnIndex != dgvAdopciones.Columns["Detalle"].Index)
                {
                    return;
                }
                else
                {

                    if (this.dgvAdopciones.CurrentRow != null)
                    {
                        this.lblIdAdopcion.Text = this.dgvAdopciones.CurrentRow.Cells[0].Value.ToString();
                        this.lblEstadoAdopcion.Text = this.dgvAdopciones.CurrentRow.Cells[3].Value.ToString();
                        this.lblFechaAdopcion.Text = this.dgvAdopciones.CurrentRow.Cells[4].Value.ToString();
                        this.lblComentario.Text = this.dgvAdopciones.CurrentRow.Cells[5].Value.ToString();
                        this.lblMascota.Text = this.dgvAdopciones.CurrentRow.Cells[6].Value.ToString();
                        this.lblEspecie.Text = this.dgvAdopciones.CurrentRow.Cells[7].Value.ToString();
                        this.lblSexo.Text = this.dgvAdopciones.CurrentRow.Cells[8].Value.ToString();
                        this.lblEdad.Text = this.dgvAdopciones.CurrentRow.Cells[9].Value.ToString();
                        var foto = mascotaController.ObtenerFotoMascota(idMascota);
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
                        this.lblAdoptante.Text = this.dgvAdopciones.CurrentRow.Cells[10].Value.ToString();
                        this.lblDNI.Text = this.dgvAdopciones.CurrentRow.Cells[11].Value.ToString();
                        this.lblTelefono.Text = this.dgvAdopciones.CurrentRow.Cells[12].Value.ToString();
                        this.lblCorreo.Text = this.dgvAdopciones.CurrentRow.Cells[13].Value.ToString();
                        this.lblDireccion.Text = this.dgvAdopciones.CurrentRow.Cells[14].Value.ToString();
                        var fotoA = usuarioController.ObtenerFoto(idAdoptante);
                        if (fotoA != null)
                        {
                            using (MemoryStream ms = new MemoryStream(foto, 0, fotoA.Length))
                            {
                                ms.Write(fotoA, 0, fotoA.Length);
                                this.pbFotoUsuario.Image = Image.FromStream(ms, true);
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
                MessageBox.Show("Error al Cargar DataGrid" + ex, "Error");
            }
        }
    }
}
