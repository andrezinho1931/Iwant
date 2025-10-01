using System.ComponentModel.DataAnnotations;

namespace CliSenhas2024.Models
{
    public class Compra
    {
        [Key]
        public int IdCompra { get; set; }
        public int IdProduto { get; set; }
        public int IdComprador { get; set; }
        public int IdVendedor { get; set; }
        public DateTime Data_hora_compra { get; set; }
        public double Preco_pago { get; set; }

    }
}
