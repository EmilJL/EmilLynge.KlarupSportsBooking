namespace EmilLynge.KlarupSportsBooking.DAL.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ClosedDay
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        [Required]
        [StringLength(30)]
        public string Description { get; set; }

        public int HallId { get; set; }

        public virtual Hall Hall { get; set; }
    }
}
