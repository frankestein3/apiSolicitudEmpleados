namespace apiEmpleadoSolicitud.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Empleado")]
    public partial class Empleado
    {
        [Column(TypeName = "numeric")]
        public decimal id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? fecha_ingreso { get; set; }

        [StringLength(50)]
        public string nombre { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? salario { get; set; }

        
    }
}
