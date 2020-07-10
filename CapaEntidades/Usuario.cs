using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;

namespace CapaEntidades
{
    [DataContract]
    public class Usuario
    {
        [DataMember]
        public string _Usuario
        { get; set; }
        [DataMember]
        public string _Contrasena
        { get; set; }
        [DataMember]
        public string _Contrasena2
        { get; set; }
        [DataMember]
        public string _Semestre
        { get; set; }
    }
}
