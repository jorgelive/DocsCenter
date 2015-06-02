using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Xml.Linq;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using DevExpress.XtraEditors;
using Redemption;
using System.Net;
using System.Configuration;
using System.IO;
using System.ServiceModel.Security;
using Microsoft.Win32;
using Microsoft.Office.Interop.Outlook;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;


namespace DCAddIn
{
    
    public partial class ThisAddIn
    {

        private DCPanelControl DCPanelControl;

        private Explorer activeExplorer;

        private List<string> userNameList = new List<string>();

        internal List<string> UserNameList
        {
            get {
                return userNameList; 
            }
            private set {
                userNameList = value; 
            }

        }

        private System.Collections.Specialized.NameValueCollection servidores = new System.Collections.Specialized.NameValueCollection();

        internal System.Collections.Specialized.NameValueCollection Servidores{
            get{
                if (servidores.Count == 0){
                    servidores = ConfigurationManager.GetSection("fileServers") as System.Collections.Specialized.NameValueCollection;
                }
                
                return servidores;
            }
            set{}
        
        }

        private List<string> passwordList = new List<string>();

        internal List<string> PasswordList
        {
            get
            {
                return passwordList;
            }
            private set
            {
                passwordList = value;
            }

        }

        private Dictionary<string, string> parametroList = new Dictionary<string, string>();

        internal Dictionary<string, string> ParametroList
        {
            get
            {
                return parametroList;
            }
            private set
            {
                parametroList = value;
            }

        }

        private void AgregarUsuario(string userName)
        {
            userNameList.Add(userName);
        }

        private void AgregarParametro(string parametro, string valor)
        {
            parametroList.Add(parametro, valor);
        }

        private void AgregarPassword(string password)
        {
            passwordList.Add(password);
        }

        internal string UsuarioConcat
        {
            get{
                
                if (userNameList != null)
                {
                return string.Join("|", userNameList);
                }
                return "";
            }
            set{}
  
        }

        internal string PasswordConcat
        {
            get
            {
                if (passwordList != null)
                {
                    return string.Join("|", passwordList);
                }
                return "";
            }
            set { }
        }

        internal CustomTaskPane DCTaskPane
        {
            get;
            private set;
        }

        private bool esAdministrador;

        internal bool EsAdministrador
        {
            get
            {
                return esAdministrador;
            }
            private set
            {
                esAdministrador = value;
            }
        }

        internal string ObtenerParametroValor(string parametro)
        {
            string valor;
            if (parametroList.TryGetValue(parametro, out valor))
            {
                return valor;

            }
            return "";

        }

        public void EscribirLog(string texto)
        {
           
            if (ObtenerParametroValor("debug") == "1")
            {
                using (EventLog eventLog = new EventLog("Application"))
                {
                    eventLog.Source = "ShareCenter";
                    eventLog.WriteEntry(texto, EventLogEntryType.Information, 101, 1);
                }
            }
            
        }

        internal DCServicio.DCServicioClient ClienteServicio
        {
            get
            {
                DCServicio.DCServicioClient clienteServicio = new DCServicio.DCServicioClient();
                clienteServicio.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.None;
                clienteServicio.ClientCredentials.UserName.UserName = UsuarioConcat;
                clienteServicio.ClientCredentials.UserName.Password = PasswordConcat;
                return clienteServicio;
            }
            private set{}
        }

        private void CrearParametros(bool usuario)
        {
            if (usuario)
            {
                RegistryKey cuentas = Registry.CurrentUser.CreateSubKey("Software\\Gopro\\Vipac Share Center\\Cuentas");
                cuentas.SetValue("cuenta@vipac.pe", "pass1234");
            }
            RegistryKey parametros = Registry.CurrentUser.CreateSubKey("Software\\Gopro\\Vipac Share Center\\Parametros");
            parametros.SetValue("debug", "0");
            parametros.SetValue("preload", "1");
            parametros.SetValue("forzarred", "no");

        }

        private bool LeerUsuarios()
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\Gopro\\Vipac Share Center");
            if (key == null)
            {
                CrearParametros(true);
                return false;
            }
            else
            {
                //adicion de mas claves despues de la instalacion
                bool usuarioExiste = false;
                RegistryKey parametrosExistentes = Registry.CurrentUser.OpenSubKey("Software\\Gopro\\Vipac Share Center\\Parametros");
                if (parametrosExistentes == null)
                {
                    CrearParametros(false);
                }

                foreach (string configuracion in key.GetSubKeyNames())
                {

                    RegistryKey llave = key.OpenSubKey(configuracion);
                    
                    if (configuracion == "Cuentas")
                    {
                        
                        
                        if (llave != null)
                        {
                            foreach (string userName in llave.GetValueNames())
                            {
                                AgregarUsuario(userName);
                                AgregarPassword(llave.GetValue(userName).ToString());
                                usuarioExiste = true;
                            }
                        }

                        
                    }else if(configuracion == "Parametros"){

                        if (llave != null)
                        {
                            foreach (string parametro in llave.GetValueNames())
                            {
                                AgregarParametro(parametro, llave.GetValue(parametro).ToString());
                            }
                        }

                    }
                }

                if (usuarioExiste == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private void ActiveExplorer_SelectionChange()
        {
            System.Windows.Forms.Form frmHack = new System.Windows.Forms.Form();
            frmHack.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            frmHack.Location = new System.Drawing.Point(-1000, -1000);
            frmHack.Size = new System.Drawing.Size(0, 0);
            frmHack.Show();
            frmHack.Close();
            frmHack.Dispose();
            frmHack = null; 
        }

        private void RunTypeInitializers(Assembly a)
        {
            try
            {
                Type[] types = a.GetExportedTypes();
                for (int i = 0; i < types.Length; i++)
                {
                    RuntimeHelpers.RunClassConstructor(types[i].TypeHandle);
                }
            }
            catch
            { 
                EscribirLog("No se pudo ejecutar la acción de precarga.");
            }
        }

        private void Precargar(Type tipo)
        {
            try {
                EscribirLog("Precargando: " + tipo.ToString());
                Assembly assemblyCarga = tipo.Assembly;
                RunTypeInitializers(assemblyCarga); 
            }
                catch { EscribirLog("No se pudo precargar: " + tipo.ToString());

            }
        }

        private void PrecargarLibrerias()
        {
            EscribirLog("Precargando librerias.");

            List<Type> assemblyTypes = new List<Type>();
            //assemblyNames.Add("DevExpress.Xpf.Core.Native.LayoutHelper");
            assemblyTypes.Add(typeof(DevExpress.Xpf.Core.ServerMode.Wcf5.WcfInstantFeedbackDataSource));
            assemblyTypes.Add(typeof(System.Data.Services.Client.DataServiceQuery));
            assemblyTypes.Add(typeof(Microsoft.Data.OData.ODataReader));
            assemblyTypes.Add(typeof(DevExpress.Mvvm.ViewModelBase));
            assemblyTypes.Add(typeof(Microsoft.Data.Edm.EdmLocation));
            assemblyTypes.Add(typeof(DevExpress.XtraBars.Ribbon.ApplicationMenu));
            assemblyTypes.Add(typeof(DevExpress.UserSkins.BonusSkins));
            assemblyTypes.Add(typeof(System.Spatial.Geometry));
            assemblyTypes.Add(typeof(DevExpress.XtraEditors.XtraForm));
            assemblyTypes.Add(typeof(DevExpress.Data.Access.DataListDescriptor));
            assemblyTypes.Add(typeof(DevExpress.XtraGrid.Controls.FindControl));
            assemblyTypes.Add(typeof(DevExpress.XtraTreeList.Columns.TreeListColumnCollection));

            assemblyTypes.ForEach(Precargar);  //tambien se pueden usar delegados

            EscribirLog("Fin de la precarga.");

        }
        
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {

            EscribirLog("Iniciando ShareCenter.");
            activeExplorer = Application.Explorers[1];

            activeExplorer.SelectionChange += ActiveExplorer_SelectionChange;
            
            if (!LeerUsuarios())
            {
                XtraMessageBox.Show("Verifique la configuración de usuario y password en el registro.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            

            DCServicio.DCServicioClient cliente = Globals.ThisAddIn.ClienteServicio;
            try
            {
                List<DCServicio.Tipo> tipos = cliente.GetTipos();
                EsAdministrador = cliente.EsAdministrador(userNameList[0]);
            }
            catch
            {
                XtraMessageBox.Show("Error en la autenticación del Centro de Documentación.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (ObtenerParametroValor("preload") == "1")
            {
                 PrecargarLibrerias();
            }


            DCPanelControl = new DCPanelControl();
            this.DCTaskPane = this.CustomTaskPanes.Add(DCPanelControl, "Centro de Documentación");
            this.DCTaskPane.DockPosition = Office.MsoCTPDockPosition.msoCTPDockPositionBottom;
            this.DCTaskPane.DockPositionRestrict = Office.MsoCTPDockPositionRestrict.msoCTPDockPositionRestrictNoChange;
            this.DCTaskPane.Visible = true;
            this.DCTaskPane.Height = 180;
        }

        internal string CurrentServer
        {
            get
            {
                System.Collections.Specialized.NameValueCollection servidores = ConfigurationManager.GetSection("fileServers") as System.Collections.Specialized.NameValueCollection;
                
                string forzarRed = ObtenerParametroValor("forzarred");
                
                if (forzarRed == "remoto")
                {
                    EscribirLog("Forzando servidor remoto.");

                    return "";

                }
                else if (forzarRed.Count(f => f == '.') == 2)
                {
                    
                    if (servidores[forzarRed] == null)
                    {
                        EscribirLog("No se ha podido forzar servidor, la subred: " + forzarRed + " no existe en los parametros de configuración.");

                        return "";
                    }
                    EscribirLog("Forzando servidor: " + forzarRed + "." + servidores[forzarRed]);

                    return forzarRed + "." + servidores[forzarRed];
                }
                
                string subredActual = "";
                IPAddress[] direccionesIP = Dns.GetHostAddresses(Dns.GetHostName());

                List<string> partes = new List<string>();
                foreach (IPAddress direccionIP in direccionesIP)
                {
                    if (direccionIP.IsIPv6LinkLocal == false)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            partes.Add(direccionIP.GetAddressBytes()[i].ToString());
                        }

                        if (partes.Count() > 0)
                        {
                            subredActual = string.Join(".", partes.ToArray());
                        }

                        break;
                    }
                }

                if (servidores[subredActual] == null)
                {
                    EscribirLog("Se utilizará servidor remoto.");
                    
                    return "";
                }

                EscribirLog("Se utilizará el servidor: " + subredActual + "." + servidores[subredActual]);

                return subredActual + "." + servidores[subredActual];
            }
            set {}

        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }

        internal void AgregarCorreoPanel(Outlook.MailItem item)
        {

            EscribirLog("Procesando el item de correo.");
            
            List<object> datos = ObtenerInfoCorreo(item);

            if (datos[3].ToString() == "")
            {
                EscribirLog("No se pudo obtener la cuenta del mensaje.");
                return;
            }
            
            DataRow[] matches = DCPanelControl.DataSource.Select("Identificador='"+datos[4].ToString()+"'");

            if (matches.Length > 0)
            {
                XtraMessageBox.Show("El item '" + datos[1] + "' ya existe en la lista.", "Datos repetidos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DCPanelControl.ItemsGridControl_AgregarFilaPanel(datos);

            DCPanelControl.ItemsGridView.CloseEditor();
            DCPanelControl.ItemsGridView.UpdateCurrentRow();
    
        }

        private string DescargarCorreo(Outlook.MailItem item, string mensajeID)
        {

            string pathFileName = "";

            try
            {
                pathFileName = ObtenerRutaArchivo("Upload") + mensajeID + ".msg";  //mensajeID.Substring(1, (mensajeID.Length - 2))

                item.SaveAs(pathFileName, Outlook.OlSaveAsType.olMSG);
            }
            catch
            {
                EscribirLog("Hubo un error en la descarga del archivo.");
            }
            return pathFileName;

        }

        public string ObtenerRutaArchivo(string tipo)
        {
            var shareCenterPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\ShareCenter";
            
            if (!Directory.Exists(shareCenterPath))
            {
                Directory.CreateDirectory(shareCenterPath);
            }

            if (!Directory.Exists(shareCenterPath + "\\" + tipo))
            {
                Directory.CreateDirectory(shareCenterPath + "\\" + tipo);
            }

            return shareCenterPath + "\\" + tipo + "\\";

        }

        private List<object> ObtenerInfoCorreo(Outlook.MailItem item)
        {
            EscribirLog("Obteniendo la información de correo.");
            
            List<object> resultado = new List<object>();

            string cuenta = ObtenerCuenta(item.Parent.FolderPath);

            int tipoProceso;

            Outlook.PropertyAccessor propertyAccessor = item.PropertyAccessor;
            string mensajeID = propertyAccessor.GetProperty("http://schemas.microsoft.com/mapi/proptag/0x1035001E").ToString();

            if (mensajeID == "")
            {
                mensajeID = GetInternetMessageIDServer(item);
            }


            if (CurrentServer == "" && ObtenerParametroValor("modoremoto") == "exchange")
            {
                EscribirLog("Se procesa el envio del correo mediante Exchange.");
                tipoProceso = 3;
            }
            else
            {
                tipoProceso = 1;

                mensajeID = DescargarCorreo(item, LimpiarCadena(mensajeID));
                EscribirLog("Se descargó el correo: " + item.Subject.Trim() + " en la ruta:" + mensajeID);
            }

            resultado.Add(tipoProceso); //0
            resultado.Add(item.Subject.Trim()); //1
            resultado.Add(ObtenerFolder(item.Parent.FullFolderPath, cuenta)); //2
            resultado.Add(cuenta); //3
            resultado.Add(mensajeID); //4
            resultado.Add(GetSenderSMTPAddress(item)); //5
            resultado.Add(GetRecipientsSMTPAddress(item)); //6
            resultado.Add(item.SentOn); //7

            return resultado;
        }

        internal string LimpiarCadena(string cadena)
        {
            string file = string.Concat(cadena.Split(System.IO.Path.GetInvalidFileNameChars(), StringSplitOptions.RemoveEmptyEntries));

            if (file.Length > 200)
            {
                file = file.Substring(0, 200);
            }

            return file;
        }

        private string GetRecipientsSMTPAddress(Outlook.MailItem mail)
        {
            EscribirLog("Buscando la información SMTPAddress del destinatario.");

            string cuenta = ObtenerCuenta(mail.Parent.FolderPath);

            string recipientsCadena = "";
     
            const string PR_SMTP_ADDRESS = "http://schemas.microsoft.com/mapi/proptag/0x39FE001E";

            Outlook.Recipients recips = mail.Recipients;

            List<string> destinatarios = new List<string>();

            foreach (Outlook.Recipient recip in recips)
            {
                Outlook.PropertyAccessor pa = recip.PropertyAccessor;
                try
                {
                    string smtpAddress = pa.GetProperty(PR_SMTP_ADDRESS).ToString();

                    EscribirLog("Se ha encontrado y agregado la información SMTPAddress del destinatario: " + smtpAddress);

                    destinatarios.Add(smtpAddress);
                }
                catch
                {
                    EscribirLog("No se han encontrado destinatarios en el correo, se usará la cuenta.");

                    return ObtenerCuenta(mail.Parent.FolderPath);
                }
            }

            if(destinatarios.Count() > 0){

                EscribirLog("Se han encontrado destinatarios en el correo.");

                recipientsCadena = string.Join(", ", destinatarios.ToArray());

                if (recipientsCadena.Length > 500){

                    return recipientsCadena.Substring(0, 500);
                }else{

                    return recipientsCadena;
                }
            }else{
                EscribirLog("No se han encontrado destinatarios en el correo, se usará la cuenta.");

                return ObtenerCuenta(mail.Parent.FolderPath);
            }

        } 

        private string GetSenderSMTPAddress(Outlook.MailItem mail)
        {
            EscribirLog("Buscando la información SMTPAddress del enviante.");
            
            string PR_SMTP_ADDRESS = @"http://schemas.microsoft.com/mapi/proptag/0x39FE001E";

            if (mail.SenderEmailType == "EX")
            {
                Outlook.AddressEntry sender =
                    mail.Sender;
                if (sender != null)
                {
                    if (sender.AddressEntryUserType ==
                        Outlook.OlAddressEntryUserType.
                        olExchangeUserAddressEntry
                        || sender.AddressEntryUserType ==
                        Outlook.OlAddressEntryUserType.
                        olExchangeRemoteUserAddressEntry)
                    {
                        Outlook.ExchangeUser exchUser =
                            sender.GetExchangeUser();
                        if (exchUser != null)
                        {
                            EscribirLog("Retornando la información SMTPAddress del enviante tipo PrimarySmtpAddress.");
                            
                            return exchUser.PrimarySmtpAddress;
                        }
                        else
                        {
                            EscribirLog("Retornando nulo como información SMTPAddress del enviante.");
                            
                            return null;
                        }
                    }
                    else
                    {
                        EscribirLog("Retornando la información SMTPAddress del enviante tipo PR_SMTP_ADDRESS.");
                        
                        return sender.PropertyAccessor.GetProperty(
                            PR_SMTP_ADDRESS) as string;

                    }
                }
                else
                {
                    EscribirLog("Retornando nulo como información SMTPAddress del enviante.");
                    
                    return null;
                }
            }
            else
            {
                EscribirLog("Retornando la información SMTPAddress del enviante existente en el correo.");
                
                return mail.SenderEmailAddress;
            }
        }

        public string GetInternetMessageIDServer(Outlook.MailItem mail)
        {

            EscribirLog("Obteniendo el Internet ID del correo utilizando Redemption.");

            try
            {

                RDOSession session = new RDOSession() { MAPIOBJECT = mail.Session.MAPIOBJECT };

                var StoreEntryID = session.Stores.DefaultStore.EntryID;
                var MAPI_NO_CACHE = 0x200;
                var MAPI_BEST_ACCESS = 0x10;

                string ID = mail.EntryID;

                RDOMail itemServidor;
                try
                {
                    itemServidor = session.GetMessageFromID(ID, StoreEntryID, MAPI_NO_CACHE | MAPI_BEST_ACCESS);

                }
                catch (System.Exception ex)
                {
                    var a = ex;
                    return null;
                }

                string resultado = itemServidor.Fields["http://schemas.microsoft.com/mapi/proptag/0x1035001F"];

                EscribirLog("El Internet ID del correo devuelto por Redemption es: " + resultado);

                return resultado;

            }
            catch
            {
                if (CurrentServer == "" && ObtenerParametroValor("modoremoto") == "exchange")
                {
                    XtraMessageBox.Show("Es necesario se instale Redemption, solicite al area de sistemas su instalación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return "";
                }
                else
                {
                    var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                    var random = new Random();
                    string randomString = new string(
                    Enumerable.Repeat(chars, 70)
                    .Select(s => s[random.Next(s.Length)])
                    .ToArray()
                    );
                    return randomString;

                }

            }

        }

        private string ObtenerFolder(string cadena, string cuenta)
        {
            Match match = Regex.Match(cadena, @"\\\\"+ cuenta + @"\\(.*)",
                RegexOptions.IgnoreCase);

            if (match.Success)
            {
                return match.Groups[1].Value;
            }

            return "Fuente Externa";
        }

        private string ObtenerCuenta(string cadena)
        {

            Match match = Regex.Match(cadena, @"\\\\([^\\]*)",
                RegexOptions.IgnoreCase);
            if (match.Success)
            {

                if (userNameList.IndexOf(match.Groups[1].Value) == -1)
                {
                    if(CurrentServer == "" && ObtenerParametroValor("modoremoto") == "exchange"){
                        XtraMessageBox.Show("La cuenta de correo no esta configurada en el archivo de preferencias, en modo exchange no se permite el envio de archivos de cuentas co configuradas o archivos externos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        
                        return "";

                    }
                    else
                    {
                        
                        return userNameList.First();
                    }
                }
                else
                {
                    return match.Groups[1].Value;
                }
               
            }

            return "";
        }

        protected override Microsoft.Office.Core.IRibbonExtensibility CreateRibbonExtensibilityObject()
        {
            return new DCRibbon();
        }
    

        #region Código generado por VSTO

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}
