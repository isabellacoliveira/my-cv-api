using Microsoft.EntityFrameworkCore;
using myCvApi.Models;

namespace myCvApi.Data;

public class LinguagemContext : DbContext
{
    public LinguagemContext(DbContextOptions<LinguagemContext> opts) : base(opts)
    {

    }
    public DbSet<Linguagem> Linguagens { get; set; }
}