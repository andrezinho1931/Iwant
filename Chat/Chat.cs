using Microsoft.AspNetCore.SignalR;
using CliSenhas2024.Data;


namespace ChatSignalR.Hubs
{
    public class ChatHub : Hub
    {
        private readonly ApplicationDbContext dbp;

        // Construtor que injeta o contexto do banco de dados
        public ChatHub(ApplicationDbContext context)
        {
            dbp = context;
        }

        // Método chamado quando um utilizador envia uma mensagem
        public async Task SendMessage(string usuarioLogado, string mensagem, string usuarioDestino)
        {
            // Verifica se o usuário está na base de dados
            var usuarioExistente = dbp.TUtilizadores
                .Any(u => u.Nome == usuarioLogado); 

            if (usuarioExistente)
            {
                // Envia a mensagem para todos os clientes conectados
                await Clients.All.SendAsync("ReceiveMessage", usuarioLogado, mensagem, usuarioDestino);
            }
            else
            {
                // Envia uma mensagem de erro ao utilizador que tentou enviar uma mensagem
                await Clients.Caller.SendAsync("ReceiveMessage", "Sistema", "Usuário não autorizado.", usuarioLogado);
            }
        }
    }
}
//O Task é um objeto que encapsula a operação assíncrona, permitindo que o método seja chamado de forma não bloqueante.

// await: é usado para pausar a execução de um método assíncrono até que a operação assíncrona seja concluída.
//no caso acima se eu não usar o await e apenas chamar SendAsync diretamente, o método continuaria sua execução imediatamente,
//sem esperar que a mensagem fosse enviada.

//Resumo, programação assíncrona otimiza o desempenho pois o envio das mensagens pode ser lento