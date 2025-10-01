using CliSenhas2024.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CliSenhas2024.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { 
        }

        public DbSet<Utilizador>? TUtilizadores { get; set; }
        public DbSet<Produto>? TProdutos { get; set; }
        public DbSet<Conversa>? TConversas { get; set; }
        public DbSet<Mensagem>? TMensagens { get; set; }
        public DbSet<Favorito>? TFavoritos { get; set; }
        public DbSet<Compra>? TCompras { get; set; }
        

    }
}
