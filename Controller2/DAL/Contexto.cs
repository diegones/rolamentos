using Modelos;

namespace Controllers
{
    class Contexto : DbContext
    {
        public Contexto() : base("strConn")
        {
        }
        public Dbset<Rolamento> Rolamentos { get; set; }
    }
}