//Define os métodos que qualquer classe que gerencie sessões precisa implementar
//nesse caso a classe Sessao
using CliSenhas2024.Models;

namespace CliSenhas2024.AjudanteVSessao
{
    public interface ISessao
    {
        void CriarSessaoDoUtilizador(Utilizador utilizador); //void pq n retorna nenhum valor
        void RemoverSessaoDoUtilizador();
        Utilizador BuscarSessaoDoUtilizador();//Este método recupera a sessão ativa de um usuário.
                                              //Ele busca e retorna um objeto Utilizador correspondente
                                              //à sessão atual (se houver uma sessão ativa).

    }
}
   