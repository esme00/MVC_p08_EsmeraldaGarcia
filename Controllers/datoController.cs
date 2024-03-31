using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_p08_EsmeraldaGarcia.Models;

namespace MVC_p08_EsmeraldaGarcia.Controllers
{
    public class datoController : Controller
    {
        public IActionResult Index()
        {
            var listaDeHabilidades = (from m in _datoContext.cursos
                                 select m).ToList();
            ViewData["listaDeHabilidades"] = new SelectList(listaDeHabilidades, "id_cursos", "nombre");

            return View();
        }

        public IActionResult CrearDato(dato nuevodato)
        {
            _datoContext.Add(nuevodato);
            _datoContext.SaveChanges();

            return RedirectToAction("Index");
        }

        private readonly datosContext _datoContext;
        public datoController(datosContext datosContext)
        {
            _datoContext = datosContext;
        }
        public IActionResult GuardarConocimientos(string[] conocimientos)
        {
            if (conocimientos != null && conocimientos.Length > 0)
            {
                // Construir la cadena de conocimientos seleccionados
                string conocimientosSeleccionados = string.Join(", ", conocimientos);

                // Guardar en la base de datos o realizar cualquier otra operación necesaria
                // Por ejemplo:
                var dato = new dato { conocimientos = conocimientosSeleccionados };
                _datoContext.dato.Add(dato);
                _datoContext.SaveChanges();
            }

            // Redirigir a alguna acción de éxito o volver a la vista
            return RedirectToAction("Index"); // Por ejemplo, redirigir a la página principal
        }

    }
   
}
