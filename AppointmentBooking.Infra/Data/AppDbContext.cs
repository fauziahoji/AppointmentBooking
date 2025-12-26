using AppointmentBooking.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace AppointmentBooking.Infra.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Appointment> appointmentsEntity { get; set; }
        public DbSet<AgencySetting> agencyEntity { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.HasKey(p => p.Id);

                entity.Property(e => e.CustomerName)
                .IsRequired().HasMaxLength(100);

                entity.Property(e => e.AppointmentDate)
                      .IsRequired();

                entity.Property(e => e.TokenNumber)
                      .IsRequired();
            });

            modelBuilder.Entity<AgencySetting>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.MaxAppointmentsPerDay)
                      .IsRequired();
            });
        }
    }
}
