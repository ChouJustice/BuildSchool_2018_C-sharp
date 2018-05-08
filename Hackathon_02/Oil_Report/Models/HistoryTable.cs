namespace Oil_Report.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HistoryTable")]
    public partial class HistoryTable
    {
        public int Id { get; set; }

        public DateTime RefudlingDate { get; set; }

        public double Liter { get; set; }

        public double Kilometer { get; set; }
    }
}
