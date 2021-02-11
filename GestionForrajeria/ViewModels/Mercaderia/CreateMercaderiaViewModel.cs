using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestionForrajeria.ViewModels.Mercaderia
{
    public class CreateMercaderiaViewModel
    {
        [Required(ErrorMessage = "Coloque un nombre al producto")]
        public string Nombre { get; set; }

        [Range(0,10000, ErrorMessage = "El valor debe ser entre 0 y 10000")]
        public int? PrecioPorKg { get; set; }

        [Range(0, 10000, ErrorMessage = "El valor debe ser entre 0 y 10000")]
        public int? PrecioPor100gr { get; set; }

        [Required(ErrorMessage = "Asigne una categoria al producto")]
        public int IdCategoria { get; set; }

        public List<SelectListItem> Categorias { get; set; }
    }
}
