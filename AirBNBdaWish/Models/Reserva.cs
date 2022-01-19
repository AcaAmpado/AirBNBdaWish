using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirBNBdaWish.Models
{
    public class Reserva
    {
        public int Id { get; set; }

        public int IdImovel { get; set; }

        public Imovel Imovel { get; set; }

        public int IdCliente { get; set; }

        public Cliente Cliente { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime DataFim { get; set; }

    }
}
