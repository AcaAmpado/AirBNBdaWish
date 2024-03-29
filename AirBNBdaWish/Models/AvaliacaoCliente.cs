﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirBNBdaWish.Models
{
    public class AvaliacaoCliente
    {
        public int Id { get; set; }

        public int ReservaId { get; set; }
        public Reserva Reserva { get; set; }

        public int GestorId { get; set; }
        public Gestor Gestor { get; set; }

        public int Classificacao { get; set; }

        public string Comentario { get; set; }

    }
}
