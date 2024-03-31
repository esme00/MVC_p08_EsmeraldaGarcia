using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    }
   
}
