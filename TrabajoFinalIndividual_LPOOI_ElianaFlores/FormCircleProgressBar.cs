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
    public partial class FormCircleProgressBar : Form
    {
        private Timer time;
        public FormCircleProgressBar()
        {
            InitializeComponent();
        }
        public FormCircleProgressBar(string mensaje)
        {
            InitializeComponent();

            time = new Timer();
            time.Interval = 2000;
            

            gcpb.Value = 60;
            this.mensaje.Text = mensaje;
            time.Tick += Timer_Tick;
        }

        private void FormCircleProgressBar_Load(object sender, EventArgs e)
        {
            time.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            time.Stop();
            this.Close();
        }
    }
}
