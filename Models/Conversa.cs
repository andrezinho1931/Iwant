using System.ComponentModel.DataAnnotations;

namespace CliSenhas2024.Models
{
    public class Conversa
    {

        [Key]
        public int IdConversa { get; set; }
        public int IdRemetente { get; set; }
        public int IdDestinatario { get; set; }
        public DateTime Data_hora_inicio { get; set; }
        public string? Estado_conversa { get; set; } // aberta, fechada

    }

}
