using Microsoft.AspNetCore.Mvc;
using MVC_p08_EsmeraldaGarcia.Models;

namespace MVC_p08_EsmeraldaGarcia.Controllers
{
    public class datoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CrearDato(datos nuevodato)
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
