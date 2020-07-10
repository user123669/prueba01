using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

using CapaEntidades;
using CapaNegocios;
using System.Data;

/// <summary>
/// Descripción breve de WSAsignatura
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
// [System.Web.Script.Services.ScriptService]
public class WSAsignatura : System.Web.Services.WebService {

    public WSAsignatura () {

        //Elimine la marca de comentario de la línea siguiente si utiliza los componentes diseñados 
        //InitializeComponent(); 
    }

    [WebMethod(Description="Listar Asignatura")]
    public DataSet Listar()
    {
        AsignaturaBL asignaturaBL= new AsignaturaBL();
        return asignaturaBL.Listar();
    }

    [WebMethod(Description="Agregar Asignatura")]
    public String[] Agregar(String _CodAsignatura, String _Asignatura, String _CodRequisito)
    {
        AsignaturaBL asignaturaBL = new AsignaturaBL();
        Asignatura asignatura = new Asignatura();
        asignatura._CodAsignatura = _CodAsignatura;
        asignatura._Asignatura = _Asignatura;
        asignatura._CodRequisito = _CodRequisito;
        bool CodError = asignaturaBL.Agregar(asignatura);
        string[] valores = new String[2];
        if (CodError == true) valores[0] = "0";
        else valores[0] = "1";
        valores[1] = asignaturaBL.Mensaje;
        return valores;
    }

    [WebMethod(Description = "Eliminar Asignatura")]
    public String[] Eliminar(String _CodAsignatura)
    {
        AsignaturaBL asignaturaBL = new AsignaturaBL();
        Asignatura asignatura = new Asignatura();
        asignatura._CodAsignatura = _CodAsignatura;
        bool CodError = asignaturaBL.Eliminar(_CodAsignatura);
        string[] valores = new String[2];
        if (CodError == true) valores[0] = "0";
        else valores[0] = "1";
        valores[1] = asignaturaBL.Mensaje;
        return valores;
    }

    [WebMethod(Description = "Actualizar Asignatura")]
    public String[] Actualizar(String _CodAsignatura, String _Asignatura, String _CodRequisito)
    {
        AsignaturaBL asignaturaBL = new AsignaturaBL();
        Asignatura asignatura = new Asignatura();
        asignatura._CodAsignatura = _CodAsignatura;
        asignatura._Asignatura = _Asignatura;
        asignatura._CodRequisito = _CodRequisito;
        bool CodError = asignaturaBL.Actualizar(asignatura);
        string[] valores = new String[2];
        if (CodError == true) valores[0] = "0";
        else valores[0] = "1";
        valores[1] = asignaturaBL.Mensaje;
        return valores;
    }

    [WebMethod(Description = "Buscar Asignatura")]
    public DataSet Buscar( string Texto, String Criterio)
    {
        AsignaturaBL asignaturaBL = new AsignaturaBL();
        return asignaturaBL.Buscar(Texto, Criterio);

    }

}
