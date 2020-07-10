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
    public class CarreraBL : Interfaces.ICarrera
    {

        Datos datos = new DatosSQL();

        //Propiedad de lectura para mostrar el mensaje 
        private string mensaje;
        public string Mensaje
        {
            get { return mensaje; }

        }

        public System.Data.DataTable Listar()
        {
            return datos.TraerDataTable("spListarCarrera");
        }

        public bool Agregar(Carrera carrera)
        {
            DataRow fila = datos.TraerDataRow("spAgregarCarrera", carrera._CodCarrera, carrera._Carrera);
            byte codError = Convert.ToByte(fila["CodError"]);
            mensaje = fila["Mensaje"].ToString();
            if (codError == 0) return true;
            else return false;
        }

        public bool Eliminar(string CodCarrera)
        {
            DataRow fila = datos.TraerDataRow("spEliminarCarrera", CodCarrera);
            byte codError = Convert.ToByte(fila["CodError"]);
            mensaje = fila["Mensaje"].ToString();
            if (codError == 0) return true;
            else return false;
        }

        public bool Actualizar(Carrera carrera)
        {
            DataRow fila = datos.TraerDataRow("spActualizarCarrera", carrera._CodCarrera,carrera._Carrera);
            byte codError = Convert.ToByte(fila["CodError"]);
            mensaje = fila["Mensaje"].ToString();
            if (codError == 0) return true;
            else return false;
        }

        public System.Data.DataTable Buscar(string texto, string criterio)
        {
           return datos.TraerDataTable("spBuscarCarrera", texto, criterio);
        }

    }
}
