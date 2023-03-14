using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{

    
    public class TipoPlan
    {
        public int IdPlan { get; set; }
        public string Descripcion { get; set; }
        public decimal Costo { get; set; }
        public string DetallePresentacionPlan { get; set; }
        public string RutaImagen { get; set; }
        public string NombreImagen { get; set; }
        public bool Activo { get; set; }



    }
}
