using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionForrajeria.Entities
{
    public class Mercaderia
    {
        private int idMercaderia;
        private string nombre;
        private int idCategoria;
        private string categoria;
        private int? precioPorKg;
        private int? precioPor100gr;

        public int IdMercaderia { get => idMercaderia; set => idMercaderia = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public int IdCategoria { get => idCategoria; set => idCategoria = value; }
        public string Categoria { get => categoria; set => categoria = value; }
        public int? PrecioPorKg { get => precioPorKg; set => precioPorKg = value; }
        public int? PrecioPor100gr { get => precioPor100gr; set => precioPor100gr = value; }

        public Mercaderia(int idMercaderia, string nombre, int idCategoria, string categoria, int? precioPorKg, int? precioPor100gr)
        {
            IdMercaderia = idMercaderia;
            Nombre = nombre;
            IdCategoria = idCategoria;
            Categoria = categoria;
            PrecioPorKg = precioPorKg;
            PrecioPor100gr = precioPor100gr;
        }
    }
}
