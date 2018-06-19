using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Rolamento
    {
        public int Id { get; set; }

        public string Sku { get; set; }

        public int Di { get; set; }

        public int Do { get; set; }

        public int W1 { get; set; }
            
        public bool Ativo { get; set; }
        
        public ICollection<Veiculo> ListaVeiculos { get; set; }
    }
}
