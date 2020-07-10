using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidades;
using System.Data;


namespace CapaNegocios
{
    public class AsignaturaBL: Interfaces.IAsignatura
    {
        Datos datos = new DatosSQL();

        private string mensaje;
        public string Mensaje
        {
            get { return mensaje; }

        }
        public System.Data.DataSet Listar()
        {
            return datos.TraerDataSet("spListarAsignatura");
        }

        public bool Agregar(Asignatura asignatura)
        {
            DataRow fila = datos.TraerDataRow("spAgregarAsignatura", asignatura._CodAsignatura, asignatura._Asignatura, asignatura._CodRequisito);
            byte codError = Convert.ToByte(fila["CodError"]);
            mensaje = fila["Mensaje"].ToString();
            if (codError == 0) return true;
            else return false;
        }

        public bool Eliminar(string CodAsignatura)
        {
            DataRow fila = datos.TraerDataRow("spEliminarAsignatura", CodAsignatura);
            byte codError = Convert.ToByte(fila["CodError"]);
            mensaje = fila["Mensaje"].ToString();
            if (codError == 0) return true;
            else return false;
        }

        public bool Actualizar(Asignatura asignatura)
        {
            DataRow fila = datos.TraerDataRow("spActualizarAsignatura", asignatura._CodAsignatura, asignatura._Asignatura, asignatura._CodRequisito);
            byte codError = Convert.ToByte(fila["CodError"]);
            mensaje = fila["Mensaje"].ToString();
            if (codError == 0) return true;
            else return false;
        }

        public System.Data.DataSet Buscar(string texto, string criterio)
        {
            return datos.TraerDataSet("spBuscarAsignatura", texto, criterio);
        }


    }
}
