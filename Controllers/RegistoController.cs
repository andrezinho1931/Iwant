using CliSenhas2024.Data;
using CliSenhas2024.Models;
using CliSenhas2024.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Intrinsics.Arm;
using BCrypt.Net;
using CliSenhas2024.Filtros_adm;

namespace CliSenhas2024.Controllers
{
    
    public class RegistoController : Controller
    {
        private readonly IUtilizadorRepositorio dbp;

        public RegistoController(IUtilizadorRepositorio context)
        {
            dbp = context;
        }

        public IActionResult IndexCriar()
        {
            return View();
        }
        [PaginaParaAdm]
        public IActionResult IndexLista()
        {
            List<Utilizador> todosUtilizadores = dbp.BuscarTodos();
            return View(todosUtilizadores);
        }
        [PaginaParaAdm]
        public IActionResult IndexApagarConfirmacao(int id)
        {
            Utilizador utilizador = dbp.ListarPorId(id);
            return View(utilizador);
		}
        [PaginaParaAdm]
        public IActionResult Apagar(int id)
        {
            dbp.Apagar(id);
            return RedirectToAction("IndexLista");
        }
        public IActionResult IndexEditar(int id)
        {
            Utilizador utilizador = dbp.ListarPorId(id);
            return View(utilizador);
        }


        [HttpPost]
        public IActionResult Criar(Utilizador utilizador) //parametro que eu quero criar
        {
            if (ModelState.IsValid)
            {
                // Fazer o hashing da senha antes de salvar no banco de dados
                utilizador.Senha = BCrypt.Net.BCrypt.HashPassword(utilizador.Senha);

                dbp.Adicionar(utilizador);
                TempData["MensagemSucesso"] = "Utilizador criado com sucesso!";
                return RedirectToAction("IndexCriar");
            }
            return View("IndexCriar");
        }

        [HttpPost]
        public IActionResult Editar(Utilizador utilizador) //parametro que eu quero criar
        {
            if (ModelState.IsValid)
            {
                // Fazer o hashing da senha antes de salvar no banco de dados
                utilizador.Senha = BCrypt.Net.BCrypt.HashPassword(utilizador.Senha);

                dbp.Atualizar(utilizador);
                TempData["MensagemSucesso"] = "Utilizador atualizado com sucesso!";
                return RedirectToAction("IndexEditar");
            }
            return View("IndexEditar");
        }
    }
}
