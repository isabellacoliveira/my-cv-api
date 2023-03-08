using Microsoft.EntityFrameworkCore;
using myCvApi.Models;

namespace myCvApi.Data;

public class LinguagemContext : DbContext
{
    public LinguagemContext(DbContextOptions<LinguagemContext> opts) : base(opts)
    {

    }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Projeto>()
                .HasOne(projeto => projeto.Linguagem)
                .WithMany(linguagem => linguagem.Projetos)
                .HasForeignKey(projeto => projeto.LinguagemId);
        }
    public DbSet<Linguagem> Linguagens { get; set; }
    public DbSet<Projeto> Projetos { get; set; }

    internal class WebAppContext
    {
    }
}