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
    public partial class FormReporteAdopcion : Form
    {
        public int IdAdopcion { get; set; }
        public FormReporteAdopcion()
        {
            InitializeComponent();
        }

        private void FormReporteAdopcion_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DsReporteAdopcion.sp_ReporteAdopcion' Puede moverla o quitarla según sea necesario.
            this.sp_ReporteAdopcionTableAdapter.Fill(this.DsReporteAdopcion.sp_ReporteAdopcion, IdAdopcion);

            this.reportViewer1.RefreshReport();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
