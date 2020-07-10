using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaEntidades;
using System.Data;

namespace CapaNegocios.Interfaces
{
    interface IUsuario
    {
        bool Login(Usuario usuario);
        bool Cambio(Usuario usuario);
        DataSet SeguimientoAcademico(Usuario usuario);
        DataSet SeguimientoSemestre(Usuario usuario);
        DataSet ListarSemestre();

    }
}
