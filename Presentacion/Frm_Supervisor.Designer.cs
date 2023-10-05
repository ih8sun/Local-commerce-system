namespace Presentacion
{
    partial class Frm_Supervisor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Supervisor));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.reportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reporrtesDeProductosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.marcaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesDeComprasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.porFechasToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesDeVentasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.porFechasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reportesToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1016, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // reportesToolStripMenuItem
            // 
            this.reportesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reporrtesDeProductosToolStripMenuItem,
            this.reportesDeComprasToolStripMenuItem,
            this.reportesDeVentasToolStripMenuItem});
            this.reportesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("reportesToolStripMenuItem.Image")));
            this.reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            this.reportesToolStripMenuItem.Size = new System.Drawing.Size(91, 20);
            this.reportesToolStripMenuItem.Text = "Reportes";
            // 
            // reporrtesDeProductosToolStripMenuItem
            // 
            this.reporrtesDeProductosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.marcaToolStripMenuItem});
            this.reporrtesDeProductosToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("reporrtesDeProductosToolStripMenuItem.Image")));
            this.reporrtesDeProductosToolStripMenuItem.Name = "reporrtesDeProductosToolStripMenuItem";
            this.reporrtesDeProductosToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.reporrtesDeProductosToolStripMenuItem.Text = "Reporte de Productos Stock";
            this.reporrtesDeProductosToolStripMenuItem.Click += new System.EventHandler(this.reporrtesDeProductosToolStripMenuItem_Click);
            // 
            // marcaToolStripMenuItem
            // 
            this.marcaToolStripMenuItem.Name = "marcaToolStripMenuItem";
            this.marcaToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.marcaToolStripMenuItem.Text = "Marca";
            this.marcaToolStripMenuItem.Click += new System.EventHandler(this.marcaToolStripMenuItem_Click);
            // 
            // reportesDeComprasToolStripMenuItem
            // 
            this.reportesDeComprasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.porFechasToolStripMenuItem2});
            this.reportesDeComprasToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("reportesDeComprasToolStripMenuItem.Image")));
            this.reportesDeComprasToolStripMenuItem.Name = "reportesDeComprasToolStripMenuItem";
            this.reportesDeComprasToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.reportesDeComprasToolStripMenuItem.Text = "Reporte de Compras";
            // 
            // porFechasToolStripMenuItem2
            // 
            this.porFechasToolStripMenuItem2.Image = ((System.Drawing.Image)(resources.GetObject("porFechasToolStripMenuItem2.Image")));
            this.porFechasToolStripMenuItem2.Name = "porFechasToolStripMenuItem2";
            this.porFechasToolStripMenuItem2.Size = new System.Drawing.Size(139, 22);
            this.porFechasToolStripMenuItem2.Text = "Por Fecha";
            this.porFechasToolStripMenuItem2.Click += new System.EventHandler(this.porFechasToolStripMenuItem2_Click);
            // 
            // reportesDeVentasToolStripMenuItem
            // 
            this.reportesDeVentasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.porFechasToolStripMenuItem});
            this.reportesDeVentasToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("reportesDeVentasToolStripMenuItem.Image")));
            this.reportesDeVentasToolStripMenuItem.Name = "reportesDeVentasToolStripMenuItem";
            this.reportesDeVentasToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.reportesDeVentasToolStripMenuItem.Text = "Reporte de Facturacion";
            // 
            // porFechasToolStripMenuItem
            // 
            this.porFechasToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("porFechasToolStripMenuItem.Image")));
            this.porFechasToolStripMenuItem.Name = "porFechasToolStripMenuItem";
            this.porFechasToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.porFechasToolStripMenuItem.Text = "Por Fecha";
            this.porFechasToolStripMenuItem.Click += new System.EventHandler(this.porFechasToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cerrarToolStripMenuItem});
            this.salirToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("salirToolStripMenuItem.Image")));
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.salirToolStripMenuItem.Text = "Salir";
            // 
            // cerrarToolStripMenuItem
            // 
            this.cerrarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cerrarToolStripMenuItem.Image")));
            this.cerrarToolStripMenuItem.Name = "cerrarToolStripMenuItem";
            this.cerrarToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.cerrarToolStripMenuItem.Text = "Cerrar";
            this.cerrarToolStripMenuItem.Click += new System.EventHandler(this.cerrarToolStripMenuItem_Click);
            // 
            // Frm_Supervisor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1016, 546);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Frm_Supervisor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Supervisor";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem reportesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reporrtesDeProductosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportesDeComprasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem porFechasToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem reportesDeVentasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem porFechasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem marcaToolStripMenuItem;
    }
}