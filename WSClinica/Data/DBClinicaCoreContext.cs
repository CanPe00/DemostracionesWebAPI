using Microsoft.EntityFrameworkCore;
using WSClinica.Models;

namespace WSClinica.Data
{
    public class DBClinicaCoreContext:DbContext
    {
        public DBClinicaCoreContext(DbContextOptions<DBClinicaCoreContext> options):base(options) { }

        public DbSet<Habitacion> Habitaciones { get; set; }
        public DbSet<Clinica> Clinicas { get; set; }
        public DbSet<Especialidad> Especialidades { get;set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Paciente> Pacientes { get; set;}
    }
}
