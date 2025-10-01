using System.ComponentModel.DataAnnotations;

namespace CliSenhas2024.Models
{
    public class Produto
    {
        [Key]
        public int IdProduto { get; set; }
        public int IdUtilizador { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public string? Foto { get; set; }
        public double Preco { get; set; }
        public string? Tipo_produto { get; set; } // compra, venda
        public DateTime Data_publicacao { get; set; }
        public string? Estado_produto { get; set; } // ativo, desativo, vendido

    }

}
