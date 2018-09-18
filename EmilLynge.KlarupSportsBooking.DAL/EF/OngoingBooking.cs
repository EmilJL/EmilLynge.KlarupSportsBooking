namespace EmilLynge.KlarupSportsBooking.DAL.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class OngoingBooking
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OngoingBooking()
        {
            ConfirmedOngoingBookings = new HashSet<ConfirmedOngoingBooking>();
        }

        public int Id { get; set; }

        public int DayOfWeek { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public DateTime StartDay { get; set; }

        public DateTime EndDay { get; set; }

        public bool IsConfirmed { get; set; }

        public int ActivityId { get; set; }

        public int CompanyId { get; set; }

        public virtual Activity Activity { get; set; }

        public virtual Company Company { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ConfirmedOngoingBooking> ConfirmedOngoingBookings { get; set; }
    }
}
