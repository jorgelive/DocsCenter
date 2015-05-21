using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using Office = Microsoft.Office.Core;
using Outlook = Microsoft.Office.Interop.Outlook;

// TODO:  Siga estos pasos para habilitar el elemento (XML) de la cinta de opciones:

namespace DCAddIn
{
    [ComVisible(true)]
    public class DCRibbon : Office.IRibbonExtensibility
    {
        private Office.IRibbonUI ribbon;

        public DCRibbon()
        {
        }

        #region Miembros de IRibbonExtensibility

        public string GetCustomUI(string ribbonID)
        {
            return GetResourceText("DCAddIn.DCRibbon.xml");
        }

        public string DCEnviarBoton_GetLabel(Office.IRibbonControl control)
        {
            return "Enviar a Share Center";
        }

        public string DCMostrarBoton_GetLabel(Office.IRibbonControl control)
        {
            return "Mostrar Panel";
        }

        #endregion


        #region Devoluciones de llamada de la cinta de opciones
        //Cree aquí métodos de devolución de llamada. Para obtener más información sobre los métodos de devolución de llamada, visite http://go.microsoft.com/fwlink/?LinkID=271226.

        public void Ribbon_Load(Office.IRibbonUI ribbonUI)
        {
            this.ribbon = ribbonUI;
        }

        public void DCEnviarBoton_Click(Office.IRibbonControl control)
        {

            Globals.ThisAddIn.EscribirLog("Ejecutando el envio desde el panel de correos.");
            try
            {
                if (control.Context is Outlook.Selection)
                {
                    Outlook.Selection seleccion = control.Context as Outlook.Selection;
                    for (var i = 1; i <= seleccion.Count; i++)
                    {
                        Outlook.MailItem item = seleccion[i] as Outlook.MailItem;
                        Globals.ThisAddIn.AgregarCorreoPanel(item);
                       
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void DCMostrarBoton_Click(Office.IRibbonControl control)
        {
            Globals.ThisAddIn.DCTaskPane.Visible = true;
            
        }

        #endregion

        #region Aplicaciones auxiliares

        private string GetResourceText(string resourceName)
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            string[] resourceNames = asm.GetManifestResourceNames();
            for (int i = 0; i < resourceNames.Length; ++i)
            {
                if (string.Compare(resourceName, resourceNames[i], StringComparison.OrdinalIgnoreCase) == 0)
                {
                    using (StreamReader resourceReader = new StreamReader(asm.GetManifestResourceStream(resourceNames[i])))
                    {
                        if (resourceReader != null)
                        {
                            return resourceReader.ReadToEnd();
                        }
                    }
                }
            }
            return null;
        }

        #endregion

        
    }
}
