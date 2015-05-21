namespace DCAddIn
{
    partial class InspectorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InspectorForm));
            this.inspectorGridControl = new DevExpress.XtraGrid.GridControl();
            this.inspectorGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDocumentoID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAno = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNumFileFisico = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAnoFile = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTipoID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colProcesoID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colNombre = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNombreFile = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMercado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCodigoCliente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNombreCliente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNota = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCuentaID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReciever = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSender = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaHora = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaHoraProceso = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCarpeta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNumFile = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIdentificador = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colArchivo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.formAssistant1 = new DevExpress.XtraBars.FormAssistant();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.refrescarBarButtonItem = new DevExpress.XtraBars.BarButtonItem();
            this.borrarBarButtonItem = new DevExpress.XtraBars.BarButtonItem();
            this.editarBarButtonItem = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            ((System.ComponentModel.ISupportInitialize)(this.inspectorGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inspectorGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // inspectorGridControl
            // 
            this.inspectorGridControl.Cursor = System.Windows.Forms.Cursors.Default;
            this.inspectorGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inspectorGridControl.Location = new System.Drawing.Point(0, 140);
            this.inspectorGridControl.MainView = this.inspectorGridView;
            this.inspectorGridControl.Name = "inspectorGridControl";
            this.inspectorGridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit1,
            this.repositoryItemLookUpEdit2});
            this.inspectorGridControl.Size = new System.Drawing.Size(1205, 411);
            this.inspectorGridControl.TabIndex = 0;
            this.inspectorGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.inspectorGridView});
            // 
            // inspectorGridView
            // 
            this.inspectorGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDocumentoID,
            this.colAno,
            this.colNumFileFisico,
            this.colAnoFile,
            this.colTipoID,
            this.colProcesoID,
            this.colNombre,
            this.colNombreFile,
            this.colMercado,
            this.colCodigoCliente,
            this.colNombreCliente,
            this.colNota,
            this.colCuentaID,
            this.colReciever,
            this.colSender,
            this.colFechaHora,
            this.colFechaHoraProceso,
            this.colCarpeta,
            this.colNumFile,
            this.colIdentificador,
            this.colArchivo});
            this.inspectorGridView.CustomizationFormBounds = new System.Drawing.Rectangle(940, 389, 216, 180);
            this.inspectorGridView.GridControl = this.inspectorGridControl;
            this.inspectorGridView.GroupCount = 1;
            this.inspectorGridView.Name = "inspectorGridView";
            this.inspectorGridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.inspectorGridView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.inspectorGridView.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.Inplace;
            this.inspectorGridView.OptionsFind.AlwaysVisible = true;
            this.inspectorGridView.OptionsFind.FindFilterColumns = "AnoFile;NombreFile;NombreCliente;CuentaID;Nombre;Nota";
            this.inspectorGridView.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.FindClick;
            this.inspectorGridView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colTipoID, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colDocumentoID, DevExpress.Data.ColumnSortOrder.Descending)});
            this.inspectorGridView.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.InspectorGridView_FocusedRowChanged);
            this.inspectorGridView.AsyncCompleted += new System.EventHandler(this.InspectorGridView_AsyncCompleted);
            this.inspectorGridView.DoubleClick += new System.EventHandler(this.InspectorGridView_DoubleClick);
            // 
            // colDocumentoID
            // 
            this.colDocumentoID.Caption = "ID";
            this.colDocumentoID.FieldName = "DocumentoID";
            this.colDocumentoID.Name = "colDocumentoID";
            this.colDocumentoID.OptionsColumn.AllowEdit = false;
            this.colDocumentoID.OptionsColumn.AllowFocus = false;
            this.colDocumentoID.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colDocumentoID.Width = 32;
            // 
            // colAno
            // 
            this.colAno.Caption = "Año";
            this.colAno.FieldName = "Ano";
            this.colAno.Name = "colAno";
            this.colAno.OptionsColumn.AllowEdit = false;
            this.colAno.OptionsColumn.AllowFocus = false;
            this.colAno.Width = 41;
            // 
            // colNumFileFisico
            // 
            this.colNumFileFisico.Caption = "# File Fisico";
            this.colNumFileFisico.FieldName = "NumFileFisico";
            this.colNumFileFisico.Name = "colNumFileFisico";
            this.colNumFileFisico.OptionsColumn.AllowEdit = false;
            this.colNumFileFisico.OptionsColumn.AllowFocus = false;
            this.colNumFileFisico.Width = 51;
            // 
            // colAnoFile
            // 
            this.colAnoFile.Caption = "File";
            this.colAnoFile.FieldName = "AnoFile";
            this.colAnoFile.Name = "colAnoFile";
            this.colAnoFile.OptionsColumn.AllowEdit = false;
            this.colAnoFile.OptionsColumn.AllowFocus = false;
            this.colAnoFile.Visible = true;
            this.colAnoFile.VisibleIndex = 0;
            this.colAnoFile.Width = 80;
            // 
            // colTipoID
            // 
            this.colTipoID.Caption = "Tipo";
            this.colTipoID.ColumnEdit = this.repositoryItemLookUpEdit1;
            this.colTipoID.FieldName = "TipoID";
            this.colTipoID.Name = "colTipoID";
            this.colTipoID.OptionsColumn.AllowEdit = false;
            this.colTipoID.OptionsColumn.AllowFocus = false;
            this.colTipoID.Visible = true;
            this.colTipoID.VisibleIndex = 6;
            this.colTipoID.Width = 56;
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            // 
            // colProcesoID
            // 
            this.colProcesoID.Caption = "Elemento";
            this.colProcesoID.ColumnEdit = this.repositoryItemLookUpEdit2;
            this.colProcesoID.FieldName = "ProcesoID";
            this.colProcesoID.Name = "colProcesoID";
            this.colProcesoID.OptionsColumn.AllowEdit = false;
            this.colProcesoID.OptionsColumn.AllowFocus = false;
            this.colProcesoID.Visible = true;
            this.colProcesoID.VisibleIndex = 4;
            this.colProcesoID.Width = 68;
            // 
            // repositoryItemLookUpEdit2
            // 
            this.repositoryItemLookUpEdit2.AutoHeight = false;
            this.repositoryItemLookUpEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit2.Name = "repositoryItemLookUpEdit2";
            // 
            // colNombre
            // 
            this.colNombre.Caption = "Asunto / Nombre";
            this.colNombre.FieldName = "Nombre";
            this.colNombre.Name = "colNombre";
            this.colNombre.OptionsColumn.AllowEdit = false;
            this.colNombre.OptionsColumn.AllowFocus = false;
            this.colNombre.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colNombre.Visible = true;
            this.colNombre.VisibleIndex = 5;
            this.colNombre.Width = 218;
            // 
            // colNombreFile
            // 
            this.colNombreFile.Caption = "Nombre del File";
            this.colNombreFile.FieldName = "NombreFile";
            this.colNombreFile.Name = "colNombreFile";
            this.colNombreFile.OptionsColumn.AllowEdit = false;
            this.colNombreFile.OptionsColumn.AllowFocus = false;
            this.colNombreFile.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colNombreFile.Visible = true;
            this.colNombreFile.VisibleIndex = 1;
            this.colNombreFile.Width = 106;
            // 
            // colMercado
            // 
            this.colMercado.Caption = "Mercado";
            this.colMercado.FieldName = "Mercado";
            this.colMercado.Name = "colMercado";
            this.colMercado.OptionsColumn.AllowEdit = false;
            this.colMercado.OptionsColumn.AllowFocus = false;
            this.colMercado.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colMercado.Visible = true;
            this.colMercado.VisibleIndex = 2;
            this.colMercado.Width = 101;
            // 
            // colCodigoCliente
            // 
            this.colCodigoCliente.Caption = "Código Cliente";
            this.colCodigoCliente.FieldName = "CodigoCliente";
            this.colCodigoCliente.Name = "colCodigoCliente";
            this.colCodigoCliente.OptionsColumn.AllowEdit = false;
            this.colCodigoCliente.OptionsColumn.AllowFocus = false;
            this.colCodigoCliente.Width = 44;
            // 
            // colNombreCliente
            // 
            this.colNombreCliente.Caption = "Nombre Cliente";
            this.colNombreCliente.FieldName = "NombreCliente";
            this.colNombreCliente.Name = "colNombreCliente";
            this.colNombreCliente.OptionsColumn.AllowEdit = false;
            this.colNombreCliente.OptionsColumn.AllowFocus = false;
            this.colNombreCliente.Visible = true;
            this.colNombreCliente.VisibleIndex = 3;
            this.colNombreCliente.Width = 87;
            // 
            // colNota
            // 
            this.colNota.FieldName = "Nota";
            this.colNota.Name = "colNota";
            this.colNota.OptionsColumn.AllowEdit = false;
            this.colNota.OptionsColumn.AllowFocus = false;
            this.colNota.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colNota.Visible = true;
            this.colNota.VisibleIndex = 6;
            this.colNota.Width = 178;
            // 
            // colCuentaID
            // 
            this.colCuentaID.Caption = "Cuenta";
            this.colCuentaID.FieldName = "CuentaID";
            this.colCuentaID.Name = "colCuentaID";
            this.colCuentaID.OptionsColumn.AllowEdit = false;
            this.colCuentaID.OptionsColumn.AllowFocus = false;
            this.colCuentaID.Visible = true;
            this.colCuentaID.VisibleIndex = 7;
            this.colCuentaID.Width = 90;
            // 
            // colReciever
            // 
            this.colReciever.Caption = "Recibido por:";
            this.colReciever.FieldName = "Reciever";
            this.colReciever.Name = "colReciever";
            this.colReciever.OptionsColumn.AllowEdit = false;
            this.colReciever.OptionsColumn.AllowFocus = false;
            this.colReciever.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colReciever.OptionsColumn.AllowIncrementalSearch = false;
            this.colReciever.OptionsFilter.AllowAutoFilter = false;
            this.colReciever.OptionsFilter.AllowFilter = false;
            this.colReciever.Visible = true;
            this.colReciever.VisibleIndex = 9;
            // 
            // colSender
            // 
            this.colSender.Caption = "Enviado por:";
            this.colSender.FieldName = "Sender";
            this.colSender.Name = "colSender";
            this.colSender.OptionsColumn.AllowEdit = false;
            this.colSender.OptionsColumn.AllowFocus = false;
            this.colSender.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colSender.OptionsColumn.AllowIncrementalSearch = false;
            this.colSender.OptionsFilter.AllowAutoFilter = false;
            this.colSender.OptionsFilter.AllowFilter = false;
            this.colSender.Visible = true;
            this.colSender.VisibleIndex = 10;
            this.colSender.Width = 130;
            // 
            // colFechaHora
            // 
            this.colFechaHora.Caption = "Fecha";
            this.colFechaHora.FieldName = "FechaHora";
            this.colFechaHora.Name = "colFechaHora";
            this.colFechaHora.OptionsColumn.AllowEdit = false;
            this.colFechaHora.OptionsColumn.AllowFocus = false;
            this.colFechaHora.Visible = true;
            this.colFechaHora.VisibleIndex = 8;
            this.colFechaHora.Width = 78;
            // 
            // colFechaHoraProceso
            // 
            this.colFechaHoraProceso.Caption = "Fecha Proceso";
            this.colFechaHoraProceso.FieldName = "FechaHoraProceso";
            this.colFechaHoraProceso.Name = "colFechaHoraProceso";
            this.colFechaHoraProceso.OptionsColumn.AllowEdit = false;
            this.colFechaHoraProceso.OptionsColumn.AllowFocus = false;
            this.colFechaHoraProceso.OptionsColumn.AllowIncrementalSearch = false;
            this.colFechaHoraProceso.Width = 87;
            // 
            // colCarpeta
            // 
            this.colCarpeta.FieldName = "Carpeta";
            this.colCarpeta.Name = "colCarpeta";
            this.colCarpeta.OptionsColumn.AllowEdit = false;
            this.colCarpeta.OptionsColumn.AllowFocus = false;
            this.colCarpeta.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colCarpeta.OptionsColumn.AllowIncrementalSearch = false;
            this.colCarpeta.OptionsFilter.AllowAutoFilter = false;
            this.colCarpeta.OptionsFilter.AllowFilter = false;
            this.colCarpeta.Width = 41;
            // 
            // colNumFile
            // 
            this.colNumFile.Caption = "Número Cotización";
            this.colNumFile.FieldName = "NumFile";
            this.colNumFile.Name = "colNumFile";
            this.colNumFile.OptionsColumn.AllowEdit = false;
            this.colNumFile.OptionsColumn.AllowFocus = false;
            this.colNumFile.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colNumFile.OptionsColumn.AllowIncrementalSearch = false;
            this.colNumFile.OptionsFilter.AllowAutoFilter = false;
            this.colNumFile.OptionsFilter.AllowFilter = false;
            this.colNumFile.Width = 49;
            // 
            // colIdentificador
            // 
            this.colIdentificador.FieldName = "Identificador";
            this.colIdentificador.Name = "colIdentificador";
            this.colIdentificador.OptionsColumn.AllowEdit = false;
            this.colIdentificador.OptionsColumn.AllowFocus = false;
            this.colIdentificador.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colIdentificador.OptionsColumn.AllowIncrementalSearch = false;
            this.colIdentificador.OptionsFilter.AllowAutoFilter = false;
            this.colIdentificador.OptionsFilter.AllowFilter = false;
            this.colIdentificador.Width = 41;
            // 
            // colArchivo
            // 
            this.colArchivo.FieldName = "Archivo";
            this.colArchivo.Name = "colArchivo";
            this.colArchivo.OptionsColumn.AllowEdit = false;
            this.colArchivo.OptionsColumn.AllowFocus = false;
            this.colArchivo.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colArchivo.OptionsColumn.AllowIncrementalSearch = false;
            this.colArchivo.OptionsFilter.AllowAutoFilter = false;
            this.colArchivo.OptionsFilter.AllowFilter = false;
            this.colArchivo.Width = 41;
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Office 2010 Silver";
            this.defaultLookAndFeel1.LookAndFeel.TouchUIMode = DevExpress.LookAndFeel.TouchUIMode.False;
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.refrescarBarButtonItem,
            this.borrarBarButtonItem,
            this.editarBarButtonItem});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 4;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010;
            this.ribbonControl1.Size = new System.Drawing.Size(1205, 140);
            this.ribbonControl1.StatusBar = this.ribbonStatusBar1;
            // 
            // refrescarBarButtonItem
            // 
            this.refrescarBarButtonItem.Caption = "Refrescar";
            this.refrescarBarButtonItem.Glyph = ((System.Drawing.Image)(resources.GetObject("refrescarBarButtonItem.Glyph")));
            this.refrescarBarButtonItem.Id = 1;
            this.refrescarBarButtonItem.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("refrescarBarButtonItem.LargeGlyph")));
            this.refrescarBarButtonItem.Name = "refrescarBarButtonItem";
            this.refrescarBarButtonItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.RefrescarBarButtonItem_ItemClick);
            // 
            // borrarBarButtonItem
            // 
            this.borrarBarButtonItem.Caption = "Borrar";
            this.borrarBarButtonItem.Glyph = ((System.Drawing.Image)(resources.GetObject("borrarBarButtonItem.Glyph")));
            this.borrarBarButtonItem.Id = 2;
            this.borrarBarButtonItem.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("borrarBarButtonItem.LargeGlyph")));
            this.borrarBarButtonItem.Name = "borrarBarButtonItem";
            this.borrarBarButtonItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BorrarBarButtonItem_ItemClick);
            // 
            // editarBarButtonItem
            // 
            this.editarBarButtonItem.Caption = "Editar";
            this.editarBarButtonItem.Glyph = ((System.Drawing.Image)(resources.GetObject("editarBarButtonItem.Glyph")));
            this.editarBarButtonItem.Id = 3;
            this.editarBarButtonItem.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("editarBarButtonItem.LargeGlyph")));
            this.editarBarButtonItem.Name = "editarBarButtonItem";
            this.editarBarButtonItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.EditarBarButtonItem_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Share Center";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.refrescarBarButtonItem);
            this.ribbonPageGroup1.ItemLinks.Add(this.editarBarButtonItem, true);
            this.ribbonPageGroup1.ItemLinks.Add(this.borrarBarButtonItem);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Acciones";
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 493);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this.ribbonControl1;
            this.ribbonStatusBar1.Size = new System.Drawing.Size(1019, 25);
            // 
            // InspectorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1205, 551);
            this.Controls.Add(this.inspectorGridControl);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "InspectorForm";
            this.Text = "Share Center - Inspector";
            ((System.ComponentModel.ISupportInitialize)(this.inspectorGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inspectorGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl inspectorGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView inspectorGridView;
        private DevExpress.XtraGrid.Columns.GridColumn colDocumentoID;
        private DevExpress.XtraGrid.Columns.GridColumn colTipoID;
        private DevExpress.XtraGrid.Columns.GridColumn colNombre;
        private DevExpress.XtraGrid.Columns.GridColumn colNota;
        private DevExpress.XtraGrid.Columns.GridColumn colCuentaID;
        private DevExpress.XtraGrid.Columns.GridColumn colReciever;
        private DevExpress.XtraGrid.Columns.GridColumn colSender;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaHora;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaHoraProceso;
        private DevExpress.XtraGrid.Columns.GridColumn colCarpeta;
        private DevExpress.XtraGrid.Columns.GridColumn colAno;
        private DevExpress.XtraGrid.Columns.GridColumn colNumFile;
        private DevExpress.XtraGrid.Columns.GridColumn colNumFileFisico;
        private DevExpress.XtraGrid.Columns.GridColumn colAnoFile;
        private DevExpress.XtraGrid.Columns.GridColumn colIdentificador;
        private DevExpress.XtraGrid.Columns.GridColumn colArchivo;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colProcesoID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit2;
        private DevExpress.XtraBars.FormAssistant formAssistant1;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraBars.BarButtonItem refrescarBarButtonItem;
        private DevExpress.XtraBars.BarButtonItem borrarBarButtonItem;
        private DevExpress.XtraBars.BarButtonItem editarBarButtonItem;
        private DevExpress.XtraGrid.Columns.GridColumn colNombreFile;
        private DevExpress.XtraGrid.Columns.GridColumn colMercado;
        private DevExpress.XtraGrid.Columns.GridColumn colCodigoCliente;
        private DevExpress.XtraGrid.Columns.GridColumn colNombreCliente;

    }
}