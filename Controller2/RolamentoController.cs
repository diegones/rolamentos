using Controllers.Base;
using Controllers.DAL;
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
            contexto.SaveChanges();

        }
        public Rolamento BuscarSku(int sku)
        {
            return contexto.Rolamentos.Find(sku);

        }
        public void Editar (Rolamento entity)
        {
            contexto.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            contexto.SaveChanges();

        }

        public void Excluir (int sku)
        {
            Rolamento rol = BuscarSku(sku);
            if(rol != null)
            {
                contexto.Rolamentos.Remove(rol);
                contexto.SaveChanges();
            }
        }

        //aplicar buscar por medida, escalavel "query"
    }
}
