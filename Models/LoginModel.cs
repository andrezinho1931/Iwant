using System.ComponentModel.DataAnnotations;

namespace CliSenhas2024.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Digite o login")]
        public string? Login { get; set; }

        [Required(ErrorMessage = "Digite a senha")]
        public string? Senha { get; set; }
    }
}
