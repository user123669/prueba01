using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security; // Namesapace para manejar seguridad 

public partial class Login : System.Web.UI.Page
{
    // Llamar al Web Services
    ServiceReferenceUsuario.WSUsuarioSoapClient servicio = new ServiceReferenceUsuario.WSUsuarioSoapClient();

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
    {
        string usuario = Login1.UserName;
        string password = Login1.Password;
        string[] valores = servicio.Login(usuario, password).ToArray();
        if (valores[0] == "0" && valores[1] == "Alumno")
        {
            FormsAuthentication.RedirectFromLoginPage(usuario, false);
        }
        else if (valores[0] == "0" && valores[1] == "Docente")
            Login1.FailureText = "Usted es docente, no tiene acceso al sistema";
        else
            Login1.FailureText = valores[1];
    }
}