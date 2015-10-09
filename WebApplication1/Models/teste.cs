using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace WebApplication1.Models
{
    public class Teste
    {
        public int id { get; set; }
        public string titulo {get; set;}
    }

    public class TesteDbContext : DbContext
    {
        public TesteDbContext() : base("testeConn") {}
        public DbSet<Teste> Testes { get; set; }
    }
}
