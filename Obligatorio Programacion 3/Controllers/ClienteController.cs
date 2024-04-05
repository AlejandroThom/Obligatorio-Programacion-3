using Microsoft.AspNetCore.Mvc;

namespace Obligatorio_Programacion_3.Controllers
{
    public class ClienteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
