using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{


    public class Membresia
    {

        public int IdMembresia { get; set; }
        public string NoNombresia { get; set; }
        public Afiliado oAfiliado { get; set; }
        public TipoPlan oTipoPlan { get; set; }
        public EstatusMembresia oEstatusMembresia { get; set; }
        public decimal TotalInscripcion { get; set; }
        public decimal Total_Paquetes_Adicionales { get; set; }
        public decimal MontoTotalFactura { get; set; }
        public string IdTransaccion { get; set; }
        public bool Activo { get; set; }

    }
}
