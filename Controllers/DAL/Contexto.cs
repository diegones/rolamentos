using Modelos;
using System.Data.Entity;

namespace Controller.DAL
{   
    class Contexto : DbContext
    {
        public Contexto() : base("strConn")
        {
        }
        public DbSet<Rolamento> Rolamentos { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }
    }
}