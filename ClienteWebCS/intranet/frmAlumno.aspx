<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmAlumno.aspx.cs" Inherits="Intranet_frmAlumno" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
		<meta name="viewport" content="width=device-width, initial-scale=1, user-scalable=no" />
		<link rel="stylesheet" href="/assets/css/main2.css" /
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <!-- Header -->
			<section id="header">
				<header>
					
					<h1 id="logo"><a href="#">UNIVERSIDAD ANDINA DEL CUSCO</a></h1>
					<p>#QUEDATEENCASA<br />
				</header>
				<nav id="nav">
					<ul>
						<li><a href="#one" class="active">INFORMACION</a></li>
						<li><a href="#two">QUE PUEDES SABER</a></li>
						<li><a href="#four">CONTACTO</a></li>
					</ul>
				</nav>
				<footer>
					<ul class="icons">
						<li><a href="#" class="icon brands fa-twitter"><span class="label">Twitter</span></a></li>
						<li><a href="#" class="icon brands fa-facebook-f"><span class="label">Facebook</span></a></li>
						<li><a href="#" class="icon brands fa-instagram"><span class="label">Instagram</span></a></li>
						<li><a href="#" class="icon brands fa-github"><span class="label">Github</span></a></li>
						<li><a href="#" class="icon solid fa-envelope"><span class="label">Email</span></a></li>
					</ul>
				</footer>
			</section>
    <form id="form1" runat="server">
    <div>
    
        Bienvenido:
        <asp:LoginName ID="LoginName1" runat="server" />
        <br />
        <br />
        <asp:LoginStatus ID="LoginStatus1" runat="server" />
        <br />
        <br />
        <br />
        <asp:Button ID="btnReporte1" runat="server" Text="Notas Semestre" OnClick="btnReporte1_Click" />
        <asp:Button ID="btnReporte2" runat="server" Text="Notas Generales" OnClick="btnReporte2_Click" />
        <asp:Button ID="btnCambiarUsuario" runat="server" Text="Cambias Contraseña" OnClick="btnCambiarUsuario_Click" />
        <br />
        <asp:MultiView ActiveViewIndex="0" runat="server" ID="mvAlumno">
            <asp:View runat="server" ID="vReporte1">
                Reporte1<asp:DropDownList ID="ddlSemestre" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSemestre_SelectedIndexChanged">
                </asp:DropDownList>
                <br />
                <asp:GridView ID="gvSemestre" runat="server" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2">
                    <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                    <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                    <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                    <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#FFF1D4" />
                    <SortedAscendingHeaderStyle BackColor="#B95C30" />
                    <SortedDescendingCellStyle BackColor="#F1E5CE" />
                    <SortedDescendingHeaderStyle BackColor="#93451F" />
                </asp:GridView>
                <asp:Button ID="btnExel2" runat="server" OnClick="btnExel2_Click" Text="Exportar a Exel" />
                <asp:Button ID="btnPdf2" runat="server" OnClick="btnPdf2_Click" Text="Exportar a PDF" />
                <br />
            </asp:View>
            <asp:View runat="server" ID="vReporte2">
            <asp:GridView ID="gvSeguimiento" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>
                <br />
                <br />
                <asp:Button Text="Exportar a Exel" runat="server" ID="btnExcel" OnClick="btnExcel_Click" style="height: 26px"/>
                <asp:Button Text="Exportar a PDF" runat="server" ID="btnPDF" OnClick="btnPDF_Click"/>
            </asp:View>
            <asp:View runat="server" ID="vCambiarContraseña">
                Cambiar Contraseña <br />
                Contraseña Actual : <asp:TextBox runat="server" Id="txtContrasena"/> 
                <asp:RequiredFieldValidator ID="Contra" runat="server" ControlToValidate="txtContrasena" ErrorMessage="*requerido contraseña actual" ForeColor="Red" >Falta</asp:RequiredFieldValidator>
                <br />

                De una nueva Contraseña : <asp:TextBox runat="server" Id="txtContrasenaNueva"/> 
                <asp:RequiredFieldValidator runat="server" ID="ContraNueva" ControlToValidate="txtContrasenaNueva"
                ErrorMessage="*requerido contraseña nueva" ForeColor="Red" >Falta</asp:RequiredFieldValidator>

                <br />

                Repita Contraseña : <asp:TextBox runat="server" Id="txtRepitaContrasena"/> 
                <asp:RequiredFieldValidator runat="server" ID="Contra2" ControlToValidate="txtRepitaContrasena"
                ErrorMessage="*requerido contraseña nueva" ForeColor="Red">Falta</asp:RequiredFieldValidator>
                <br />
                <asp:CompareValidator ID="Compare" runat="server" ControlToCompare="txtContrasenaNueva" ControlToValidate="txtRepitaContrasena" ErrorMessage="No son Iguales las Contraseñas"></asp:CompareValidator>
                <br />
                <asp:Button ID="btnCambiarContrasena" runat="server" OnClick="btnCambiarContrasena_Click" Text="Cambiar contraseña" />
                <br />
                <asp:Label ID="Label1" runat="server" ForeColor="#120502"></asp:Label>
            </asp:View>
        </asp:MultiView>
    
    </div>
    </form>
    	<!-- Footer -->
					<section id="footer">
						<div class="container">
							<ul class="copyright">
								<li>&copy; DERECHOS RESERVADOS</li><li>Design:CHAUCA & CASTELO</li>
							</ul>
						</div>
					</section>

			</div>

		<!-- Scripts -->
			<script src="/assets/js/jquery.min.js"></script>
			<script src="/assets/js/jquery.scrollex.min.js"></script>
			<script src="/assets/js/jquery.scrolly.min.js"></script>
			<script src="/assets/js/browser.min.js"></script>
			<script src="/assets/js/breakpoints.min.js"></script>
			<script src="/assets/js/util.js"></script>
			<script src="/assets/js/main.js"></script>
</body>
</html>
