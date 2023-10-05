namespace Presentacion
{
    partial class Frm_Consulta_Cliente
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
            this.gdvCliente = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboforma = new System.Windows.Forms.ComboBox();
            this.txtconsultar = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtfactura = new System.Windows.Forms.TextBox();
            this.txtobservacion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtforma = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gdvCliente)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // gdvCliente
            // 
            this.gdvCliente.AllowUserToAddRows = false;
            this.gdvCliente.BackgroundColor = System.Drawing.Color.White;
            this.gdvCliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gdvCliente.Location = new System.Drawing.Point(22, 112);
            this.gdvCliente.Name = "gdvCliente";
            this.gdvCliente.ReadOnly = true;
            this.gdvCliente.Size = new System.Drawing.Size(883, 251);
            this.gdvCliente.TabIndex = 183;
            this.gdvCliente.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gdvCliente_CellContentClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.cboforma);
            this.groupBox3.Controls.Add(this.txtconsultar);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(22, 17);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(883, 76);
            this.groupBox3.TabIndex = 182;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Consultar ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(520, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 140;
            this.label1.Text = "Forma de Pago";
            // 
            // cboforma
            // 
            this.cboforma.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboforma.FormattingEnabled = true;
            this.cboforma.Items.AddRange(new object[] {
            "Contado",
            "Credito",
            "Cancelado"});
            this.cboforma.Location = new System.Drawing.Point(620, 31);
            this.cboforma.Name = "cboforma";
            this.cboforma.Size = new System.Drawing.Size(241, 21);
            this.cboforma.TabIndex = 139;
            this.cboforma.SelectedIndexChanged += new System.EventHandler(this.cboforma_SelectedIndexChanged);
            // 
            // txtconsultar
            // 
            this.txtconsultar.Location = new System.Drawing.Point(79, 32);
            this.txtconsultar.Name = "txtconsultar";
            this.txtconsultar.Size = new System.Drawing.Size(400, 20);
            this.txtconsultar.TabIndex = 138;
            this.txtconsultar.TextChanged += new System.EventHandler(this.txtconsultar_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 138;
            this.label5.Text = "Cliente";
            // 
            // txtfactura
            // 
            this.txtfactura.Location = new System.Drawing.Point(305, 263);
            this.txtfactura.Name = "txtfactura";
            this.txtfactura.Size = new System.Drawing.Size(100, 20);
            this.txtfactura.TabIndex = 184;
            // 
            // txtobservacion
            // 
            this.txtobservacion.Location = new System.Drawing.Point(521, 252);
            this.txtobservacion.Name = "txtobservacion";
            this.txtobservacion.Size = new System.Drawing.Size(100, 20);
            this.txtobservacion.TabIndex = 185;
            this.txtobservacion.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 141;
            this.label2.Text = "Seleccionar ";
            // 
            // txtforma
            // 
            this.txtforma.Location = new System.Drawing.Point(340, 233);
            this.txtforma.Name = "txtforma";
            this.txtforma.Size = new System.Drawing.Size(100, 20);
            this.txtforma.TabIndex = 187;
            this.txtforma.Text = "3";
            // 
            // Frm_Consulta_Cliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(917, 443);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gdvCliente);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.txtobservacion);
            this.Controls.Add(this.txtfactura);
            this.Controls.Add(this.txtforma);
            this.Name = "Frm_Consulta_Cliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta Cliente  (Contado - Credito) Facturacion";
            this.Load += new System.EventHandler(this.Frm_Consulta_Cliente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gdvCliente)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gdvCliente;
        private System.Windows.Forms.GroupBox groupBox3;
        internal System.Windows.Forms.TextBox txtconsultar;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboforma;
        private System.Windows.Forms.TextBox txtfactura;
        private System.Windows.Forms.TextBox txtobservacion;
        internal System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtforma;
    }
}