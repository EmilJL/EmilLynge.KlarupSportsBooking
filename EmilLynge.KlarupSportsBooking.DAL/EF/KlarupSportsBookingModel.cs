namespace EmilLynge.KlarupSportsBooking.DAL.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class KlarupSportsBookingModel : DbContext
    {
        public KlarupSportsBookingModel()
            : base("name=KlarupSportsBookingConString")
        {
        }

        public virtual DbSet<Activity> Activities { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<ClosedDay> ClosedDays { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<CompanyLeader> CompanyLeaders { get; set; }
        public virtual DbSet<ConfirmedOngoingBooking> ConfirmedOngoingBookings { get; set; }
        public virtual DbSet<ConfirmedSingleBooking> ConfirmedSingleBookings { get; set; }
        public virtual DbSet<Hall> Halls { get; set; }
        public virtual DbSet<OngoingBooking> OngoingBookings { get; set; }
        public virtual DbSet<OpeningHour> OpeningHours { get; set; }
        public virtual DbSet<Section> Sections { get; set; }
        public virtual DbSet<SingleBooking> SingleBookings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Activity>()
                .HasMany(e => e.OngoingBookings)
                .WithRequired(e => e.Activity)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Activity>()
                .HasMany(e => e.SingleBookings)
                .WithRequired(e => e.Activity)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Admin>()
                .HasMany(e => e.ConfirmedOngoingBookings)
                .WithRequired(e => e.Admin)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Admin>()
                .HasMany(e => e.ConfirmedSingleBookings)
                .WithRequired(e => e.Admin)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Company>()
                .HasMany(e => e.CompanyLeaders)
                .WithRequired(e => e.Company)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Company>()
                .HasMany(e => e.OngoingBookings)
                .WithRequired(e => e.Company)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Company>()
                .HasMany(e => e.SingleBookings)
                .WithRequired(e => e.Company)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Hall>()
                .HasMany(e => e.Admins)
                .WithRequired(e => e.Hall)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Hall>()
                .HasMany(e => e.ClosedDays)
                .WithRequired(e => e.Hall)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Hall>()
                .HasMany(e => e.OpeningHours)
                .WithRequired(e => e.Hall)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Hall>()
                .HasMany(e => e.Sections)
                .WithRequired(e => e.Hall)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OngoingBooking>()
                .HasMany(e => e.ConfirmedOngoingBookings)
                .WithRequired(e => e.OngoingBooking)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OpeningHour>()
                .Property(e => e.NameOfDay)
                .IsFixedLength();

            modelBuilder.Entity<SingleBooking>()
                .HasMany(e => e.ConfirmedSingleBookings)
                .WithRequired(e => e.SingleBooking)
                .WillCascadeOnDelete(false);
        }
    }
}
