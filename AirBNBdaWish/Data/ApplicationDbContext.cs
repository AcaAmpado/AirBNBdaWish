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

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<AvaliacaoCliente> AvaliacaoCliente { get; set; }
        public DbSet<AvaliacaoImovel> AvaliacaoImovel { get; set; }
        public DbSet<Funcionario> Funcionario { get; set; }
        public DbSet<Gestor> Gestor { get; set; }
        public DbSet<Imovel> Imovel { get; set; }
        public DbSet<Reserva> Reserva { get; set; }
    }
}
