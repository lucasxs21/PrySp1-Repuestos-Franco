using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrySp1_Franco
{
    internal class ClsArchivo
    {
        public string NombreArchivo { get; set; }

        public bool GrabarRepuesto(ClsRepuesto repuesto)
        {
            bool resultado = false;
            if (NombreArchivo != "")
            {
                StreamWriter sw = new StreamWriter(NombreArchivo, true);
                sw.WriteLine(repuesto.codigo + "," + repuesto.nombre + "," + repuesto.marca + "," + repuesto.precio.ToString("#.00", CultureInfo.InvariantCulture) + "," + repuesto.origen);
                sw.Close();
                sw.Dispose();
                resultado = true;
            }
            return resultado;
        }

        public bool BuscarCodigoRepuesto(string codigo)
        {
            bool resultado = false;
            string Linea;
            string CodigoRepuesto;
            if (NombreArchivo != "" && File.Exists(NombreArchivo))
            {
                StreamReader sr = new StreamReader(NombreArchivo);
                while (sr.EndOfStream == false)
                {
                    Linea = sr.ReadLine();
                    CodigoRepuesto = Linea.Split(',')[0];
                    if (codigo == CodigoRepuesto)
                    {
                        resultado = true;
                        break;
                    }
                }
                sr.Close();
                sr.Dispose();
            }
            return resultado;
        }

        public List<ClsRepuesto> ObtenerRepuestos()
        {
            List<ClsRepuesto> Lista = new List<ClsRepuesto>();
            string Linea;
            if (NombreArchivo != "" && File.Exists(NombreArchivo))
            {
                StreamReader sr = new StreamReader(NombreArchivo);
                while (sr.EndOfStream == false)
                {
                    Linea = sr.ReadLine();
                    ClsRepuesto repuesto = new ClsRepuesto();
                    repuesto.codigo = Linea.Split(',')[0];
                    repuesto.nombre = Linea.Split(',')[1];
                    repuesto.marca = Linea.Split(',')[2];
                    repuesto.precio = decimal.Parse(Linea.Split(',')[3], CultureInfo.InvariantCulture);
                    repuesto.origen = Linea.Split(',')[4];
                    Lista.Add(repuesto);
                }
                sr.Close();
                sr.Dispose();
            }
            return Lista;
        }

        public List<ClsRepuesto> ObtenerRepuestosOrdenados()
        {
            List<ClsRepuesto> Lista = ObtenerRepuestos();
            ClsRepuesto[] repuestosArray = Lista.ToArray();

            for (int i = 0; i < repuestosArray.Length - 1; i++)
            {
                for (int j = 0; j < repuestosArray.Length - 1; j++)
                {
                    if (string.Compare(repuestosArray[j].nombre, repuestosArray[j + 1].nombre) > 0)
                    {
                        ClsRepuesto aux = repuestosArray[j];
                        repuestosArray[j] = repuestosArray[j + 1];
                        repuestosArray[j + 1] = aux;
                    }
                }
            }
            List<ClsRepuesto> Ordenados = repuestosArray.ToList<ClsRepuesto>();
            return Ordenados;
        }
    }
}
