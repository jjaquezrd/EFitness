using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{


    public class Afiliado
    {
        public int IdAfiliado { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string FechaNacimiento { get; set; }
        public string Sexo { get; set; }
        public string CorreoElectronico { get; set; }
        public string NoIdentificacion { get; set; }
        public string Clave { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public bool Activo { get; set; }
        public string FechaUltimoPago { get; set; }
        public string FechaProximoPago { get; set; }
        public bool PagoVencido { get; set; }

        


    }
}
