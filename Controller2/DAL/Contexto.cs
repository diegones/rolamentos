using Modelos;

namespace Controllers.DAL
{   
    class Contexto : DbContext
    {
        public Contexto() : base("strConn")
        {
        }
        public Dbset<Rolamento> Rolamentos { get; set; }
    }
}