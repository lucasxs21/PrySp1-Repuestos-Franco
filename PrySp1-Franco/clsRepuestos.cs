using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrySp1_Franco
{
    internal class clsRepuestos
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Marca { get; set; }
        public int Precio { get; set; }
        public bool Origen { get; set; }




        public string ObtenerDatos()
        {
            string AuxOrigen;
            {
                if(Origen == true)
                {
                    AuxOrigen = "Nacional";
                }

                
                {
                    AuxOrigen = "Importado";
                }
            }
            return Codigo + " " + Nombre + " " + Marca + " " + Precio + " " + AuxOrigen + " ";
        }
    }
}
