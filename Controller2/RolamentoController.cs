using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Controllers
{
    public class RolamentoController : IBaseController<Rolamento>
    {
        private Contexto contexto = new Contexto();

        public void Incluir(Rolamento entity)
        {
            contexto.Rolamentos.Add(entity);

        }


    }
}
