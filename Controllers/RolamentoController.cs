using Controller.Base;
using Controller.DAL;
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

        public Rolamento BuscarPorID(int id)
        {
            return contexto.Rolamentos.Find(id);
        }

        public void Editar(Rolamento entity)
        {
            contexto.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            contexto.SaveChanges();
        }

        public void Excluir(int id)
        {
                Rolamento rol = BuscarPorID(id);
                if (rol != null)
                {
                contexto.Rolamentos.Remove(rol);
                contexto.SaveChanges();
                }
        }

        public void Incluir(Rolamento entity)
        {
            contexto.Rolamentos.Add(entity);
            contexto.SaveChanges();

        }

        public IList<Rolamento> ListarPorNome(string nome)
        {
            return contexto.Rolamentos.Where(rol => rol.Sku == nome).ToList();
        }

        public IList<Rolamento> ListarTodos()
        {
            return contexto.Rolamentos.ToList();
        }

        public IList<Rolamento> ListarPorDiametroInterno(int diametroInterno)
        {
            return contexto.Rolamentos.Where(r => r.Di == diametroInterno).ToList();
        }
        public IList<Rolamento> ListarPorDiametroExterno(int diametroExterno)
        {
            return contexto.Rolamentos.Where(r => r.Do == diametroExterno).ToList();
        }
        public IList<Rolamento> ListarPorlargura(int largura)
        {
            return contexto.Rolamentos.Where(r => r.W1 == largura).ToList();
        }
    }

        //aplicar buscar por medida, escalavel "query"
    }
