using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionForrajeria.Entities
{
    public class Bolsa
    {
        private int idBolsa;
        private int idMercaderia;
        private int peso;
        private double precio;
        private Mercaderia mercaderia;

        public int IdBolsa { get => idBolsa; set => idBolsa = value; }
        public int Peso { get => peso; set => peso = value; }
        public double Precio { get => precio; set => precio = value; }
        public int IdMercaderia { get => idMercaderia; set => idMercaderia = value; }
        public Mercaderia Mercaderia { get => mercaderia; set => mercaderia = value; }

        public Bolsa(int idBolsa, int peso, double precio, int idMercancia, Mercaderia mercaderia)
        {
            IdBolsa = idBolsa;
            Peso = peso;
            Precio = precio;
            IdMercaderia = idMercancia;
        }
    }
}
