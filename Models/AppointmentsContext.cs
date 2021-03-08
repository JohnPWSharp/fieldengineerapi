using Microsoft.EntityFrameworkCore;

namespace FieldEngineerApi.Models
{

    public class AppointmentsContext : DbContext
    {
        public AppointmentsContext(DbContextOptions<AppointmentsContext> options)
            : base(options)
        {

        }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<AppointmentStatus> AppointmentStatuses { get; set; }

    }
}