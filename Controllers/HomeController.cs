using CliSenhas2024.Filtros_UtilizadoresLogados;
using CliSenhas2024.Models; 
using CliSenhas2024.Repositorio; 
using Microsoft.AspNetCore.Mvc; 


namespace CliSenhas2024.Data
{
    
    public class HomeController : Controller
    {
        // Depend�ncia injetada para acessar o reposit�rio de produtos
        private readonly IProdutoRepositorio _produtoRepositorio;

        // Depend�ncia injetada para o servi�o de logging (registros de log)
        private readonly ILogger<HomeController> dbp;

        // Construtor do controlador que injeta as depend�ncias (reposit�rio de produtos e logger)
        public HomeController(IProdutoRepositorio produtoRepositorio, ILogger<HomeController> context)
        {
            _produtoRepositorio = produtoRepositorio; // Atribui o reposit�rio de produtos � vari�vel _produtoRepositorio
            dbp = context; // Atribui o servi�o de logging � vari�vel dbp
        }

        public IActionResult Index()
        {
            // Obt�m a lista de produtos do reposit�rio de produtos
            var produtos = _produtoRepositorio.ObterTodos();
            // Retorna a view da p�gina principal com a lista de produtos
            return View(produtos);
        }


        public IActionResult Sobre()
        {
            return View(); 
        }

      
        public IActionResult Termos()
        {
            return View(); 
        }

        public IActionResult LivroReclamacao()
        {
            return View(); 
        }


        public IActionResult Privacy()
        {
            return View(); 
        }
    }
}
