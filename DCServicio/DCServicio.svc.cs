using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.IO;
using Microsoft.Exchange.WebServices.Data;
using System.Data;
using System.Configuration;
using Binbin.Linq;

namespace DCServicio
{
    public class DCServicio : IDCServicio
    {
        public FilePrincipal GetFilePrincipalByAnoFile(string anoFile)
        {
            DCModelo.Entities contexto;

            using (contexto = new DCModelo.Entities())
            {
                DCModelo.FilePrincipal file = contexto.FilePrincipals.Where(f => f.AnoFile == anoFile).FirstOrDefault();
                FilePrincipal resultado = new FilePrincipal();
                if (file == null)
                {
                    return resultado;
                }
                resultado.Ano = file.Ano;
                resultado.NumFile = file.NumFile;
                resultado.NumFileFisico = file.NumFileFisico;
                resultado.Nombre = file.Nombre;
                resultado.AnoFile = file.AnoFile;
                resultado.Mercado = file.Mercado;
                return resultado;
            }
        }

        public List<Tipo> GetTipos()
        {
            DCModelo.Entities contexto;
            List<Tipo> resultado = new List<Tipo>();
            using (contexto = new DCModelo.Entities())
            {
                foreach (DCModelo.Tipo tipo in contexto.Tipoes){
                    Tipo fila = new Tipo();
                    fila.TipoID = tipo.TipoID;
                    fila.Nombre = tipo.Nombre;
                    resultado.Add(fila);
                }
                return resultado;
            }
        }

        public List<Proceso> GetProcesos()
        {

            DCModelo.Entities contexto;
            List<Proceso> resultado = new List<Proceso>();
            using (contexto = new DCModelo.Entities())
            {
                foreach (DCModelo.Proceso tipo in contexto.Procesoes)
                {
                    Proceso fila = new Proceso();
                    fila.ProcesoID = tipo.ProcesoID;
                    fila.Nombre = tipo.Nombre;
                    resultado.Add(fila);
                }
                return resultado;
            }

        }

        public List<int> ProcesarCorreos(List<DataTable> tablas)
        {

            List<int> resultado = new List<int>();

            foreach (DataTable tabla in tablas)
            {
                string cuentaID = tabla.Rows[0]["cuentaID"].ToString();
                DCModelo.Entities contexto;
                DCModelo.Cuenta cuenta;
                using (contexto = new DCModelo.Entities())
                {
                    cuenta = contexto.Cuentas.Find(cuentaID);
                    if (cuenta == null)
                    {
                        return resultado;
                    }
                }
                
                ExchangeService ExService = new ExchangeService();
                ExService.UseDefaultCredentials = true;
                ExService.Credentials = new WebCredentials(cuentaID, cuenta.PasswordCorreo);
                ExService.AutodiscoverUrl(cuentaID, (a) =>
                {
                    return true;
                });

                List<string> mensajesID = tabla.AsEnumerable().Select(x => x["Identificador"].ToString()).ToList();
                DataTable itemsRecibidos = DescargarItemByInternetMessageId(mensajesID, ExService);

                foreach (DataRow filaRecibida in itemsRecibidos.Rows)
                {

                    DataRow[] filasEnviadas = tabla.Select("Identificador='" + filaRecibida["Identificador"] + "'");
                    bool correcto = GuardarCorreoDB(filaRecibida, filasEnviadas[0]);
                    if (correcto == true)
                    {
                        dynamic ID = filasEnviadas[0]["ID"];
                        resultado.Add(ID);
                    }
                }

            }
            return resultado;
        }

        public List<int> ProcesarArchivos(List<InfoArchivo> listaInformacion)
        {

            List<int> resultado = new List<int>();

            foreach (InfoArchivo informacion in listaInformacion)
            {

                bool correcto = GuardarArchivoDB(informacion);

                if (correcto == true)
                {
                    resultado.Add(informacion.id);
                }
            }   
            
            return resultado;
        }

        public int ProcesarArchivoRemoto(InfoArchivo informacion, byte[] contenido)
        {
            int resultado = -1;

            if (EscribirArchivoFS(informacion.archivo, informacion.fechaHoraProceso, contenido))
            {
                if (GuardarArchivoDB(informacion))
                {
                    resultado = informacion.id;
                }
            }

            return resultado;
        }

        private bool GuardarArchivoDB(InfoArchivo informacion)
        {

            DCModelo.Entities contexto;
            DCModelo.Documento documento = new DCModelo.Documento();
            try
            {
                documento.ProcesoID = informacion.procesoID;
                documento.Nombre = informacion.nombre;
                documento.TipoID = informacion.tipoID;
                documento.CuentaID = informacion.cuentaID;
                documento.Carpeta = informacion.carpeta;
                documento.Identificador = informacion.identificador;
                documento.Archivo = informacion.archivo;
                documento.Nota = informacion.nota;
                documento.Ano = informacion.ano;
                documento.NumFile = informacion.numFile;
                documento.NumFileFisico = informacion.numFileFisico;
                documento.Sender = informacion.sender;
                documento.Reciever = informacion.reciever;
                documento.FechaHora = informacion.fechaHora;
                documento.FechaHoraProceso = informacion.fechaHoraProceso;
                using (contexto = new DCModelo.Entities())
                {
                    contexto.Documentoes.Add(documento);
                    contexto.SaveChanges();
                }

                return true;
            }
            catch 
            {
                return false;
            }
            
        }

        private bool GuardarCorreoDB(DataRow filaRecibida, DataRow filaEnviada)
        {
            dynamic procesoID = filaEnviada["ProcesoID"];
            dynamic nombre = filaEnviada["Nombre"];
            dynamic nota = filaEnviada["Nota"];
            dynamic tipoID = filaEnviada["TipoID"];
            dynamic cuentaID = filaEnviada["CuentaID"];
            dynamic carpeta = filaEnviada["Carpeta"];
            dynamic identificador = filaEnviada["Identificador"];
            dynamic ano = filaEnviada["Ano"];
            dynamic numFile = filaEnviada["NumFile"];
            dynamic numFileFisico = filaEnviada["NumFileFisico"];
            dynamic archivo = filaRecibida["Archivo"];
            dynamic sender = filaRecibida["Sender"];
            dynamic reciever = filaRecibida["Reciever"];
            dynamic fechaHora = filaRecibida["FechaHora"];
            dynamic fechaHoraProceso = filaRecibida["FechaHoraProceso"];

            DCModelo.Entities contexto;
            DCModelo.Documento documento = new DCModelo.Documento();

            try
            {
                documento.ProcesoID = procesoID;
                documento.Nombre = nombre;
                documento.TipoID = tipoID;
                documento.CuentaID = cuentaID;
                documento.Carpeta = carpeta;
                documento.Identificador = identificador;
                documento.Archivo = archivo;
                if (!DBNull.Value.Equals(nota))
                {
                    documento.Nota = nota;
                }
                documento.Ano = ano;
                documento.NumFile = numFile;
                documento.NumFileFisico = numFileFisico;
                documento.Sender = sender;
                documento.Reciever = reciever;
                documento.FechaHora = fechaHora;
                documento.FechaHoraProceso = fechaHoraProceso;
                using (contexto = new DCModelo.Entities())
                {
                    contexto.Documentoes.Add(documento);
                    contexto.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
            
        }

        private DataTable DescargarItemByInternetMessageId(List<string> mensajesID, ExchangeService service)
        {
            string rutaBase = "\\\\" + ConfigurationManager.AppSettings["fileServer"].ToString() + "\\" + ConfigurationManager.AppSettings["servidorCarpeta"].ToString();

            DataTable resultados = new DataTable("resultadoDescarga");
            resultados.Columns.Add("Identificador", typeof(String));
            resultados.Columns.Add("Archivo", typeof(String));
            resultados.Columns.Add("Sender", typeof(String));
            resultados.Columns.Add("Reciever", typeof(String));
            resultados.Columns.Add("FechaHora", typeof(DateTime));
            resultados.Columns.Add("FechaHoraProceso", typeof(DateTime));

            List<EmailMessage> correos = new List<EmailMessage>();

            var propertySetBasico = new PropertySet(BasePropertySet.IdOnly, EmailMessageSchema.InternetMessageId);
            var propertySetCompleto = new PropertySet(BasePropertySet.FirstClassProperties, ItemSchema.MimeContent, EmailMessageSchema.IsRead);

            try
            {

                SearchFilter.SearchFilterCollection searchFilterCollection = new SearchFilter.SearchFilterCollection(LogicalOperator.Or);
                foreach (string mensajeID in mensajesID)
                {
                    searchFilterCollection.Add(new SearchFilter.IsEqualTo(EmailMessageSchema.InternetMessageId, mensajeID));
                }

                ItemView vista = new ItemView(100);

                //busca folderes

                ExtendedPropertyDefinition allFoldersType = new ExtendedPropertyDefinition(13825, MapiPropertyType.Integer);

                FolderId rootFolderId = new FolderId(WellKnownFolderName.Root);
                FolderView folderView = new FolderView(1000);
                folderView.Traversal = FolderTraversal.Shallow;

                SearchFilter.SearchFilterCollection folderSearchFilterCollection = new SearchFilter.SearchFilterCollection(LogicalOperator.And, new SearchFilter.IsEqualTo(FolderSchema.DisplayName, "AllItems"));
                FindFoldersResults findFoldersResults = service.FindFolders(rootFolderId, folderSearchFilterCollection, folderView);

                //fin de busqueda de folderes

                if (findFoldersResults.Folders.Count > 0)
                {
                    Folder allItemsFolder = findFoldersResults.Folders[0];
                    vista.PropertySet = propertySetBasico;
                    FindItemsResults<Item> findItemsResult = allItemsFolder.FindItems(searchFilterCollection, vista);

                    foreach (Item item in findItemsResult)
                    {
                        correos.Add((EmailMessage)item); ;
                    }

                    if (correos.Count > 0)
                    {
                        service.LoadPropertiesForItems(correos, propertySetCompleto);

                        foreach (EmailMessage correo in correos)
                        {
                            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                            var random = new Random();
                            string randomString = new string(
                            Enumerable.Repeat(chars, 70)
                            .Select(s => s[random.Next(s.Length)])
                            .ToArray()
                            );

                            string nombre = randomString + ".eml";

                            DateTime fechaHoraProceso = DateTime.Now;

                            bool resultadoEscritura = EscribirArchivoFS(nombre, fechaHoraProceso, correo.MimeContent.Content);

                            if (resultadoEscritura)
                            {
                                string reciever;
                                if (correo.ReceivedBy == null)
                                {
                                    reciever = correo.DisplayTo;
                                }
                                else
                                {
                                    reciever = correo.ReceivedBy.Address;
                                }

                                resultados.Rows.Add(correo.InternetMessageId, nombre, correo.Sender.Address, reciever, correo.DateTimeReceived, fechaHoraProceso);

                            }

                        }

                    }

                }

            }
            catch
            {
                return null;
            }
            return resultados;

        }

        private bool EscribirArchivoFS(string nombre, DateTime fecha, byte[] contenido){

            string rutaBase = "\\\\" + ConfigurationManager.AppSettings["fileServer"].ToString() + "\\" + ConfigurationManager.AppSettings["servidorCarpeta"].ToString();

            string anoPath = fecha.ToString("yyyy");
            string mesPath = fecha.ToString("MM");
            string diaPath = fecha.ToString("dd");

            bool folderAnoExists = Directory.Exists(rutaBase + "\\" + anoPath);

            try
            {
                if (!folderAnoExists)
                    Directory.CreateDirectory(rutaBase + "\\" + anoPath);

                bool folderMesExists = Directory.Exists(rutaBase + "\\" + anoPath + "\\" + mesPath);
                if (!folderMesExists)
                    Directory.CreateDirectory(rutaBase + "\\" + anoPath + "\\" + mesPath);

                bool folderDiaExists = Directory.Exists(rutaBase + "\\" + anoPath + "\\" + mesPath + "\\" + diaPath);
                if (!folderDiaExists)
                    Directory.CreateDirectory(rutaBase + "\\" + anoPath + "\\" + mesPath + "\\" + diaPath);

                System.IO.File.WriteAllBytes(rutaBase + "\\" + anoPath + "\\" + mesPath + "\\" + diaPath + "\\" + nombre, contenido);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public DCArchivo DescargarDCArchivo(int documentoID)
        {

            DCArchivo resultado = new DCArchivo();
            DCModelo.Entities contexto;
            DCModelo.Documento documento = new DCModelo.Documento();
            using (contexto = new DCModelo.Entities())
            {
                documento = contexto.Documentoes.Find(documentoID);

                if (documento != null)
                {
                    resultado.Archivo = documento.Archivo;
                    resultado.FechaHoraProceso = documento.FechaHoraProceso;

                    string ruta = GetPath(documento.Archivo, documento.FechaHoraProceso, ConfigurationManager.AppSettings["fileServer"].ToString()); 

                    try
                    {
                        resultado.Data = File.ReadAllBytes(ruta);
                    }
                    catch
                    {
                        
                    }
                }
            }

            return resultado;
        }

        public bool EsAdministrador(string cuentaID)
        {
            DCModelo.Entities contexto;
            using (contexto = new DCModelo.Entities())
            {
                DCModelo.Cuenta cuenta = contexto.Cuentas.Find(cuentaID);
                if (cuenta != null)
                {

                    if (cuenta.IndAdministrador == 1)
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        public string GetPath(string nombre, DateTime fecha, string fileserver)
        {
            string rutaBase = "\\\\" + fileserver + "\\" + ConfigurationManager.AppSettings["servidorCarpeta"].ToString();
            string anoPath = fecha.ToString("yyyy");
            string mesPath = fecha.ToString("MM");
            string diaPath = fecha.ToString("dd");

            return  rutaBase + "\\" + anoPath + "\\" + mesPath + "\\" + diaPath + "\\" + nombre;
        }

        public bool BorrarDocumento(int documentoID)
        {
            DCModelo.Entities contexto;
            using (contexto = new DCModelo.Entities())
            {
                DCModelo.Documento documento = contexto.Documentoes.Find(documentoID);
                if (documento != null)
                {
                    try
                    {
                        contexto.Documentoes.Remove(documento);
                        string ruta = GetPath(documento.Archivo, documento.FechaHoraProceso, ConfigurationManager.AppSettings["fileServer"].ToString());

                        if (File.Exists(ruta))
                        {
                            File.Delete(ruta);
                            contexto.SaveChanges();
                        }
                        else
                        {
                            List<string> servidores = new List<string>(ConfigurationManager.AppSettings["extraFileServers"].Split(new char[] { ';' }));
                            
                            foreach (string servidor in servidores)
                            {
                                ruta = GetPath(documento.Archivo, documento.FechaHoraProceso, servidor);
                                if (File.Exists(ruta))
                                {
                                    File.Delete(ruta);
                                    contexto.SaveChanges();
                                    break;
                                }
                            }
                        }
                        
                        return true;
                    }
                    catch
                    {
                        return false;
                    }
                }

                return false;
            }
         }

        public bool EditarDocumento(int documentoID, List<object> datos)
        {
            DCModelo.Entities contexto;
            using (contexto = new DCModelo.Entities())
            {
                DCModelo.Documento documento = contexto.Documentoes.Find(documentoID);
                if (documento != null)
                {
                    try
                    {
                        documento.Nombre = datos[0].ToString();
                        if(datos[1] != null)
                            documento.Nota = datos[1].ToString();
                        documento.TipoID = Convert.ToInt16(datos[2]);

                        contexto.Documentoes.Attach(documento);
                        contexto.Entry(documento).State = System.Data.EntityState.Modified;
                        contexto.SaveChanges();

                        return true;
                    }
                    catch
                    {
                        return false;
                    }
                }

                return false;
            }
        }
    }
}
