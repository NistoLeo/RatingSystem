using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using RatingSystem.Models;

#nullable disable

namespace RatingSystem.Data
{
    public partial class AfterhillsContext : DbContext
    {
        

        public AfterhillsContext(DbContextOptions<AfterhillsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Conference> Conferences { get; set; }
        public virtual DbSet<ConferenceXattendee> ConferenceXattendees { get; set; }
        public virtual DbSet<ConferenceXspeaker> ConferenceXspeakers { get; set; }
        public virtual DbSet<DictionaryCategory> DictionaryCategories { get; set; }
        public virtual DbSet<DictionaryCity> DictionaryCities { get; set; }
        public virtual DbSet<DictionaryConferenceType> DictionaryConferenceTypes { get; set; }
        public virtual DbSet<DictionaryCountry> DictionaryCountries { get; set; }
        public virtual DbSet<DictionaryCounty> DictionaryCounties { get; set; }
        public virtual DbSet<DictionaryStatus> DictionaryStatuses { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<Speaker> Speakers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Conference>(entity =>
            {
                entity.ToTable("Conference");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.OrganizerEmail)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Conferences)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Conference_DictionaryCategory");

                entity.HasOne(d => d.ConferenceType)
                    .WithMany(p => p.Conferences)
                    .HasForeignKey(d => d.ConferenceTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Conference_DictionaryConferenceType");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Conferences)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Conference_Location");
            });

            modelBuilder.Entity<ConferenceXattendee>(entity =>
            {
                entity.ToTable("ConferenceXAttendee");

                entity.Property(e => e.AttendeeEmail)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Conference)
                    .WithMany(p => p.ConferenceXattendees)
                    .HasForeignKey(d => d.ConferenceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ConferenceXAttendee_Conference");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.ConferenceXattendees)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ConferenceXAttendee_DictionaryStatus");
            });

            modelBuilder.Entity<ConferenceXspeaker>(entity =>
            {
                entity.ToTable("ConferenceXSpeaker");

                entity.HasOne(d => d.Conference)
                    .WithMany(p => p.ConferenceXspeakers)
                    .HasForeignKey(d => d.ConferenceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ConferenceXSpeaker_Conference");

                entity.HasOne(d => d.Speaker)
                    .WithMany(p => p.ConferenceXspeakers)
                    .HasForeignKey(d => d.SpeakerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ConferenceXSpeaker_Speaker");
            });

            modelBuilder.Entity<DictionaryCategory>(entity =>
            {
                entity.ToTable("DictionaryCategory");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<DictionaryCity>(entity =>
            {
                entity.ToTable("DictionaryCity");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<DictionaryConferenceType>(entity =>
            {
                entity.ToTable("DictionaryConferenceType");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<DictionaryCountry>(entity =>
            {
                entity.ToTable("DictionaryCountry");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<DictionaryCounty>(entity =>
            {
                entity.ToTable("DictionaryCounty");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<DictionaryStatus>(entity =>
            {
                entity.ToTable("DictionaryStatus");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("Location");

                entity.Property(e => e.Address).HasMaxLength(255);

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.Latitude).HasColumnType("decimal(12, 9)");

                entity.Property(e => e.Longitude).HasColumnType("decimal(12, 9)");

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Locations)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Location_DictionaryCity");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Locations)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Location_DictionaryCountry");

                entity.HasOne(d => d.County)
                    .WithMany(p => p.Locations)
                    .HasForeignKey(d => d.CountyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Location_DictionaryCounty");
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.ToTable("__Logs");

                entity.Property(e => e.Level).HasMaxLength(128);

                entity.Property(e => e.TimeStamp).HasColumnType("datetime");
            });

            modelBuilder.Entity<Speaker>(entity =>
            {
                entity.ToTable("Speaker");

                entity.Property(e => e.Image).HasColumnType("image");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Nationality).HasMaxLength(50);

                entity.Property(e => e.Rating).HasColumnType("decimal(5, 2)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
