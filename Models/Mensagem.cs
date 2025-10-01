using System.ComponentModel.DataAnnotations;

namespace CliSenhas2024.Models
{
    public class Mensagem
    {
        [Key]
        public int IdMensagem { get; set; }
        public int IdConversa { get; set; }
        public int IdRemetente { get; set; }
        public string? Conteudo { get; set; }
        public DateTime Data_hora_envio { get; set; }

     
    }

}
