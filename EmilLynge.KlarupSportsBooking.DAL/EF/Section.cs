namespace EmilLynge.KlarupSportsBooking.DAL.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Section
    {
        public int Id { get; set; }

        public int SectionNumber { get; set; }

        public int HallId { get; set; }

        public virtual Hall Hall { get; set; }
    }
}
