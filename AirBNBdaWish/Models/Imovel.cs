using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AirBNBdaWish.Models
{
    public class Imovel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Funcionário")]
        public int FuncionarioId { get; set; }
        public Funcionario Funcionario { get; set; }
        
        [Required]
        [Display(Name = "Gestor")]
        public int GestorId { get; set; }
        public Gestor Gestor { get; set; }

        [Required]
        public String Nome { get; set; }

        [Required]
        public string Descricao { get; set; }

        [Required]
        public string Cidade { get; set; }
        [Required]
        public string Localidade { get; set; }
        [Required]
        public string Rua{ get; set; }
        [Required]
        public string Porta{ get; set; }
        [Required]
        public string CodigoPostal { get; set; }
        // TODO imagens
        [Required]
        public double Preco { get; set; }
        
        public string Comodidades { get; set; }

    }
}
