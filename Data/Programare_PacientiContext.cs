using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Programare_Pacienti.Models;

namespace Programare_Pacienti.Data
{
    public class Programare_PacientiContext : DbContext
    {
        public Programare_PacientiContext (DbContextOptions<Programare_PacientiContext> options)
            : base(options)
        {
        }

        public DbSet<Programare_Pacienti.Models.Patient> Patient { get; set; }

        public DbSet<Programare_Pacienti.Models.Consultation> Consultation { get; set; }

        public DbSet<Programare_Pacienti.Models.Category> Category { get; set; }

        
    }
}
