//Define os métodos que qualquer classe que gerencie sessões precisa implementar
using CliSenhas2024.Models;

namespace CliSenhas2024.Repositorio
{
    //Interface Registo Repositorio
    public interface IUtilizadorRepositorio
    {
        Utilizador BuscarPorLogin(string login);

        List<Utilizador> BuscarTodos();
        Utilizador ListarPorId(int id);
        bool Apagar(int id);

        Utilizador Adicionar(Utilizador utilizador); //Metodo adicionar que recebe como parametro o objeto "Utilizador"
                                                     //e retorna o modelo quando ele adicionar na base de dados 

        Utilizador Atualizar(Utilizador utilizador);
    }
}
