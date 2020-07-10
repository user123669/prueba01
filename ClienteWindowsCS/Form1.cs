using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClienteWindowsCS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ServiceReference1.WSAsignaturaSoapClient servicio;

        private void Listar()
        {
            servicio = new ServiceReference1.WSAsignaturaSoapClient();
            dgbAsignatura.DataSource = servicio.Listar().Tables[0];
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            Listar();
            cboCriterio.Items.Add("CodAsignatura");
            cboCriterio.Items.Add("Asignatura");
            cboCriterio.Items.Add("Codrequisito");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string CodAsignatura = txtCodAsignatura.Text.Trim();
            string Asignatura = txtAsignatura.Text.Trim();
            string CodRequisito = txtCodRequisito.Text.Trim();
            string[] resp = new string[2];
            resp = servicio.Agregar(CodAsignatura, Asignatura, CodRequisito);
                if(resp[0].ToString()=="0")
                    Listar();
            MessageBox.Show(resp[1].ToString());
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string CodAsignatura = txtCodAsignatura.Text.Trim();
            string[] resp = new string[2];
            resp = servicio.Eliminar(CodAsignatura);
            if (resp[0].ToString() == "0")
                Listar();
            MessageBox.Show(resp[1].ToString());
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            string CodAsignatura = txtCodAsignatura.Text.Trim();
            string Asignatura = txtAsignatura.Text.Trim();
            string CodRequisito = txtCodRequisito.Text.Trim();
            string[] resp = new string[2];
            resp = servicio.Actualizar(CodAsignatura, Asignatura, CodRequisito);
            if (resp[0].ToString() == "0")
                Listar();
            MessageBox.Show(resp[1].ToString());
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string Texto = txtBuscar.Text.Trim();
            string Criterio = cboCriterio.Text.Trim();
            dgbAsignatura.DataSource = servicio.Buscar(Texto,Criterio).Tables[0];
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            servicio = new ServiceReference1.WSAsignaturaSoapClient();
            dgbAsignatura.DataSource = servicio.Listar().Tables[0];
        }




        


    }
}
