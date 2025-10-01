//Define os métodos que qualquer classe que gerencie sessões precisa implementar
using CliSenhas2024.Models;

namespace CliSenhas2024.Repositorio
{
    //Interface Registo Repositorio
    public interface IProdutoRepositorio
    {
        Produto Adicionar(Produto produto); //Metodo adicionar que recebe como parametro o objeto "Utilizador"
                                            //e retorna o modelo quando ele adicionar na base de dados 

        IEnumerable<Produto> ObterTodos(); // Novo método para obter todos os produtos
    }
}

