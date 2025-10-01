using CliSenhas2024.Filtros_UtilizadoresLogados;
using CliSenhas2024.Models; 
using CliSenhas2024.Repositorio; 
using Microsoft.AspNetCore.Mvc; 


namespace CliSenhas2024.Data
{
    
    public class HomeController : Controller
    {
        // Dependência injetada para acessar o repositório de produtos
        private readonly IProdutoRepositorio _produtoRepositorio;

        // Dependência injetada para o serviço de logging (registros de log)
        private readonly ILogger<HomeController> dbp;

        // Construtor do controlador que injeta as dependências (repositório de produtos e logger)
        public HomeController(IProdutoRepositorio produtoRepositorio, ILogger<HomeController> context)
        {
            _produtoRepositorio = produtoRepositorio; // Atribui o repositório de produtos à variável _produtoRepositorio
            dbp = context; // Atribui o serviço de logging à variável dbp
        }

        public IActionResult Index()
        {
            // Obtém a lista de produtos do repositório de produtos
            var produtos = _produtoRepositorio.ObterTodos();
            // Retorna a view da página principal com a lista de produtos
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
