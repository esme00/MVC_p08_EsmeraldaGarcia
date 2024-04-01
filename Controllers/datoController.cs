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
            // Muestra las habilidades
            var listaDeHabilidades = (from m in _datoContext.cursos
                                 select m).ToList();
            ViewData["listaDeHabilidades"] = new SelectList(listaDeHabilidades, "id_cursos", "nombre");

            return View();
        }

        public IActionResult CrearDato(dato nuevodato, string[] pasatiempo)
        {
            if (ModelState.IsValid)
            {
                // Verifica si hay pasatiempos seleccionados
                if (pasatiempo != null && pasatiempo.Length > 0)
                {
                    // Construye la cadena de pasatiempos seleccionados
                    string pasatiemposSeleccionados = string.Join(", ", pasatiempo);

                    // Asigna los pasatiempos seleccionados al objeto nuevodato
                    nuevodato.pasatiempo = pasatiemposSeleccionados;
                }

                // Agrega el nuevo dato al contexto y guarda los cambios
                _datoContext.Add(nuevodato);
                _datoContext.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                // Si el modelo no es válido, vuelve a cargar la vista con los errores de validación
                return View(nuevodato);
            }

            // DATO ANTIGUOS//
            //_datoContext.Add(nuevodato);
            //_datoContext.SaveChanges();
            //return RedirectToAction("Index");
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
                var dato = new dato { conocimientos = conocimientosSeleccionados };
                _datoContext.dato.Add(dato);
                _datoContext.SaveChanges();
            }

            // Redirigir a alguna acción de éxito o volver a la vista
            return RedirectToAction("Index"); 
        }

       
    }
   
}
