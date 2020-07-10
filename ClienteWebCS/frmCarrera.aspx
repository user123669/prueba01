<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmCarrera.aspx.cs" Inherits="frmCarrera" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>formulario Carrera</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <p> Cod Carrera: <asp:TextBox runat="server" ID="txtCodCarrera" /> </p>
        <p> Carrera:<asp:TextBox runat="server" Id="txtCarrera" /></p>
        <p> 
            <asp:Button Text="Agregar" runat="server" Id="btnAgregar" OnClick="btnAgregar_Click" />
            <asp:Button Text="Eliminar" runat="server" Id="btnEliminar" OnClick="btnEliminar_Click" />
            <asp:Button Text="Actualizar" runat="server" Id="btnActualizar" OnClick="btnActualizar_Click" />
        </p>
        <p> 
            Buscar
            <asp:TextBox runat="server" Id="txtTexto" />
            <asp:DropDownList runat="server" ID="ddlCarrera">
                <asp:ListItem Text="CodCarrera" />
                <asp:ListItem Text="Carrera" />
            </asp:DropDownList>  
            <asp:Button Text="Buscar" runat="server" id="btnBuscar" OnClick="btnBuscar_Click"/>
        </p>
        <p> 
            <asp:GridView runat="server" ID="gvCarrera" OnSelectedIndexChanged="gvCarrera_SelectedIndexChanged"></asp:GridView>
        </p>
    </div>
    </form>
</body>
</html>
