using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace apiEmpleadoSolicitud.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Empleado> Empleado { get; set; }
        public virtual DbSet<Solicitud> Solicitud { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Empleado>()
                .Property(e => e.id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Empleado>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Empleado>()
                .Property(e => e.salario)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Solicitud>()
                .Property(e => e.id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Solicitud>()
                .Property(e => e.codigo)
                .IsUnicode(false);

            modelBuilder.Entity<Solicitud>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Solicitud>()
                .Property(e => e.resumen)
                .IsUnicode(false);

            modelBuilder.Entity<Solicitud>()
                .Property(e => e.id_empleado)
                .HasPrecision(18, 0);
        }
    }
}
