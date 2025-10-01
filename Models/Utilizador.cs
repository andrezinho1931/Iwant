using CliSenhas2024.TipoDaConta;
using System.ComponentModel.DataAnnotations;

namespace CliSenhas2024.Models
{
    public class Utilizador
    {
        [Key]
        public int IdUtilizador { get; set; }
        [Required(ErrorMessage = "Digite o nome do utilizador")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite o Email do utilizador")]
        [EmailAddress(ErrorMessage = "O e-mail informado não é válido!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Digite o login do utilizador")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Digite sua senha do utilizador")]
        public string Senha { get; set; }
        public string? Foto { get; set; }
        [Required(ErrorMessage = "Digite a idade do utilizador")]
        public int Idade { get; set; }
        [Required(ErrorMessage = "Digite o curso do utilizador")]
        public string Curso { get; set; }
        [Required(ErrorMessage = "Digite o telemóvel do utilizador")]
        public string Num_telefone { get; set; }
        public DateTime Data_registo { get; set; }
        public Tipo_conta Perfil { get; set; } // utilizador normal, administrador

        public bool SenhaValida(string senha)
        {
            return Senha == senha;
        }

    }
}
