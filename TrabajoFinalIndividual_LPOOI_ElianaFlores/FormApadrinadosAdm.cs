using Controller;
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
    public partial class FormApadrinadosAdm : Form
    {
        ApadrinadoController apadrinadoController = new ApadrinadoController();
        public FormApadrinadosAdm()
        {
            InitializeComponent();
            cargarDGV();
        }
        private void cargarDGV()
        {
            //this.dgvMascotas.DataSource = mascotaController.ListarMascotasPorEstado("Solicitado", "Sin estado");
            this.dgvApadrinados.DataSource = apadrinadoController.ListarApadrinados();
        }

        private void dgvApadrinados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != dgvApadrinados.Columns["Detalle"].Index)
            {
                return;
            }
            else
            {

                int id = int.Parse(this.dgvApadrinados.CurrentRow.Cells[0].Value.ToString());
                FormApadrinadoDetalle formrDetalle = new FormApadrinadoDetalle(id);
                formrDetalle.ShowDialog();
            }
        }
    }
}
