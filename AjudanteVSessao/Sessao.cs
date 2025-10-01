
//Tem como objetivo manipular a sessão de um utilizador autenticado
using CliSenhas2024.Models;
using Newtonsoft.Json;

namespace CliSenhas2024.AjudanteVSessao
{
    public class Sessao : ISessao
    {
        private readonly IHttpContextAccessor _httpContext; //O IHttpContextAccessor permite acessar o HttpContext (Uma classe que armazena
                                                            //dados do utilizador em diferentes sessoes)
                                                            //fora de controlador, e serve para facilitar o acesso a informações de sessão
        public Sessao(IHttpContextAccessor httpContext)//injetar base de dados,
                                                       //entretanto eu so consigo acessar atraves dos metodos,
                                                       //por isso terei que criar uma variavel privada
        {
            _httpContext = httpContext;
        }
        public Utilizador BuscarSessaoDoUtilizador()
        {
            string sessaoUtilizador = _httpContext.HttpContext.Session.GetString("sessaoUtilizadorLogado");

            if (string.IsNullOrEmpty(sessaoUtilizador)) return null;

            return JsonConvert.DeserializeObject<Utilizador>(sessaoUtilizador);
        }

        public void CriarSessaoDoUtilizador(Utilizador utilizador) 
        {
            string valor = JsonConvert.SerializeObject(utilizador); 

            _httpContext.HttpContext.Session.SetString("sessaoUtilizadorLogado", valor); //nao dar para colocar simplesmente "utilizador" como valor,
                                                                                      //na "chave valor", pq ele é um objeto, portanto,
                                                                                      //primeiro eu tenho que transformar o obj em string
        }

        public void RemoverSessaoDoUtilizador()
        {
            _httpContext.HttpContext.Session.Remove("sessaoUtilizadorLogado");
        }
    }
}
