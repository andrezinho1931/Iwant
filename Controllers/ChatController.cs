using Microsoft.AspNetCore.Mvc;
using CliSenhas2024.Data;
using CliSenhas2024.Filtros_UtilizadoresLogados;


namespace ChatSignalR.Controllers
{
    [PaginaParaUtilizadoresLogados]
    public class ChatController : Controller
    {
        private readonly ApplicationDbContext dbp;

        // Construtor que injeta o contexto do SignalR e o contexto do banco de dados
        public ChatController (ApplicationDbContext dbContext)
        {
            dbp = dbContext;
        }

        // Método para carregar a página do chat e passar o ConnectionId para a view
        public IActionResult IndexChat(string connectionId)
        {
            ViewBag.ConnectionId = connectionId;//Esse identificador permite ao SignalR gerenciar as comunicações
                                                //com diferentes utilizadpres de forma individual

            // Carrega a lista de usuários da base de dados
            var usuarios = dbp.TUtilizadores.Select(u => u.Nome).ToList();
            ViewBag.Usuarios = usuarios;

            return View();
        }

    }
}








//Controller: Envia mensagens através do IHubContext para o ChatHub.
//O controller pode fazer isso quando necessário,
//mas geralmente a comunicação em tempo real é gerenciada diretamente pelo JavaScript.

//View e JavaScript: Conectam - se diretamente ao ChatHub
//usando o endpoint /chat definido no Program.cs. 
//O JavaScript é responsável por lidar com a comunicação em tempo real
// e interagir com a interface do usuário.





// RESUMO

// O ChatHub gerencia a comunicação em tempo real e é acessado via SignalR.
// O ChatController pode enviar mensagens usando IHubContext mas não interage diretamente com os métodos de instância do ChatHub.
// A página do controller (Index.cshtml) fornece a interface do usuário e usa JavaScript para se conectar e
//interagir com o ChatHub via SignalR.