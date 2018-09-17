namespace EmilLynge.KlarupSportsBooking.DAL.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ConfirmedSingleBooking
    {
        public int Id { get; set; }

        public DateTime ConfirmDate { get; set; }

        public int AdminId { get; set; }

        public int SingleBookingId { get; set; }

        public virtual Admin Admin { get; set; }

        public virtual SingleBooking SingleBooking { get; set; }
    }
}
