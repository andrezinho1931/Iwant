using CliSenhas2024.Models; 
using Microsoft.AspNetCore.Mvc;  
using Newtonsoft.Json;  // Importa a biblioteca 'Newtonsoft.Json', que é usada para manipulação de JSON (conversão entre objetos e JSON).

namespace CliSenhas2024.ViewComponentes 
{
    public class Menu : ViewComponent
    {
        // Método 'InvokeAsync' - Executa o componente de forma assíncrona.
        // IViewComponentResult é o retorno do componente, que será renderizado numa View.
        public async Task<IViewComponentResult> InvokeAsync()
        {
            // Tenta recuperar uma string da sessão HTTP do usuário, usando a chave 'sessaoUtilizadorLogado'.
            // 'HttpContext.Session' dá acesso à sessão do usuário atual.
            string sessaoUtilizador = HttpContext.Session.GetString("sessaoUtilizadorLogado");

            // Se 'sessaoUtilizador' estiver vazia ou for nula, retorna o menu para um usuário não logado.
            if (string.IsNullOrEmpty(sessaoUtilizador)) return View("IndexDes");

            // Caso 'sessaoUtilizador' não esteja vazia, converte o conteúdo da sessão de volta
            // para um objeto 'Utilizador' usando 'JsonConvert.DeserializeObject'.
            // Isso ocorre porque os dados do usuário foram salvos como JSON na sessão.
            Utilizador utilizador = JsonConvert.DeserializeObject<Utilizador>(sessaoUtilizador);

            // Retorna uma View padrão passando o objeto 'utilizador' para ser usado na exibição da interface.
            return View(utilizador);
        }
    }
}
