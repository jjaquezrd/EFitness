using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Afiliado
    {
        private CD_Afiliado objCapadato = new CD_Afiliado();

        public List<Afiliado> Listar()
        {
            return objCapadato.listar();

        }

        public int Registrar(Afiliado obj, out string Mensaje)
        {

            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.PrimerNombre) || string.IsNullOrWhiteSpace(obj.PrimerNombre))
            {
                Mensaje = "El nombre del afiliado no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.PrimerApellido) || string.IsNullOrWhiteSpace(obj.PrimerApellido))
            {
                Mensaje = "El apellido del usuario no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.CorreoElectronico) || string.IsNullOrWhiteSpace(obj.CorreoElectronico))
            {

                Mensaje = "El correo del usuario no puede ser vacio";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {

                string clave = "test123";
                obj.Clave = CN_Recursos.ConvertirSha256(clave);
            }


            return objCapadato.Registrar(obj, out Mensaje);

        }

        public bool Editar(Afiliado obj, out string Mensaje)
        {

            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.PrimerNombre) || string.IsNullOrWhiteSpace(obj.PrimerNombre))
            {
                Mensaje = "El nombre del afiliado no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.PrimerApellido) || string.IsNullOrWhiteSpace(obj.PrimerApellido))
            {
                Mensaje = "El apellido del usuario no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.CorreoElectronico) || string.IsNullOrWhiteSpace(obj.CorreoElectronico))
            {

                Mensaje = "El correo del afiliado no puede ser vacio";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {

                return objCapadato.Editar(obj, out Mensaje);
            }
            else
            {

                return false;
            }


        }

        public bool Eliminar(int id, out string Mensaje)
        {

            return objCapadato.Eliminar(id, out Mensaje);
        }

        public bool EditarPago(Afiliado obj, out string Mensaje)
        {

            Mensaje = string.Empty;

            
                return objCapadato.EditarPago(obj, out Mensaje);
        }
            

        
    }
}
