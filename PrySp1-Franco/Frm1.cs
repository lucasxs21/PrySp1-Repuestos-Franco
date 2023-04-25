using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PrySp1_Franco
{
    public partial class Frm1 : Form
    {
        private string PATH_ARCHIVO;
        public Frm1(string Path)
        {
            InitializeComponent();
            PATH_ARCHIVO = Path;
        }
        private void Inicializar()
        {
            cmbMarca.Items.Clear();
            cmbMarca.Items.Add("Marca A");
            cmbMarca.Items.Add("Marca B");
            cmbMarca.Items.Add("Marca C");
            cmbMarca.SelectedIndex = 0;
            optNacional.Checked = true;
        }
        private void Frm1_Load(object sender, EventArgs e)
        {
            Inicializar();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (!File.Exists(Application.StartupPath + "\\" + PATH_ARCHIVO))
            {
                MessageBox.Show("No hay datos para mostrar", "Consulta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            ClsArchivo Repuestos = new ClsArchivo();
            Repuestos.NombreArchivo = PATH_ARCHIVO;
            List<ClsRepuesto> repuestos = Repuestos.ObtenerRepuestosOrdenados();

            dgvInfo.Rows.Clear();

            foreach (ClsRepuesto repuesto in repuestos)
            {
                if (repuesto.marca == cmbMarca.SelectedItem.ToString())
                {
                    if (optImportado.Checked && repuesto.origen == "Importado")
                    {
                        dgvInfo.Rows.Add(repuesto.codigo, repuesto.nombre, repuesto.marca, repuesto.origen, repuesto.precio.ToString());
                    }
                    else
                    {
                        if (optNacional.Checked && repuesto.origen == "Nacional")
                        {
                            dgvInfo.Rows.Add(repuesto.codigo, repuesto.nombre, repuesto.marca, repuesto.origen, repuesto.precio.ToString());
                        }
                        else
                        {
                            if (optAmbos.Checked)
                            {
                                dgvInfo.Rows.Add(repuesto.codigo, repuesto.nombre, repuesto.marca, repuesto.origen, repuesto.precio.ToString());
                            }
                        }
                    }
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
    
}
