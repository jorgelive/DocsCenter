using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;


namespace DCServicio
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IDCServicio
    {

        [OperationContract]
        FilePrincipal GetFilePrincipalByAnoFile(string anoFile);

        [OperationContract]
        List<Tipo> GetTipos();

        [OperationContract]
        List<Proceso> GetProcesos();

        [OperationContract]
        List<int> ProcesarCorreos(List<DataTable> tablas);

        [OperationContract]
        List<int> ProcesarArchivos(List<InfoArchivo> listaInformacion);

        [OperationContract]
        bool BorrarDocumento(int documentoID);

        [OperationContract]
        bool EditarDocumento(int documentoID, List<Object> datos);

        [OperationContract]
        DCArchivo DescargarDCArchivo(int documentoID);

        [OperationContract]
        int ProcesarArchivoRemoto(InfoArchivo informacion, byte[] contenido);

        [OperationContract]
        bool EsAdministrador(string cuentaID);

        // TODO: agregue aquí sus operaciones de servicio
    }


    // Utilice un contrato de datos, como se ilustra en el ejemplo siguiente, para agregar tipos compuestos a las operaciones de servicio.
    [DataContract]
    public class FilePrincipal
    {

        [DataMember]
        public string Ano;

        [DataMember]
        public string NumFile;

        [DataMember]
        public string NumFileFisico;

        [DataMember]
        public string Nombre;

        [DataMember]
        public string AnoFile;

        [DataMember]
        public string Mercado;
    }
    [DataContract]
    public class Tipo
    {

        [DataMember]
        public int TipoID;

        [DataMember]
        public string Nombre;
    }

    [DataContract]
    public class Proceso
    {

        [DataMember]
        public int ProcesoID;

        [DataMember]
        public string Nombre;
    }

    [DataContract]
    public class DCArchivo
    {
        [DataMember]
        public string Archivo { get; set; }

        [DataMember]
        public DateTime FechaHoraProceso { get; set; }

        [DataMember]
        public byte[] Data { get; set; }
    }

    [DataContract]
    public class InfoArchivo
    {
        [DataMember]
        public int id { get; set; }
        
        [DataMember]
        public short procesoID { get; set; }

        [DataMember]
        public string nombre { get; set; }

        [DataMember]
        public string nota { get; set; }

        [DataMember]
        public short tipoID { get; set; }

        [DataMember]
        public string cuentaID { get; set; }

        [DataMember]
        public string carpeta { get; set; }

        [DataMember]
        public string identificador { get; set; }

        [DataMember]
        public string ano { get; set; }

        [DataMember]
        public string numFile { get; set; }

        [DataMember]
        public string numFileFisico { get; set; }

        [DataMember]
        public string archivo { get; set; }

        [DataMember]
        public string sender { get; set; }

        [DataMember]
        public string reciever { get; set; }

        [DataMember]
        public DateTime fechaHora { get; set; }

        [DataMember]
        public DateTime fechaHoraProceso { get; set; }

    }


}
