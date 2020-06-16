using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionDePersonas.Model;

namespace GestionDePersonas.DA
{
    public class AppDbContext : DbContext
    {  
        public DbSet<Persona> Personas { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> opciones) : base(opciones)
        {

         

        }
    }
}
