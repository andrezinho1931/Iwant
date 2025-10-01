using CliSenhas2024.Data;
using CliSenhas2024.Models;

namespace CliSenhas2024.Repositorio
{
    //É NELA QUE CONTÉM OS METÓDOS DE ADICIONAR, EXCLUIR, BUSCAR, ATUALIZAR AS INFORMACOES DA TABELA PRODUTOS
    public class ProdutoRepositorio : IProdutoRepositorio //implementaçao da interface 
    {
        private readonly ApplicationDbContext __dbp;
        public ProdutoRepositorio(ApplicationDbContext bancoContextt)//injetar base de dados,
                                                                       //entretanto eu so consigo acessar atraves dos metodos,
                                                                       //por isso terei que criar uma variavel privada
        {
            __dbp = bancoContextt;
        }


        public Produto Adicionar(Produto produto)
        {
            //gravar na base de dados (quem faz isso propiamente dito é o context),
            //portanto o contexto precisa ser injetado aqui (se faz isso com o construtor)
            __dbp.TProdutos.Add(produto); // aqui ja insere na base de dados, mas precisa de um commite(uma confirmação)
            __dbp.SaveChanges();  //commite
            return produto;
        }

        public IEnumerable<Produto> ObterTodos()
        {
            return __dbp.TProdutos.ToList(); // Retorna a lista de todos os produtos
        }

    }
}
