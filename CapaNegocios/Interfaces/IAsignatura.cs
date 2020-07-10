using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaEntidades;
using System.Data;

namespace CapaNegocios.Interfaces
    
{
    interface IAsignatura
    {
        DataSet Listar();
        bool Agregar(Asignatura asignatura);
        bool Eliminar(string codAsignatura);
        bool Actualizar(Asignatura asignatura);
        DataSet Buscar(string texto, string criterio);

    }
}
