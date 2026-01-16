
namespace TrabajoFinalIndividual_LPOOI_ElianaFlores
{
    partial class FormCircleProgressBar
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
            this.gcpb = new Guna.UI.WinForms.GunaCircleProgressBar();
            this.gunaElipse1 = new Guna.UI.WinForms.GunaElipse(this.components);
            this.gunaCirclePictureBox1 = new Guna.UI.WinForms.GunaCirclePictureBox();
            this.mensaje = new Guna.UI.WinForms.GunaLabel();
            this.gcpb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gunaCirclePictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // gcpb
            // 
            this.gcpb.Animated = true;
            this.gcpb.AnimationSpeed = 0.3F;
            this.gcpb.BackColor = System.Drawing.Color.Transparent;
            this.gcpb.BaseColor = System.Drawing.Color.Transparent;
            this.gcpb.Controls.Add(this.gunaCirclePictureBox1);
            this.gcpb.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gcpb.IdleColor = System.Drawing.Color.White;
            this.gcpb.IdleOffset = 20;
            this.gcpb.Image = null;
            this.gcpb.ImageSize = new System.Drawing.Size(52, 52);
            this.gcpb.Location = new System.Drawing.Point(130, 12);
            this.gcpb.Name = "gcpb";
            this.gcpb.ProgressMaxColor = System.Drawing.Color.Fuchsia;
            this.gcpb.ProgressMinColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.gcpb.ProgressOffset = 20;
            this.gcpb.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gcpb.Size = new System.Drawing.Size(150, 150);
            this.gcpb.TabIndex = 0;
            this.gcpb.Value = 1;
            // 
            // gunaElipse1
            // 
            this.gunaElipse1.Radius = 15;
            this.gunaElipse1.TargetControl = this;
            // 
            // gunaCirclePictureBox1
            // 
            this.gunaCirclePictureBox1.BaseColor = System.Drawing.Color.White;
            this.gunaCirclePictureBox1.Image = global::TrabajoFinalIndividual_LPOOI_ElianaFlores.Properties.Resources.ok_px;
            this.gunaCirclePictureBox1.Location = new System.Drawing.Point(47, 45);
            this.gunaCirclePictureBox1.Name = "gunaCirclePictureBox1";
            this.gunaCirclePictureBox1.Size = new System.Drawing.Size(56, 56);
            this.gunaCirclePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.gunaCirclePictureBox1.TabIndex = 0;
            this.gunaCirclePictureBox1.TabStop = false;
            this.gunaCirclePictureBox1.UseTransfarantBackground = false;
            // 
            // mensaje
            // 
            this.mensaje.AutoSize = true;
            this.mensaje.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mensaje.ForeColor = System.Drawing.Color.Black;
            this.mensaje.Location = new System.Drawing.Point(31, 180);
            this.mensaje.Name = "mensaje";
            this.mensaje.Size = new System.Drawing.Size(98, 25);
            this.mensaje.TabIndex = 1;
            this.mensaje.Text = "MENSAJE";
            this.mensaje.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormCircleProgressBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(411, 227);
            this.Controls.Add(this.mensaje);
            this.Controls.Add(this.gcpb);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormCircleProgressBar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormCircleProgressBar";
            this.Load += new System.EventHandler(this.FormCircleProgressBar_Load);
            this.gcpb.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gunaCirclePictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI.WinForms.GunaCircleProgressBar gcpb;
        private Guna.UI.WinForms.GunaElipse gunaElipse1;
        private Guna.UI.WinForms.GunaCirclePictureBox gunaCirclePictureBox1;
        private Guna.UI.WinForms.GunaLabel mensaje;
    }
}