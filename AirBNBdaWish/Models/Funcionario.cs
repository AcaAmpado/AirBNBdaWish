using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AirBNBdaWish.Models
{
    public class Funcionario
    {
        public int Id { get; set; }

        [Display(Name = "Nome do Funcionario")]
        public string NomeFuncionario { get; set; }

        public string Email { get; set; }

        public string Telemovel { get; set; }

        public string Password { get; set; }

        public int GestorId { get; set; }

        public Gestor Gestor { get; set; }
    }
}
