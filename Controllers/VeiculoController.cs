using Controller.Base;
using Controller.DAL;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class VeiculoController : IBaseController<Veiculo>
    {
        private Contexto contexto = new Contexto();

        public void Incluir(Veiculo entity)
        {
            contexto.Veiculos.Add(entity);
            contexto.SaveChanges();

        }
        public Veiculo BuscarPorID(int id)
        {
            return contexto.Veiculos.Find(id);

        }
        public void Editar(Veiculo entity)
        {
            contexto.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            contexto.SaveChanges();

        }

        public void Excluir(int id)
        {
            Veiculo carro = BuscarPorID(id);
            if (carro != null)
            {
                contexto.Veiculos.Remove(carro);
                contexto.SaveChanges();
            }
        }

        public IList<Veiculo> ListarTodos()
        {
            return contexto.Veiculos.ToList();
        }

        public IList<Veiculo> ListarPorNome(string nome)
        {
            return contexto.Veiculos.Where(carro => carro.Marca.Contains(nome)).ToList();
        }

        public IList<Veiculo> ListaVeiculosPorMarca(string marca)
        {
            return contexto.Veiculos.Where(carro => carro.Marca.Contains(marca)).ToList();
        }

    }
        

    
}
