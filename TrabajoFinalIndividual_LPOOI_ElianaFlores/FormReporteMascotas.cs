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
    public partial class FormReporteMascotas : Form
    {
        public FormReporteMascotas()
        {
            InitializeComponent();
        }

        private void FormReporteMascotas_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DsReporteMascotas.sp_ReporteMascotas' Puede moverla o quitarla según sea necesario.
            this.sp_ReporteMascotasTableAdapter.Fill(this.DsReporteMascotas.sp_ReporteMascotas);

            this.reportViewer1.RefreshReport();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
