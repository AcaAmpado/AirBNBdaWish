using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AirBNBdaWish.Models
{
    public class Gestor
    {
        public int Id { get; set; }

        [Display(Name = "Nome Proprietário")]
        public string NomeProprietario { get; set; }

        public string Email { get; set; }

        public string Telemovel { get; set; }

        public string Password { get; set; }
    }
}
