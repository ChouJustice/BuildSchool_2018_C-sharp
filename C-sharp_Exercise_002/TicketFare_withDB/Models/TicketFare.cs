namespace TicketFare.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TicketFare")]
    public partial class TicketFare
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string StartStation { get; set; }

        [Required]
        [StringLength(50)]
        public string EndStation { get; set; }

        public decimal TicketPrice { get; set; }
    }
}
