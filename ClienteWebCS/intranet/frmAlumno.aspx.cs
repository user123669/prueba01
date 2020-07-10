using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using CapaEntidades;
using CapaNegocios;
public partial class Intranet_frmAlumno : System.Web.UI.Page
{
    ServiceReferenceUsuario.WSUsuarioSoapClient servicio = new ServiceReferenceUsuario.WSUsuarioSoapClient();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ddlSemestre.DataSource = servicio.ListarSemestre();
            ddlSemestre.DataTextField = "Semestre";
            ddlSemestre.DataBind();

        }
    }
    protected void btnReporte1_Click(object sender, EventArgs e)
    {
        mvAlumno.ActiveViewIndex = 0;
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
           server control at run time. */
    }
    private void ExportGridToPDF()
    {
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=Vithal_Wadje.pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        gvSeguimiento.RenderControl(hw);
        StringReader sr = new StringReader(sw.ToString());
        Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        pdfDoc.Open();
        htmlparser.Parse(sr);
        pdfDoc.Close();
        gvSeguimiento.AllowPaging = true;
        gvSeguimiento.DataBind();
        Response.Write(pdfDoc);
        Response.End();
   
    }
    private void ExportGridToPDF2()
    {
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=Vithal_Wadje.pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        gvSemestre.RenderControl(hw);
        StringReader sr = new StringReader(sw.ToString());
        Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        pdfDoc.Open();
        htmlparser.Parse(sr);
        pdfDoc.Close();
        gvSemestre.AllowPaging = true;
        gvSemestre.DataBind();
        Response.Write(pdfDoc);
        Response.End();

    }
    private void ExportToExcel(string nameReport, GridView wControl)
    {
        HttpResponse response = Response;
        StringWriter sw = new StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        Page pageToRender = new Page();
        HtmlForm form = new HtmlForm();
        form.Controls.Add(wControl);
        pageToRender.Controls.Add(form);
        response.Clear();
        response.Buffer = true;
        response.ContentType = "application/vnd.ms-excel";
        response.AddHeader("Content-Disposition", "attachment;filename=" + nameReport);
        response.Charset = "UTF-8";
        response.ContentEncoding = Encoding.Default;
        pageToRender.RenderControl(htw);
        response.Write(sw.ToString());
        response.End();
    }
    protected void btnReporte2_Click(object sender, EventArgs e)
    {
        mvAlumno.ActiveViewIndex = 1;
        //llamar los datos del seguimiento academico
        gvSeguimiento.DataSource = servicio.SeguimientoAcademico(User.Identity.Name);
        gvSeguimiento.DataBind();

    }
    protected void btnCambiarUsuario_Click(object sender, EventArgs e)
    {
        mvAlumno.ActiveViewIndex = 2;
    }

    protected void btnExcel_Click(object sender, EventArgs e)
    {
        ExportToExcel("Informe.xls", gvSeguimiento);
    }

    protected void btnPDF_Click(object sender, EventArgs e)
    {
        ExportGridToPDF();
    }

    protected void gvSemestre_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void ddlSemestre_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSemestre.SelectedIndex == 0)
        {
            gvSemestre.DataSource = servicio.SeguimientoSemestre(User.Identity.Name, "2010-I");
            gvSemestre.DataBind();
        }
        else if (ddlSemestre.SelectedIndex == 1)
            gvSemestre.DataSource = servicio.SeguimientoSemestre(User.Identity.Name, "2010-II");
        gvSemestre.DataBind();
    }

    protected void btnCambiarContrasena_Click(object sender, EventArgs e)
    {
        string usuario = User.Identity.Name;
        string contranterior = txtContrasena.Text.Trim();
        string contranueva = txtContrasenaNueva.Text.Trim();
        string repita = txtRepitaContrasena.Text.Trim();


        if (contranueva == repita)
        {
            string[] valores = servicio.Cambio(usuario, contranterior, contranueva).ToArray();

            Label1.Text = valores[1];


        }
    }

    protected void btnExel2_Click(object sender, EventArgs e)
    {
        ExportToExcel("Informe.xls", gvSemestre);
    }

    protected void btnPdf2_Click(object sender, EventArgs e)
    {
        ExportGridToPDF2();
    }
}