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


        public int GestorId { get; set; }

        public Gestor Gestor { get; set; }
    }
}
