using AgendaVacina.Models;
using Microsoft.EntityFrameworkCore;

namespace AgendaVacina.Data
{
    public class AgendaVacinaContext : DbContext
    {
        public AgendaVacinaContext(DbContextOptions<AgendaVacinaContext> options)
            : base(options)
        {
        }

        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<Local> Local { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
    }
}