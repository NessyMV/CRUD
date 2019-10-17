using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace crud
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "Ifuunciones" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface Ifuunciones
    {
        [OperationContract]
        void Create(string id, string nombre, string apellidos, string direccion, string numero);
        [OperationContract]
        string [] Read( string id);
        [OperationContract]
        bool delete(string id);
        [OperationContract]
        bool update(string id, string nombre, string apellidos, string direccion, string numero);
    }
}
