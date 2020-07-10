using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaEntidades;
using System.Data;

namespace CapaNegocios.Interfaces
{
    interface ICarrera
    {
        DataTable Listar();
        bool Agregar(Carrera carrera);
        bool Eliminar(string CodCarrera);
        bool Actualizar(Carrera carrera);
        DataTable Buscar(string texto, string criterio);
    }
}
