
namespace TrabajoFinalIndividual_LPOOI_ElianaFlores
{
    partial class FormReporteMascotas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReporteMascotas));
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.gunaGradientPanel1 = new Guna.UI.WinForms.GunaGradientPanel();
            this.lblTituloDeFormularioHijo = new System.Windows.Forms.Label();
            this.iconActualHijoDeFormulario = new FontAwesome.Sharp.IconPictureBox();
            this.btnSalir = new Guna.UI.WinForms.GunaButton();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DsReporteMascotas = new TrabajoFinalIndividual_LPOOI_ElianaFlores.DsReporteMascotas();
            this.sp_ReporteMascotasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sp_ReporteMascotasTableAdapter = new TrabajoFinalIndividual_LPOOI_ElianaFlores.DsReporteMascotasTableAdapters.sp_ReporteMascotasTableAdapter();
            this.gunaGradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconActualHijoDeFormulario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DsReporteMascotas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sp_ReporteMascotasBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // gunaGradientPanel1
            // 
            this.gunaGradientPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gunaGradientPanel1.BackgroundImage")));
            this.gunaGradientPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gunaGradientPanel1.Controls.Add(this.lblTituloDeFormularioHijo);
            this.gunaGradientPanel1.Controls.Add(this.iconActualHijoDeFormulario);
            this.gunaGradientPanel1.Controls.Add(this.btnSalir);
            this.gunaGradientPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.gunaGradientPanel1.GradientColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.gunaGradientPanel1.GradientColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.gunaGradientPanel1.GradientColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.gunaGradientPanel1.GradientColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.gunaGradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.gunaGradientPanel1.Name = "gunaGradientPanel1";
            this.gunaGradientPanel1.Size = new System.Drawing.Size(800, 47);
            this.gunaGradientPanel1.TabIndex = 2;
            this.gunaGradientPanel1.Text = "gunaGradientPanel1";
            // 
            // lblTituloDeFormularioHijo
            // 
            this.lblTituloDeFormularioHijo.AutoSize = true;
            this.lblTituloDeFormularioHijo.BackColor = System.Drawing.Color.Transparent;
            this.lblTituloDeFormularioHijo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloDeFormularioHijo.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblTituloDeFormularioHijo.Location = new System.Drawing.Point(51, 9);
            this.lblTituloDeFormularioHijo.Name = "lblTituloDeFormularioHijo";
            this.lblTituloDeFormularioHijo.Size = new System.Drawing.Size(86, 24);
            this.lblTituloDeFormularioHijo.TabIndex = 8;
            this.lblTituloDeFormularioHijo.Text = "Reportes";
            // 
            // iconActualHijoDeFormulario
            // 
            this.iconActualHijoDeFormulario.BackColor = System.Drawing.Color.Transparent;
            this.iconActualHijoDeFormulario.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.iconActualHijoDeFormulario.IconChar = FontAwesome.Sharp.IconChar.Paperclip;
            this.iconActualHijoDeFormulario.IconColor = System.Drawing.SystemColors.ButtonFace;
            this.iconActualHijoDeFormulario.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconActualHijoDeFormulario.IconSize = 35;
            this.iconActualHijoDeFormulario.Location = new System.Drawing.Point(9, 7);
            this.iconActualHijoDeFormulario.Name = "iconActualHijoDeFormulario";
            this.iconActualHijoDeFormulario.Size = new System.Drawing.Size(35, 35);
            this.iconActualHijoDeFormulario.TabIndex = 7;
            this.iconActualHijoDeFormulario.TabStop = false;
            // 
            // btnSalir
            // 
            this.btnSalir.AnimationHoverSpeed = 0.07F;
            this.btnSalir.AnimationSpeed = 0.03F;
            this.btnSalir.BackColor = System.Drawing.Color.Transparent;
            this.btnSalir.BaseColor = System.Drawing.Color.Red;
            this.btnSalir.BorderColor = System.Drawing.Color.White;
            this.btnSalir.BorderSize = 2;
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnSalir.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSalir.FocusedColor = System.Drawing.Color.Empty;
            this.btnSalir.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ForeColor = System.Drawing.Color.White;
            this.btnSalir.Image = null;
            this.btnSalir.ImageSize = new System.Drawing.Size(20, 20);
            this.btnSalir.Location = new System.Drawing.Point(769, 0);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.OnHoverBaseColor = System.Drawing.Color.DarkRed;
            this.btnSalir.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnSalir.OnHoverForeColor = System.Drawing.Color.White;
            this.btnSalir.OnHoverImage = null;
            this.btnSalir.OnPressedColor = System.Drawing.Color.Black;
            this.btnSalir.Radius = 8;
            this.btnSalir.Size = new System.Drawing.Size(31, 47);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "X";
            this.btnSalir.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.sp_ReporteMascotasBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "TrabajoFinalIndividual_LPOOI_ElianaFlores.Reportes.RptMascotas.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 48);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 481);
            this.reportViewer1.TabIndex = 3;
            // 
            // DsReporteMascotas
            // 
            this.DsReporteMascotas.DataSetName = "DsReporteMascotas";
            this.DsReporteMascotas.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sp_ReporteMascotasBindingSource
            // 
            this.sp_ReporteMascotasBindingSource.DataMember = "sp_ReporteMascotas";
            this.sp_ReporteMascotasBindingSource.DataSource = this.DsReporteMascotas;
            // 
            // sp_ReporteMascotasTableAdapter
            // 
            this.sp_ReporteMascotasTableAdapter.ClearBeforeFill = true;
            // 
            // FormReporteMascotas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 529);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.gunaGradientPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormReporteMascotas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormReporteMascotas";
            this.Load += new System.EventHandler(this.FormReporteMascotas_Load);
            this.gunaGradientPanel1.ResumeLayout(false);
            this.gunaGradientPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconActualHijoDeFormulario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DsReporteMascotas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sp_ReporteMascotasBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI.WinForms.GunaGradientPanel gunaGradientPanel1;
        private System.Windows.Forms.Label lblTituloDeFormularioHijo;
        private FontAwesome.Sharp.IconPictureBox iconActualHijoDeFormulario;
        private Guna.UI.WinForms.GunaButton btnSalir;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource sp_ReporteMascotasBindingSource;
        private DsReporteMascotas DsReporteMascotas;
        private DsReporteMascotasTableAdapters.sp_ReporteMascotasTableAdapter sp_ReporteMascotasTableAdapter;
    }
}