using CliSenhas2024.Filtros_adm;
using Microsoft.AspNetCore.Mvc;

namespace CliSenhas2024.Controllers
{
    
    public class RestritoUtilizadoresController : Controller
    {
        public IActionResult IndexRestritoUtilizador()
        {
            return View();
        }
    }
}
