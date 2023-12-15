using Microsoft.AspNetCore.Mvc;
using CRUDFuncional.Data;
using CRUDFuncional.Models;
namespace CRUDFuncional.Controllers
{
    public class EmpleadoController : Controller
    {
        EmpleadoData _EmpleadoData = new EmpleadoData();
        public IActionResult Listar()
        {
            var oLista = _EmpleadoData.Listar();
            //muestra una lista de contactos
            return View(oLista);
        }

        public IActionResult Guardar()
        {
            //devuelve solo la vista
            return View();
        }


        [HttpPost]
        public IActionResult Guardar(EmpleadosModel oEmpleado)
        {
            
            //en caso de que todos los campos sean validos
            //if (ModelState.IsValid) 
              //  return View();
             //recibe el objeto y lo guarda en la BD
             var respuesta = _EmpleadoData.Guardar(oEmpleado);

            if(respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }



        public IActionResult Editar(int IdEmpleado)
        {
            var oEmpleado = _EmpleadoData.Obtener(IdEmpleado);
            //devuelve solo la vista
            return View(oEmpleado);
        }

        [HttpPost]
        public IActionResult Editar(EmpleadosModel oEmpleado)
        {
            //if (ModelState.IsValid)
              //  return View();
            //recibe el objeto y lo guarda en la BD
            var respuesta = _EmpleadoData.Editar(oEmpleado);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Eliminar(int IdEmpleado)
        {
            //METODO SOLO DEVUELVE LA VISTA
            var ocontacto = _EmpleadoData.Obtener(IdEmpleado);
            return View(ocontacto);
        }

        [HttpPost]
        public IActionResult Eliminar(EmpleadosModel oContacto)
        {

            var respuesta = _EmpleadoData.Eliminar(oContacto.IdEmpleado);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }
    }
}
