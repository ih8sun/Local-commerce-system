namespace Presentacion
{
    partial class Frm_Inventario_Stock
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
            this.txtconsultar = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Label23 = new System.Windows.Forms.Label();
            this.txtsubtotal = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gdvCliente)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // gdvCliente
            // 
            this.gdvCliente.AllowUserToAddRows = false;
            this.gdvCliente.BackgroundColor = System.Drawing.Color.White;
            this.gdvCliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gdvCliente.Location = new System.Drawing.Point(12, 113);
            this.gdvCliente.Name = "gdvCliente";
            this.gdvCliente.ReadOnly = true;
            this.gdvCliente.Size = new System.Drawing.Size(721, 277);
            this.gdvCliente.TabIndex = 200;
            this.gdvCliente.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gdvCliente_CellContentClick);
            this.gdvCliente.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gdvCliente_CellFormatting);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtconsultar);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(12, 18);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(721, 76);
            this.groupBox3.TabIndex = 199;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Consultar ";
            // 
            // txtconsultar
            // 
            this.txtconsultar.Location = new System.Drawing.Point(69, 32);
            this.txtconsultar.Name = "txtconsultar";
            this.txtconsultar.Size = new System.Drawing.Size(525, 20);
            this.txtconsultar.TabIndex = 138;
            this.txtconsultar.TextChanged += new System.EventHandler(this.txtconsultar_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 138;
            this.label5.Text = "Producto";
            // 
            // Label23
            // 
            this.Label23.AutoSize = true;
            this.Label23.ForeColor = System.Drawing.Color.Black;
            this.Label23.Location = new System.Drawing.Point(548, 399);
            this.Label23.Name = "Label23";
            this.Label23.Size = new System.Drawing.Size(62, 13);
            this.Label23.TabIndex = 201;
            this.Label23.Text = "Stock Total";
            // 
            // txtsubtotal
            // 
            this.txtsubtotal.Enabled = false;
            this.txtsubtotal.Location = new System.Drawing.Point(616, 396);
            this.txtsubtotal.Name = "txtsubtotal";
            this.txtsubtotal.Size = new System.Drawing.Size(117, 20);
            this.txtsubtotal.TabIndex = 202;
            // 
            // Frm_Inventario_Stock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(753, 459);
            this.Controls.Add(this.Label23);
            this.Controls.Add(this.txtsubtotal);
            this.Controls.Add(this.gdvCliente);
            this.Controls.Add(this.groupBox3);
            this.Name = "Frm_Inventario_Stock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inventario Stock";
            this.Load += new System.EventHandler(this.Frm_Inventario_Stock_Load);
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
        internal System.Windows.Forms.Label Label23;
        internal System.Windows.Forms.TextBox txtsubtotal;
    }
}