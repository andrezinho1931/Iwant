using CliSenhas2024.Data;
using CliSenhas2024.Models;

namespace CliSenhas2024.Repositorio
{
    //É NELA QUE CONTÉM OS METÓDOS DE ADICIONAR, EXCLUIR, BUSCAR, ATUALIZAR AS INFORMACOES DA TABELA UTILIZADOR
    public class UtilizadorRepositorio : IUtilizadorRepositorio //implementaçao da interface 
    {
        private readonly ApplicationDbContext _dbp;
        public UtilizadorRepositorio(ApplicationDbContext bancoContext)//injetar base de dados,
                                                                       //entretanto eu so consigo acessar atraves dos metodos,
                                                                       //por isso terei que criar uma variavel privada
        {
            _dbp = bancoContext;
        }

        public Utilizador BuscarPorLogin(string login)
        {
            return _dbp.TUtilizadores.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper());
        }
        public List<Utilizador> BuscarTodos()   
        {
            return _dbp.TUtilizadores.ToList();
        }
        public Utilizador ListarPorId(int id)
        {
            return _dbp.TUtilizadores.FirstOrDefault(x => x.IdUtilizador == id);
        }

        public Utilizador Adicionar(Utilizador utilizador)
        {
            //gravar na base de dados (quem faz isso propiamente dito é o context),
            //portanto o contexto precisa ser injetado aqui (se faz isso com o construtor)
            _dbp.TUtilizadores.Add(utilizador); // aqui ja insere na base de dados, mas precisa de um commite(uma confirmação)
            _dbp.SaveChanges();  //commite
            return utilizador;
        }

        public bool Apagar(int id)
        {
            Utilizador utilizadorDB = ListarPorId(id);

            if (utilizadorDB == null) throw new System.Exception("Houve um erro na deleção do utilizador!");

            _dbp.TUtilizadores.Remove(utilizadorDB);
            _dbp.SaveChanges(); 

            return true;    
        
        }

        public Utilizador Atualizar(Utilizador utilizador)
        {
            Utilizador utilizadorDB = ListarPorId(utilizador.IdUtilizador);

            if (utilizadorDB == null) throw new System.Exception("Houve um erro na atualização do utilizador!");

            utilizadorDB.Nome = utilizador.Nome;
            utilizadorDB.Idade = utilizador.Idade;
            utilizadorDB.Curso = utilizador.Curso;
            utilizadorDB.Num_telefone = utilizador.Num_telefone;
            utilizadorDB.Email = utilizador.Email;
            utilizadorDB.Login = utilizador.Login;
            utilizadorDB.Senha = utilizador.Senha;
            utilizadorDB.Foto = utilizador.Foto;
            
            _dbp.TUtilizadores.Update(utilizadorDB);
            _dbp.SaveChanges();

            return utilizadorDB;
        }
    }
}
    