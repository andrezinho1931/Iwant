using CliSenhas2024.AjudanteVSessao;
using CliSenhas2024.Data;
using CliSenhas2024.Models;
using CliSenhas2024.Repositorio;
using Microsoft.AspNetCore.Mvc;
using BCrypt.Net; // Para usar o BCrypt

namespace CliSenhas2024.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUtilizadorRepositorio dbp;
        private readonly ISessao _sessao;

        public LoginController(IUtilizadorRepositorio context, ISessao sessao)
        {
            dbp = context;
            _sessao = sessao;
        }

        public IActionResult IndexLogin()
        {
            if (_sessao.BuscarSessaoDoUtilizador() != null) return RedirectToAction("Index", "Home");
            return View();
        }

        public IActionResult Sair()
        {
            _sessao.RemoverSessaoDoUtilizador();
            return RedirectToAction("IndexLogin", "Login");
        }

        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Busca o utilizador pelo login (e-mail, nome de utilizador, etc.)
                    Utilizador utilizador = dbp.BuscarPorLogin(loginModel.Login);

                    if (utilizador != null)
                    {
                        // Verifica se a senha fornecida corresponde ao hash armazenado
                        if (BCrypt.Net.BCrypt.Verify(loginModel.Senha, utilizador.Senha))
                        {
                            _sessao.CriarSessaoDoUtilizador(utilizador);
                            return RedirectToAction("Index", "Home");
                        }
                    }

                    // Se o utilizador não for encontrado ou a senha for inválida
                    TempData["MensagemErro"] = "Utilizador e/ou senha inválido(s). Por favor, tente novamente.";
                }

                return View("IndexLogin");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos realizar seu login, tente novamente. Detalhes do erro: {erro.Message}";
                return RedirectToAction("IndexLogin");
            }
        }
    }
}
