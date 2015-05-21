using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DCAddIn
{
    public partial class InspectorFormEdit : DevExpress.XtraEditors.XtraForm
    {
        
        public InspectorFormEdit()
        {
            InitializeComponent();
            DCServicio.DCServicioClient cliente = Globals.ThisAddIn.ClienteServicio;
            List<DCServicio.Tipo> tipos = cliente.GetTipos();

            tipoLookUpEdit.Properties.DropDownRows = 4;
            tipoLookUpEdit.Properties.DisplayMember = "Nombre";
            tipoLookUpEdit.Properties.ValueMember = "TipoID";
            tipoLookUpEdit.Properties.NullText = "Selecione...";
            tipoLookUpEdit.Properties.DataSource = tipos;
            
        }

        public string NombreText
        {
            get
            {
                return nombreTextEdit.Text;
            }

            set
            {
                nombreTextEdit.Text = value;
            }
        }

        public int TipoCombo
        {
            get
            {
                return Convert.ToInt32(tipoLookUpEdit.EditValue);
            }

            set
            {
                tipoLookUpEdit.EditValue = value;
            }
        }

        public string NotaText
        {
            get
            {
                return notaTextEdit.Text;
            }

            set
            {
                notaTextEdit.Text = value;
            }
        }

        public int DocumentoID
        {
            get
            {
                return Convert.ToInt32(documentoIDTextEdit.Text);
            }

            set
            {
                documentoIDTextEdit.Text = value.ToString();
            }
        }

        private void cancelarSimpleButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AceptarSimpleButton_Click(object sender, EventArgs e)
        {
            ModificarDocumento();
        }

        private void ModificarDocumento()
        {
            DCServicio.DCServicioClient cliente = Globals.ThisAddIn.ClienteServicio;

            List<object> datos = new List<object>();

            datos.Add(NombreText);
            datos.Add(NotaText);
            datos.Add(TipoCombo);

            bool resultado = cliente.EditarDocumento(DocumentoID, datos);
            if (resultado == false)
            {
                XtraMessageBox.Show("Hubo un error en el proceso, intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.DialogResult = DialogResult.OK;
            Close();
        }

    }
}
