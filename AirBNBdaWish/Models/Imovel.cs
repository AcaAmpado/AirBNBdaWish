using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirBNBdaWish.Models
{
    public class Imovel
    {
        public int Id { get; set; }

        public int IdFuncionario { get; set; }
        public Funcionario Funcionario { get; set; }

        public int IdGestor { get; set; }
        public Gestor Gestor { get; set; }
        
        public string Descricao { get; set; }

        // TODO imagens

        public double Preco { get; set; }

        public string Comodidades { get; set; }

    }
}
