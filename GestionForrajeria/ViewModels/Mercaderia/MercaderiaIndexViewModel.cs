using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionForrajeria.ViewModels.Mercaderia
{
    public class MercaderiaIndexViewModel
    {
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public int? PrecioPorKg { get; set; }
        public int? PrecioPor100gr { get; set; }
    }
}
