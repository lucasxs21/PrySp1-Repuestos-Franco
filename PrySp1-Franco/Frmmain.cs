using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrySp1_Franco
{
    public partial class Frmmain : Form
    {
        List<clsRepuestos> ListarRepuestos = new List<clsRepuestos>();

        public Frmmain()
        {
            InitializeComponent();
        }

        private void bynpersona_Click(object sender, EventArgs e)
        {
            clsRepuestos objRepuestos = new clsRepuestos();

            objRepuestos.Nombre = txtNombre.Text;
            objRepuestos.Codigo = int.Parse(txtCodigo.Text);
            objRepuestos.Precio = int.Parse(txtPrecio.Text);
            objRepuestos.Marca = cmbMarca.Text;
            if(optImportado.Checked == true)
            {
                objRepuestos.Origen = false;
            }
            if(optNacional.Checked)
            {
                objRepuestos.Origen = true;
            }

            MessageBox.Show("Grabacion Exitosa");

            ListarRepuestos.Add(objRepuestos);
            

            foreach (clsRepuestos leer in ListarRepuestos)
            {
                //lstRepuestos.Items.Add(leer.Nombre + leer.Origen);
            }
        }

        private void Frmmain_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            Frm1 abrir = new Frm1();
            abrir.ShowDialog();

           
        }
    }
}
