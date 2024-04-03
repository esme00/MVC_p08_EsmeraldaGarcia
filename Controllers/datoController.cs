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

            var listadodeequipo = (from d in _datoContext.dato
                                   join c in _datoContext.cursos on d.id_cursos equals c.id_cursos
                                   select new
                                   {
                                       nombre = d.name_user ?? "Sin nombre", // Usando el operador de coalescencia nula para manejar valores nulos
                                       genero = d.genero ?? "No especificado",
                                       pasatiempo = d.pasatiempo ?? "Ninguno",
                                       curso = c.nombre ?? "Sin curso", 
                                       conocimientos = d.conocimientos ?? "Ninguno"
                                   }).ToList();
            ViewData["listadodeequipo"] = listadodeequipo;

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
