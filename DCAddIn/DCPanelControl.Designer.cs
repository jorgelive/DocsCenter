namespace DCAddIn
{
    partial class DCPanelControl
    {
        /// <summary> 
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar 
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCPanelControl));
            this.itemsGridControl = new DevExpress.XtraGrid.GridControl();
            this.itemsGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.enviarBoton = new DevExpress.XtraEditors.SimpleButton();
            this.inspectorBoton = new DevExpress.XtraEditors.SimpleButton();
            this.archivoBoton = new DevExpress.XtraEditors.SimpleButton();
            this.borrarBoton = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.itemsGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // itemsGridControl
            // 
            this.itemsGridControl.AllowDrop = true;
            this.itemsGridControl.Cursor = System.Windows.Forms.Cursors.Default;
            this.itemsGridControl.Location = new System.Drawing.Point(94, 3);
            this.itemsGridControl.MainView = this.itemsGridView;
            this.itemsGridControl.Name = "itemsGridControl";
            this.itemsGridControl.Size = new System.Drawing.Size(1241, 147);
            this.itemsGridControl.TabIndex = 1;
            this.itemsGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.itemsGridView});
            // 
            // itemsGridView
            // 
            this.itemsGridView.GridControl = this.itemsGridControl;
            this.itemsGridView.Name = "itemsGridView";
            this.itemsGridView.OptionsSelection.MultiSelect = true;
            this.itemsGridView.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.itemsGridView.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.ItemsGridView_CellValueChanged);
            // 
            // enviarBoton
            // 
            this.enviarBoton.Image = ((System.Drawing.Image)(resources.GetObject("enviarBoton.Image")));
            this.enviarBoton.Location = new System.Drawing.Point(3, 84);
            this.enviarBoton.Name = "enviarBoton";
            this.enviarBoton.Size = new System.Drawing.Size(85, 22);
            this.enviarBoton.TabIndex = 2;
            this.enviarBoton.Text = "Procesar";
            this.enviarBoton.Click += new System.EventHandler(this.EnviarButton_Click);
            // 
            // inspectorBoton
            // 
            this.inspectorBoton.Image = ((System.Drawing.Image)(resources.GetObject("inspectorBoton.Image")));
            this.inspectorBoton.Location = new System.Drawing.Point(3, 3);
            this.inspectorBoton.Name = "inspectorBoton";
            this.inspectorBoton.Size = new System.Drawing.Size(85, 22);
            this.inspectorBoton.TabIndex = 3;
            this.inspectorBoton.Text = "Inspector";
            this.inspectorBoton.Click += new System.EventHandler(this.InspectorButton_Click);
            // 
            // archivoBoton
            // 
            this.archivoBoton.Image = ((System.Drawing.Image)(resources.GetObject("archivoBoton.Image")));
            this.archivoBoton.Location = new System.Drawing.Point(3, 31);
            this.archivoBoton.Name = "archivoBoton";
            this.archivoBoton.Size = new System.Drawing.Size(85, 21);
            this.archivoBoton.TabIndex = 4;
            this.archivoBoton.Text = "Archivo";
            this.archivoBoton.Click += new System.EventHandler(this.ArchivoButton_Click);
            // 
            // borrarBoton
            // 
            this.borrarBoton.Image = ((System.Drawing.Image)(resources.GetObject("borrarBoton.Image")));
            this.borrarBoton.Location = new System.Drawing.Point(3, 58);
            this.borrarBoton.Name = "borrarBoton";
            this.borrarBoton.Size = new System.Drawing.Size(85, 20);
            this.borrarBoton.TabIndex = 5;
            this.borrarBoton.Text = "Borrar";
            this.borrarBoton.Click += new System.EventHandler(this.BorrarButton_Click);
            // 
            // DCPanelControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.borrarBoton);
            this.Controls.Add(this.archivoBoton);
            this.Controls.Add(this.inspectorBoton);
            this.Controls.Add(this.enviarBoton);
            this.Controls.Add(this.itemsGridControl);
            this.Name = "DCPanelControl";
            this.Size = new System.Drawing.Size(1350, 154);
            this.Load += new System.EventHandler(this.DCPanelControl_Load);
            this.Resize += new System.EventHandler(this.DCPanelControl_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.itemsGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl itemsGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView itemsGridView;
        private DevExpress.XtraEditors.SimpleButton enviarBoton;
        private DevExpress.XtraEditors.SimpleButton inspectorBoton;
        private DevExpress.XtraEditors.SimpleButton archivoBoton;
        private DevExpress.XtraEditors.SimpleButton borrarBoton;
    }
}
