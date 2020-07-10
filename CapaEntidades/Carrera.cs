using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;

namespace CapaEntidades
{
   [DataContract]

    public class Carrera
    {
        [DataMember]
        public String _CodCarrera
       { get; set; }
        [DataMember]

        public String _Carrera
         {get;set;}

    }
}
