using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AirBNBdaWish.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        public string UtilizadorId { get; set; }
        public Utilizador Utilizador { get; set; }
    }
}
