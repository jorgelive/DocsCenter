using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Xml;
using DevExpress.XtraGrid.Views.Base;
using DCAddIn.DCDataServicio;
using DevExpress.Xpf.Core.ServerMode;
using DevExpress.Data.WcfLinq;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using System.Configuration;
using System.IO;
using System.Data.Services.Client;

namespace DCAddIn
{
    
    public partial class InspectorForm : DevExpress.XtraEditors.XtraForm
    {

        public bool abriendoArchivo = false;
        
        DevExpress.Xpf.Core.ServerMode.Wcf5.WcfInstantFeedbackDataSource source = new DevExpress.Xpf.Core.ServerMode.Wcf5.WcfInstantFeedbackDataSource();
        Entities context = new Entities(new Uri(ConfigurationManager.AppSettings["ubicacionDataServicio"].ToString()));
        public InspectorForm()
        {

            InitializeComponent();

            DCServicio.DCServicioClient cliente = Globals.ThisAddIn.ClienteServicio;
            List<DCServicio.Tipo> tipos = cliente.GetTipos();

            repositoryItemLookUpEdit1.DropDownRows = 3;
            repositoryItemLookUpEdit1.DisplayMember = "Nombre";
            repositoryItemLookUpEdit1.ValueMember = "TipoID";
            repositoryItemLookUpEdit1.NullText = "Selecione...";
            repositoryItemLookUpEdit1.DataSource = tipos;
            
            List<DCServicio.Proceso> procesos = Globals.ThisAddIn.ClienteServicio.GetProcesos();
            cliente.Close();
            repositoryItemLookUpEdit2.DropDownRows = 3;
            repositoryItemLookUpEdit2.DisplayMember = "Nombre";
            repositoryItemLookUpEdit2.ValueMember = "ProcesoID";
            repositoryItemLookUpEdit2.NullText = "Selecione...";
            repositoryItemLookUpEdit2.DataSource = procesos;

            source.DataServiceContext = context;
            context.MergeOption = MergeOption.NoTracking;
            source.Query = context.DocumentoFiles;
            source.KeyExpression = "DocumentoID";
            inspectorGridControl.DataSource = source.Data;
 
        }

        private void AbrirArchivoLocalnet(GridView view, string servidorIP){
            string servidorCarpeta = ConfigurationManager.AppSettings["servidorCarpeta"].ToString();
            string nombreArchivo = view.GetRowCellValue(view.FocusedRowHandle, "Archivo").ToString();
            dynamic fechaHoraProceso = view.GetRowCellValue(view.FocusedRowHandle, "FechaHoraProceso");
            string anoPath = fechaHoraProceso.ToString("yyyy");
            string mesPath = fechaHoraProceso.ToString("MM");
            string diaPath = fechaHoraProceso.ToString("dd");
            string archivoRutaComun = "\\" + servidorCarpeta + "\\" + anoPath + "\\" + mesPath + "\\" + diaPath + "\\" + nombreArchivo;
            bool archivoEncontrado = false;
            if (File.Exists("\\\\" + servidorIP + archivoRutaComun))
            {
                System.Diagnostics.Process.Start("\\\\" + servidorIP + archivoRutaComun);
                archivoEncontrado = true;
            }
            else
            {
                foreach (string key in Globals.ThisAddIn.Servidores.AllKeys)
                {
                    string otroServidorIP = key + "." + Globals.ThisAddIn.Servidores[key];
                    if (otroServidorIP != servidorIP)
                    {
                        if (File.Exists("\\\\" + otroServidorIP + archivoRutaComun))
                        {
                            System.Diagnostics.Process.Start("\\\\" + otroServidorIP + archivoRutaComun);
                            archivoEncontrado = true;
                            break;
                        }

                    }

                }

            }

            if (archivoEncontrado == false)
            {
                XtraMessageBox.Show("El archivo no se ha encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                abriendoArchivo = false;
                return;
            }

            BackgroundWorker timer = new BackgroundWorker();
            timer.DoWork += FileTimer;
            timer.RunWorkerCompleted += FileTimeEnd;
            timer.RunWorkerAsync();
        }

        private void FileTimer(object sender, DoWorkEventArgs e)
        {
            System.Threading.Thread.Sleep(2500);
        }

        private void FileTimeEnd(object sender, RunWorkerCompletedEventArgs e)
        {
            abriendoArchivo = false;
        }

        private void AbrirArchivoWeb(GridView view){
            var userPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\ShareCenter";

            DateTime fechaHoraProceso = Convert.ToDateTime(view.GetRowCellValue(view.FocusedRowHandle, "FechaHoraProceso"));
            string anoPath = fechaHoraProceso.ToString("yyyy");
            string mesPath = fechaHoraProceso.ToString("MM");
            string diaPath = fechaHoraProceso.ToString("dd");

            if (File.Exists(userPath + "\\Download\\" + anoPath + "\\" + mesPath + "\\" + diaPath + "\\" + view.GetRowCellValue(view.FocusedRowHandle, "Archivo")))
            {
                System.Diagnostics.Process.Start(userPath + "\\Download\\" + anoPath + "\\" + mesPath + "\\" + diaPath + "\\" + view.GetRowCellValue(view.FocusedRowHandle, "Archivo"));
                BackgroundWorker timer = new BackgroundWorker();
                timer.DoWork += FileTimer;
                timer.RunWorkerCompleted += FileTimeEnd;
                timer.RunWorkerAsync();
                return;

            }

            DCServicio.DCServicioClient cliente = Globals.ThisAddIn.ClienteServicio;
            int id = Convert.ToInt32(view.GetRowCellValue(view.FocusedRowHandle, "DocumentoID"));

            DCServicio.DCArchivo archivoDescargado = cliente.DescargarDCArchivo(id);

            fechaHoraProceso = archivoDescargado.FechaHoraProceso;
            anoPath = fechaHoraProceso.ToString("yyyy");
            mesPath = fechaHoraProceso.ToString("MM");
            diaPath = fechaHoraProceso.ToString("dd");

            if (!Directory.Exists(userPath))
                Directory.CreateDirectory(userPath);

            if (!Directory.Exists(userPath + "\\Download"))
                Directory.CreateDirectory(userPath + "\\Download");

            if (!Directory.Exists(userPath + "\\Download\\" + anoPath))
                Directory.CreateDirectory(userPath + "\\Download\\" + anoPath);

            if (!Directory.Exists(userPath + "\\" + anoPath + "\\" + mesPath))
                Directory.CreateDirectory(userPath + "\\Download\\" + anoPath + "\\" + mesPath);

            if (!Directory.Exists(userPath + "\\" + anoPath + "\\" + mesPath + "\\" + diaPath))
                Directory.CreateDirectory(userPath + "\\Download\\" + anoPath + "\\" + mesPath + "\\" + diaPath);

            File.WriteAllBytes(userPath + "\\Download\\" + anoPath + "\\" + mesPath + "\\" + diaPath + "\\" + archivoDescargado.Archivo, archivoDescargado.Data);

            if (File.Exists(userPath + "\\Download\\" + anoPath + "\\" + mesPath + "\\" + diaPath + "\\" + archivoDescargado.Archivo))
            {
                System.Diagnostics.Process.Start(userPath + "\\Download\\" + anoPath + "\\" + mesPath + "\\" + diaPath + "\\" + archivoDescargado.Archivo);
                BackgroundWorker timer = new BackgroundWorker();
                timer.DoWork += FileTimer;
                timer.RunWorkerCompleted += FileTimeEnd;
                timer.RunWorkerAsync();
            }
            else
            {
                abriendoArchivo = false;
                XtraMessageBox.Show("El archivo no se ha encontrado, vuelva a intentarlo en 10 minutos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void InspectorGridView_DoubleClick(object sender, EventArgs e)
        {

            if (abriendoArchivo)
            {
                XtraMessageBox.Show("El archivo se esta abriendo por favor espere.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            abriendoArchivo = true;

            string servidorIP = Globals.ThisAddIn.CurrentServer;

            if (servidorIP != "")
            {
                AbrirArchivoLocalnet((GridView)sender, servidorIP);
            }
            else
            {
                AbrirArchivoWeb((GridView)sender);
            }
 
        }

        private void RefrescarBarButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            source.Refresh();
        }

        private void EditarBarButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            EditarDocumentoSeleccionado(inspectorGridView.FocusedRowHandle);
        }

        private int lastEditedHandle;
        private int lastTopIndex;
        private bool enEdicion;

        private void EditarDocumentoSeleccionado(int rowHandle)
        {
            
            if (rowHandle < 0)
                return;
            lastTopIndex = inspectorGridView.TopRowIndex;
            lastEditedHandle = inspectorGridView.FocusedRowHandle;
            InspectorFormEdit editarForm = new InspectorFormEdit();
            editarForm.NombreText = inspectorGridView.GetFocusedRowCellValue("Nombre").ToString();
            editarForm.TipoCombo = Convert.ToInt32(inspectorGridView.GetFocusedRowCellValue("TipoID"));
            editarForm.DocumentoID = Convert.ToInt32(inspectorGridView.GetFocusedRowCellValue("DocumentoID"));

            if (inspectorGridView.GetFocusedRowCellValue("Nota") != null)
                editarForm.NotaText = inspectorGridView.GetFocusedRowCellValue("Nota").ToString();

            if (editarForm.ShowDialog(this) == DialogResult.OK)
            {
                enEdicion = true;
                source.Refresh();
            }
            
        }

        private void InspectorGridView_AsyncCompleted(object sender, EventArgs e)
        {
            if (!enEdicion)
            {
                return;
            }

            ComprobarEditable();
            
            inspectorGridView.FocusedRowHandle = lastEditedHandle;
            inspectorGridView.TopRowIndex = lastTopIndex;
        }

        private void ComprobarEditable()
        {
            string cuenta = inspectorGridView.GetFocusedRowCellValue("CuentaID").ToString();

            if (Globals.ThisAddIn.UserNameList.Contains(cuenta) || Globals.ThisAddIn.EsAdministrador)
            {
                editarBarButtonItem.Enabled = true;
                borrarBarButtonItem.Enabled = true;
            }
            else
            {
                editarBarButtonItem.Enabled = false;
                borrarBarButtonItem.Enabled = false;
            }

        }


        private void BorrarBarButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            BorrarDocumentoSeleccionado(inspectorGridView.FocusedRowHandle);
        }

        private void BorrarDocumentoSeleccionado(int rowHandle)
        {
            if (rowHandle < 0)
                return;
            
            if (XtraMessageBox.Show("Esta seguro que desea eliminar los registros seleccionados del Centro de documentación?", "Confirme la acción", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                DCServicio.DCServicioClient cliente = Globals.ThisAddIn.ClienteServicio;
                bool resultado = cliente.BorrarDocumento(Convert.ToInt32(inspectorGridView.GetFocusedRowCellValue("DocumentoID")));

                if (!resultado)
                {
                    XtraMessageBox.Show("Hubo un error en el proceso, intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                source.Refresh();
            }
        }

        private void InspectorGridView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            try
            {

                ComprobarEditable();
            }
            catch (Exception)
            {
                editarBarButtonItem.Enabled = false;
                borrarBarButtonItem.Enabled = false;
            }
        }


    }
}
