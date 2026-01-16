
namespace TrabajoFinalIndividual_LPOOI_ElianaFlores
{
    partial class FormLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.gunaPictureBox1 = new Guna.UI.WinForms.GunaPictureBox();
            this.gunaGradientPanel1 = new Guna.UI.WinForms.GunaGradientPanel();
            this.lblMsjError = new System.Windows.Forms.Label();
            this.txtPassword = new Guna.UI.WinForms.GunaTextBox();
            this.txtUsuario = new Guna.UI.WinForms.GunaTextBox();
            this.chbMostrarContraseña = new Guna.UI.WinForms.GunaCheckBox();
            this.btnIngresar = new Guna.UI.WinForms.GunaButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTituloDeFormularioHijo = new System.Windows.Forms.Label();
            this.btnSalir = new Guna.UI.WinForms.GunaButton();
            ((System.ComponentModel.ISupportInitialize)(this.gunaPictureBox1)).BeginInit();
            this.gunaGradientPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gunaPictureBox1
            // 
            this.gunaPictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.gunaPictureBox1.BaseColor = System.Drawing.Color.White;
            this.gunaPictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.gunaPictureBox1.Image = global::TrabajoFinalIndividual_LPOOI_ElianaFlores.Properties.Resources.login1;
            this.gunaPictureBox1.Location = new System.Drawing.Point(0, 0);
            this.gunaPictureBox1.Name = "gunaPictureBox1";
            this.gunaPictureBox1.Size = new System.Drawing.Size(172, 266);
            this.gunaPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.gunaPictureBox1.TabIndex = 1;
            this.gunaPictureBox1.TabStop = false;
            // 
            // gunaGradientPanel1
            // 
            this.gunaGradientPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gunaGradientPanel1.BackgroundImage")));
            this.gunaGradientPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gunaGradientPanel1.Controls.Add(this.lblMsjError);
            this.gunaGradientPanel1.Controls.Add(this.txtPassword);
            this.gunaGradientPanel1.Controls.Add(this.txtUsuario);
            this.gunaGradientPanel1.Controls.Add(this.chbMostrarContraseña);
            this.gunaGradientPanel1.Controls.Add(this.btnIngresar);
            this.gunaGradientPanel1.Controls.Add(this.label2);
            this.gunaGradientPanel1.Controls.Add(this.label1);
            this.gunaGradientPanel1.Controls.Add(this.lblTituloDeFormularioHijo);
            this.gunaGradientPanel1.Controls.Add(this.btnSalir);
            this.gunaGradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gunaGradientPanel1.GradientColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.gunaGradientPanel1.GradientColor2 = System.Drawing.Color.Fuchsia;
            this.gunaGradientPanel1.GradientColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.gunaGradientPanel1.GradientColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.gunaGradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.gunaGradientPanel1.Name = "gunaGradientPanel1";
            this.gunaGradientPanel1.Size = new System.Drawing.Size(628, 266);
            this.gunaGradientPanel1.TabIndex = 0;
            this.gunaGradientPanel1.Text = "gunaGradientPanel1";
            this.gunaGradientPanel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gunaGradientPanel1_MouseDown);
            // 
            // lblMsjError
            // 
            this.lblMsjError.AutoSize = true;
            this.lblMsjError.BackColor = System.Drawing.Color.Transparent;
            this.lblMsjError.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsjError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.lblMsjError.Location = new System.Drawing.Point(205, 189);
            this.lblMsjError.Name = "lblMsjError";
            this.lblMsjError.Size = new System.Drawing.Size(392, 24);
            this.lblMsjError.TabIndex = 18;
            this.lblMsjError.Text = "USUARIO O CONTRASEÑA INCORRECTOS";
            this.lblMsjError.Visible = false;
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.Transparent;
            this.txtPassword.BaseColor = System.Drawing.Color.White;
            this.txtPassword.BorderColor = System.Drawing.Color.Silver;
            this.txtPassword.BorderSize = 0;
            this.txtPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPassword.FocusedBaseColor = System.Drawing.Color.White;
            this.txtPassword.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txtPassword.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(231, 134);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.Radius = 12;
            this.txtPassword.Size = new System.Drawing.Size(298, 27);
            this.txtPassword.TabIndex = 17;
            this.txtPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // txtUsuario
            // 
            this.txtUsuario.BackColor = System.Drawing.Color.Transparent;
            this.txtUsuario.BaseColor = System.Drawing.Color.White;
            this.txtUsuario.BorderColor = System.Drawing.Color.Silver;
            this.txtUsuario.BorderSize = 0;
            this.txtUsuario.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUsuario.FocusedBaseColor = System.Drawing.Color.White;
            this.txtUsuario.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txtUsuario.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.Location = new System.Drawing.Point(231, 69);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.PasswordChar = '\0';
            this.txtUsuario.Radius = 12;
            this.txtUsuario.Size = new System.Drawing.Size(298, 27);
            this.txtUsuario.TabIndex = 16;
            this.txtUsuario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chbMostrarContraseña
            // 
            this.chbMostrarContraseña.BackColor = System.Drawing.Color.Transparent;
            this.chbMostrarContraseña.BaseColor = System.Drawing.Color.Transparent;
            this.chbMostrarContraseña.CheckedOffColor = System.Drawing.Color.White;
            this.chbMostrarContraseña.CheckedOnColor = System.Drawing.Color.Lime;
            this.chbMostrarContraseña.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chbMostrarContraseña.FillColor = System.Drawing.Color.White;
            this.chbMostrarContraseña.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbMostrarContraseña.Location = new System.Drawing.Point(232, 167);
            this.chbMostrarContraseña.Name = "chbMostrarContraseña";
            this.chbMostrarContraseña.Size = new System.Drawing.Size(131, 20);
            this.chbMostrarContraseña.TabIndex = 13;
            this.chbMostrarContraseña.Text = "Mostrar contraseña";
            this.chbMostrarContraseña.CheckedChanged += new System.EventHandler(this.chbMostrarContraseña_CheckedChanged);
            // 
            // btnIngresar
            // 
            this.btnIngresar.AnimationHoverSpeed = 0.07F;
            this.btnIngresar.AnimationSpeed = 0.03F;
            this.btnIngresar.BackColor = System.Drawing.Color.Transparent;
            this.btnIngresar.BaseColor = System.Drawing.Color.Black;
            this.btnIngresar.BorderColor = System.Drawing.Color.Black;
            this.btnIngresar.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnIngresar.FocusedColor = System.Drawing.Color.Empty;
            this.btnIngresar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIngresar.ForeColor = System.Drawing.Color.White;
            this.btnIngresar.Image = null;
            this.btnIngresar.ImageSize = new System.Drawing.Size(20, 20);
            this.btnIngresar.Location = new System.Drawing.Point(231, 216);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.OnHoverBaseColor = System.Drawing.Color.Green;
            this.btnIngresar.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnIngresar.OnHoverForeColor = System.Drawing.Color.White;
            this.btnIngresar.OnHoverImage = null;
            this.btnIngresar.OnPressedColor = System.Drawing.Color.Black;
            this.btnIngresar.Radius = 20;
            this.btnIngresar.Size = new System.Drawing.Size(351, 38);
            this.btnIngresar.TabIndex = 12;
            this.btnIngresar.Text = "INGRESAR";
            this.btnIngresar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(227, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 24);
            this.label2.TabIndex = 11;
            this.label2.Text = "Contraseña";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(227, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 24);
            this.label1.TabIndex = 10;
            this.label1.Text = "Usuario";
            // 
            // lblTituloDeFormularioHijo
            // 
            this.lblTituloDeFormularioHijo.AutoSize = true;
            this.lblTituloDeFormularioHijo.BackColor = System.Drawing.Color.Transparent;
            this.lblTituloDeFormularioHijo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloDeFormularioHijo.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblTituloDeFormularioHijo.Location = new System.Drawing.Point(325, 9);
            this.lblTituloDeFormularioHijo.Name = "lblTituloDeFormularioHijo";
            this.lblTituloDeFormularioHijo.Size = new System.Drawing.Size(152, 24);
            this.lblTituloDeFormularioHijo.TabIndex = 9;
            this.lblTituloDeFormularioHijo.Text = "INICIO SESION";
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
            this.btnSalir.FocusedColor = System.Drawing.Color.Empty;
            this.btnSalir.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ForeColor = System.Drawing.Color.White;
            this.btnSalir.Image = null;
            this.btnSalir.ImageSize = new System.Drawing.Size(20, 20);
            this.btnSalir.Location = new System.Drawing.Point(596, 0);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.OnHoverBaseColor = System.Drawing.Color.DarkRed;
            this.btnSalir.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnSalir.OnHoverForeColor = System.Drawing.Color.White;
            this.btnSalir.OnHoverImage = null;
            this.btnSalir.OnPressedColor = System.Drawing.Color.Black;
            this.btnSalir.Radius = 8;
            this.btnSalir.Size = new System.Drawing.Size(31, 28);
            this.btnSalir.TabIndex = 3;
            this.btnSalir.Text = "X";
            this.btnSalir.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 266);
            this.Controls.Add(this.gunaPictureBox1);
            this.Controls.Add(this.gunaGradientPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormLogin";
            ((System.ComponentModel.ISupportInitialize)(this.gunaPictureBox1)).EndInit();
            this.gunaGradientPanel1.ResumeLayout(false);
            this.gunaGradientPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI.WinForms.GunaGradientPanel gunaGradientPanel1;
        private Guna.UI.WinForms.GunaPictureBox gunaPictureBox1;
        private Guna.UI.WinForms.GunaButton btnSalir;
        private Guna.UI.WinForms.GunaCheckBox chbMostrarContraseña;
        private Guna.UI.WinForms.GunaButton btnIngresar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTituloDeFormularioHijo;
        private System.Windows.Forms.Label label1;
        private Guna.UI.WinForms.GunaTextBox txtUsuario;
        private Guna.UI.WinForms.GunaTextBox txtPassword;
        private System.Windows.Forms.Label lblMsjError;
    }
}