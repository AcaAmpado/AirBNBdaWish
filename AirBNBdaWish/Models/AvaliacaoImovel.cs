using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirBNBdaWish.Models
{
    public class AvaliacaoImovel
    {
        public int Id { get; set; }

        public int IdReserva { get; set; }
        public Reserva Reserva { get; set; }

        public int Classificacao { get; set; }

        public string Comentario { get; set; }

    }
}
