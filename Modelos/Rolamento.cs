using Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Rolamento 
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Sku { get; set; }

        [Required]
        public int Di { get; set; }

        [Required]
        public int Do { get; set; }

        [Required]
        public int W1 { get; set; }

        [Required]
        public ICollection<Veiculo> ListaVeiculos { get; set; }
    }
}
