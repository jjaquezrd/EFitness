using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidad;
using CapaNegocio;
namespace CapaPresentacionAdmin.Controllers
{
    public class MantenedorController : Controller
    {
        // GET: Mantenedor
        public ActionResult Afiliados()
        {
            return View();
        }

        [HttpGet]
        public JsonResult ListarAfiliados()
        {
            List<Afiliado> oLista = new List<Afiliado>();

            oLista = new CN_Afiliado().Listar();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult GuardarAfiliado(Afiliado objeto)
        {

            object resultado;
            string mensaje = string.Empty;

            if (objeto.IdAfiliado == 0)
            {
                resultado = new CN_Afiliado().Registrar(objeto, out mensaje);
            }
            else
            {

                resultado = new CN_Afiliado().Editar(objeto, out mensaje);
            }

            return Json(new { resutlado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public JsonResult GuardarPago(Afiliado objeto)
        {

            object resultado;
            string mensaje = string.Empty;

            if (objeto.IdAfiliado == 0)
            {
               resultado = new CN_Afiliado().Registrar(objeto, out mensaje);
            }
            else
            {

                resultado = new CN_Afiliado().EditarPago(objeto, out mensaje);
            }

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult Planes()
        {
            return View();
        }

        public ActionResult Membresias()
        {
            return View();
        }
    }
}