using AirBNBdaWish.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirBNBdaWish.Data
{
    public class ApplicationDbContext : IdentityDbContext<Utilizador>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        DbSet <Cliente> Cliente { get; set; }
        DbSet<AvaliacaoCliente> AvaliacaoCliente { get; set; }
        DbSet<AvaliacaoImovel> AvaliacaoImovel { get; set; }
        DbSet<Funcionario> Funcionario { get; set; }
        DbSet<Gestor> Gestor { get; set; }
        DbSet<Imovel> Imovel { get; set; }
        DbSet<Reserva> Reserva { get; set; }
    }
}
