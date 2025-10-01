using System.ComponentModel.DataAnnotations;

namespace CliSenhas2024.Models
{
    public class Favorito
    {
        [Key]
        public int IdFavorito { get; set; }
        public int IdUtilizador { get; set; }
        public int IdProduto { get; set; }

      
    }

}
