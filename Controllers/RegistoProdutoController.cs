using CliSenhas2024.Data;
using CliSenhas2024.Filtros_adm;
using CliSenhas2024.Filtros_UtilizadoresLogados;
using CliSenhas2024.Models;
using CliSenhas2024.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace CliSenhas2024.Controllers
{
    [PaginaParaUtilizadoresLogados]
    public class RegistoProdutoController : Controller
    {
        // Injeção de dependência para acessar o repositório de produtos.
        private readonly IProdutoRepositorio dbp;

        // Construtor que recebe uma instância de IProdutoRepositorio e a atribui ao campo privado dbp.
        public RegistoProdutoController(IProdutoRepositorio context)
        {
            dbp = context;
        }

        // Método de ação que exibe a página de registo de produtos.
        public IActionResult IndexRegistoProduto()
        {
            return View(); // Retorna a view associada à página de registo.
        }

        // Método de ação HTTP POST que processa o registo de um produto.
        // Recebe um objeto Produto com os dados enviados no formulário.
        
        [HttpPost]
        public IActionResult Registar(Produto produto)
        {
            // Verifica se os dados do modelo (Produto) são válidos conforme as regras de validação.
            if (ModelState.IsValid)
            {
                // Chama o método Adicionar do repositório para salvar o produto no banco de dados.
                dbp.Adicionar(produto);

                // TempData para armazenar uma mensagem temporária de sucesso, que será exibida na próxima requisição.
                TempData["MensagemSucesso"] = "Produto registado com sucesso!";

                // Redireciona para a ação IndexRegistoProduto, para exibir novamente a página de registo.
                return RedirectToAction("IndexRegistoProduto");
            }

            // Caso o modelo seja inválido, a mesma página de registo é retornada para que o usuário corrija os erros.
            return View("IndexRegistoProduto");
        }
    }
}
