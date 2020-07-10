using CapaDatos;
using CapaEntidades;
using System;
using System.Data;

namespace CapaNegocios
{
    public class UsuarioBL : Interfaces.IUsuario
    {
        private Datos datos = new DatosSQL();

        private string mensaje;

        public string Mensaje
        { get { return mensaje; } }

        public bool Login(Usuario usuario)
        {
            DataRow fila = datos.TraerDataRow("spLoginUsuario", usuario._Usuario, usuario._Contrasena);
            byte codError = Convert.ToByte(fila["CodError"]);
            mensaje = fila["Mensaje"].ToString();
            if (codError == 0) return true;
            else return false;
        }
        public bool Cambio(Usuario usuario)
        {
            DataRow fila = datos.TraerDataRow("spActualizarContrasenaNueva", usuario._Usuario, usuario._Contrasena, usuario._Contrasena2);
            byte codError = Convert.ToByte(fila["CodError"]);
            mensaje = fila["Mensaje"].ToString();
            if (codError == 0) return true;
            else return false;
        }

        public DataSet SeguimientoAcademico(Usuario usuario)
        {
            return datos.TraerDataSet("spSeguimientoAcademico", usuario._Usuario);
        }
        public DataSet SeguimientoSemestre(Usuario usuario)
        {
            return datos.TraerDataSet("spListarSemestre", usuario._Usuario, usuario._Semestre);
        }
        public DataSet ListarSemestre()
        {
            return datos.TraerDataSet("spListarSolosemestre");
        }
    }
}
