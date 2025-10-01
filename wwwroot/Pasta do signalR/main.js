"use strict"; // Modo estrito do JavaScript, ajuda a evitar erros silenciosos e imp�e regras mais r�gidas.

// Cria uma conex�o com o SignalR, especificando o URL do hub de chat.
var connection = new signalR.HubConnectionBuilder().withUrl("/chat").build();

// Evento que escuta a mensagem recebida no SignalR e executa uma a��o quando a mensagem � recebida.
connection.on("ReceiveMessage", function (usuarioQueMandou, mensagem, usuarioQueRecebe) {
    console.log("Mensagem recebida de " + usuarioQueMandou); // Exibe no console quem enviou a mensagem.

    // Obt�m o nome do usu�rio logado a partir de um campo oculto (por exemplo, um input).
    var usuarioLogado = $("#usuario").val();

    // Verifica se o usu�rio logado � o destinat�rio da mensagem ou se a mensagem foi enviada para "todos".
    if (usuarioLogado == usuarioQueRecebe || usuarioQueRecebe == 'todos') {
        // Substitui caracteres especiais na mensagem para prevenir inje��o de c�digo (XSS).
        var msg = mensagem.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");

        // Cria um novo item de lista (li) com a mensagem formatada.
        var li = $("<li></li>").text(usuarioQueMandou + ": " + msg);
        li.addClass("list-group-item"); // Adiciona uma classe de estilo ao item.

        // Adiciona o item de mensagem � lista de mensagens na interface.
        $("#messagesList").append(li);
    }

    // Caso o usu�rio logado seja quem enviou a mensagem e a mensagem n�o seja para "todos".
    if (usuarioLogado == usuarioQueMandou && usuarioQueRecebe != 'todos') {
        // Faz a mesma substitui��o de caracteres especiais para proteger contra XSS.
        var msg = mensagem.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");

        // Cria o item de lista com a mensagem enviada.
        var li = $("<li></li>").text(usuarioQueMandou + ": " + msg);
        li.addClass("list-group-item"); // Classe para estilo.
        li.addClass("quandoManda"); // Adiciona outra classe de estilo para mensagens enviadas pelo usu�rio.

        // Adiciona o item de mensagem � lista de mensagens.
        $("#messagesList").append(li);
    }
});

// Evento disparado quando o bot�o de enviar � clicado.
$("#send").on("click", function (event) {
    console.log("Bot�o de enviar clicado."); // Log para verificar se o clique foi detectado.

    // Obt�m a mensagem escrita no campo de entrada de mensagem.
    var mensagem = $("#mensagem").val();

    // Obt�m o usu�rio destinat�rio da mensagem (quem deve receber).
    var usuarioDestino = $("#destino").val();

    // Obt�m o nome do usu�rio logado.
    var usuarioLogado = $("#usuario").val();

    // Envia a mensagem para o backend via SignalR (chama o m�todo SendMessage no servidor).
    connection.invoke("SendMessage", usuarioLogado, mensagem, usuarioDestino).catch(function (err) {
        // Se ocorrer um erro ao enviar a mensagem, exibe o erro no console.
        return console.error(err.toString());
    });

    event.preventDefault(); // Evita que o bot�o de envio recarregue a p�gina.
});

// Inicia a conex�o com o SignalR.
connection.start().then(function () {
    console.log("Conectado ao SignalR"); // Log de sucesso quando a conex�o � estabelecida.
}).catch(function (err) {
    // Caso ocorra um erro ao conectar, exibe a mensagem de erro.
    console.error("Erro ao conectar ao SignalR: ", err.toString());
});

// Quando o documento (HTML) estiver completamente carregado, executa essa fun��o.
$(document).ready(function () {
    // Cria uma lista de nomes de usu�rios aleat�rios.
    var quotes = ["joao", "pedro", "lucas", "samuel"];

    // Seleciona um nome aleat�rio da lista.
    var randno = quotes[Math.floor(Math.random() * quotes.length)];

    // Define o nome aleat�rio no campo oculto que cont�m o nome do usu�rio logado.
    $('#usuario').val(randno);
});
