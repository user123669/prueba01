using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;

namespace CapaEntidades
{
     [DataContract]
    public class Asignatura
    {
        [DataMember]
        public string _CodAsignatura
        { get; set; }

        [DataMember]
        public string _Asignatura
        { get; set; }

        [DataMember]
        public string _CodRequisito
        { get; set; }
    }
}
