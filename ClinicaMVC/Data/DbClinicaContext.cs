using ClinicaMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace Clinica.Data
{
    public class DbClinicaContext : DbContext
    {
        public DbClinicaContext(DbContextOptions<DbClinicaContext> options) : base (options) { }        
       public virtual DbSet<Medico> Medicos { get; set; }
    }
}
