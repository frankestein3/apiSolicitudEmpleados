namespace apiEmpleadoSolicitud.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Solicitud")]
    public partial class Solicitud
    {
        [Column(TypeName = "numeric")]
        public decimal id { get; set; }

        [StringLength(50)]
        public string codigo { get; set; }

        [StringLength(50)]
        public string descripcion { get; set; }

        [StringLength(50)]
        public string resumen { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? id_empleado { get; set; }

        

    }
}
