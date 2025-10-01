"use strict"; // Modo estrito do JavaScript, ajuda a evitar erros silenciosos e impõe regras mais rígidas.

// Cria uma conexão com o SignalR, especificando o URL do hub de chat.
var connection = new signalR.HubConnectionBuilder().withUrl("/chat").build();

// Evento que escuta a mensagem recebida no SignalR e executa uma ação quando a mensagem é recebida.
connection.on("ReceiveMessage", function (usuarioQueMandou, mensagem, usuarioQueRecebe) {
    console.log("Mensagem recebida de " + usuarioQueMandou); // Exibe no console quem enviou a mensagem.

    // Obtém o nome do usuário logado a partir de um campo oculto (por exemplo, um input).
    var usuarioLogado = $("#usuario").val();

    // Verifica se o usuário logado é o destinatário da mensagem ou se a mensagem foi enviada para "todos".
    if (usuarioLogado == usuarioQueRecebe || usuarioQueRecebe == 'todos') {
        // Substitui caracteres especiais na mensagem para prevenir injeção de código (XSS).
        var msg = mensagem.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");

        // Cria um novo item de lista (li) com a mensagem formatada.
        var li = $("<li></li>").text(usuarioQueMandou + ": " + msg);
        li.addClass("list-group-item"); // Adiciona uma classe de estilo ao item.

        // Adiciona o item de mensagem à lista de mensagens na interface.
        $("#messagesList").append(li);
    }

    // Caso o usuário logado seja quem enviou a mensagem e a mensagem não seja para "todos".
    if (usuarioLogado == usuarioQueMandou && usuarioQueRecebe != 'todos') {
        // Faz a mesma substituição de caracteres especiais para proteger contra XSS.
        var msg = mensagem.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");

        // Cria o item de lista com a mensagem enviada.
        var li = $("<li></li>").text(usuarioQueMandou + ": " + msg);
        li.addClass("list-group-item"); // Classe para estilo.
        li.addClass("quandoManda"); // Adiciona outra classe de estilo para mensagens enviadas pelo usuário.

        // Adiciona o item de mensagem à lista de mensagens.
        $("#messagesList").append(li);
    }
});

// Evento disparado quando o botão de enviar é clicado.
$("#send").on("click", function (event) {
    console.log("Botão de enviar clicado."); // Log para verificar se o clique foi detectado.

    // Obtém a mensagem escrita no campo de entrada de mensagem.
    var mensagem = $("#mensagem").val();

    // Obtém o usuário destinatário da mensagem (quem deve receber).
    var usuarioDestino = $("#destino").val();

    // Obtém o nome do usuário logado.
    var usuarioLogado = $("#usuario").val();

    // Envia a mensagem para o backend via SignalR (chama o método SendMessage no servidor).
    connection.invoke("SendMessage", usuarioLogado, mensagem, usuarioDestino).catch(function (err) {
        // Se ocorrer um erro ao enviar a mensagem, exibe o erro no console.
        return console.error(err.toString());
    });

    event.preventDefault(); // Evita que o botão de envio recarregue a página.
});

// Inicia a conexão com o SignalR.
connection.start().then(function () {
    console.log("Conectado ao SignalR"); // Log de sucesso quando a conexão é estabelecida.
}).catch(function (err) {
    // Caso ocorra um erro ao conectar, exibe a mensagem de erro.
    console.error("Erro ao conectar ao SignalR: ", err.toString());
});

// Quando o documento (HTML) estiver completamente carregado, executa essa função.
$(document).ready(function () {
    // Cria uma lista de nomes de usuários aleatórios.
    var quotes = ["joao", "pedro", "lucas", "samuel"];

    // Seleciona um nome aleatório da lista.
    var randno = quotes[Math.floor(Math.random() * quotes.length)];

    // Define o nome aleatório no campo oculto que contém o nome do usuário logado.
    $('#usuario').val(randno);
});
