namespace EmilLynge.KlarupSportsBooking.DAL.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class OpeningHour
    {
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string NameOfDay { get; set; }

        public DateTime OpeningTime { get; set; }

        public DateTime ClosingTime { get; set; }

        public int HallId { get; set; }

        public virtual Hall Hall { get; set; }
    }
}
