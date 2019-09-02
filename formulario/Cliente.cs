namespace formulario
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cliente")]
    public partial class Cliente
    {
        [Key]
        [StringLength(15)]
        public string IdCliente { get; set; }

        [StringLength(60)]
        public string Nombres { get; set; }

        [StringLength(60)]
        public string Apellidos { get; set; }

        [StringLength(60)]
        public string Dirección { get; set; }
    }
}
