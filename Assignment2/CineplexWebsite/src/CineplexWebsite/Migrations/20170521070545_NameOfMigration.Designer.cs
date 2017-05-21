using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CineplexWebsite.Models;

namespace CineplexWebsite.Migrations
{
    [DbContext(typeof(CineplexContext))]
    [Migration("20170521070545_NameOfMigration")]
    partial class NameOfMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CineplexWebsite.Models.Cineplex", b =>
                {
                    b.Property<int>("CineplexId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CineplexID");

                    b.Property<string>("ImageUrl");

                    b.Property<string>("Location")
                        .IsRequired();

                    b.Property<string>("LongDescription")
                        .IsRequired();

                    b.Property<string>("ShortDescription")
                        .IsRequired();

                    b.HasKey("CineplexId");

                    b.ToTable("Cineplex");
                });

            modelBuilder.Entity("CineplexWebsite.Models.CineplexMovie", b =>
                {
                    b.Property<int>("CineplexId")
                        .HasColumnName("CineplexID");

                    b.Property<int>("MovieId")
                        .HasColumnName("MovieID");

                    b.HasKey("CineplexId", "MovieId")
                        .HasName("PK__Cineplex__CB419E6D5670BC38");

                    b.HasIndex("CineplexId");

                    b.HasIndex("MovieId");

                    b.ToTable("CineplexMovie");
                });

            modelBuilder.Entity("CineplexWebsite.Models.Enquiry", b =>
                {
                    b.Property<int>("EnquiryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("EnquiryID");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Message")
                        .IsRequired();

                    b.HasKey("EnquiryId");

                    b.ToTable("Enquiry");
                });

            modelBuilder.Entity("CineplexWebsite.Models.Movie", b =>
                {
                    b.Property<int>("MovieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("MovieID");

                    b.Property<string>("ImageUrl");

                    b.Property<string>("LongDescription")
                        .IsRequired();

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.Property<string>("ShortDescription")
                        .IsRequired();

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("MovieId");

                    b.ToTable("Movie");
                });

            modelBuilder.Entity("CineplexWebsite.Models.MovieComingSoon", b =>
                {
                    b.Property<int>("MovieComingSoonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("MovieComingSoonID");

                    b.Property<string>("ImageUrl");

                    b.Property<string>("LongDescription")
                        .IsRequired();

                    b.Property<string>("ShortDescription")
                        .IsRequired();

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("MovieComingSoonId");

                    b.ToTable("MovieComingSoon");
                });

            modelBuilder.Entity("CineplexWebsite.Models.MovieSession", b =>
                {
                    b.Property<int>("MovieSessionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("MovieSessionID");

                    b.Property<int>("CineplexId")
                        .HasColumnName("CineplexID");

                    b.Property<int>("MovieId")
                        .HasColumnName("MovieID");

                    b.Property<DateTime>("SessionTime")
                        .HasColumnType("datetime");

                    b.HasKey("MovieSessionId");

                    b.HasIndex("CineplexId");

                    b.HasIndex("MovieId");

                    b.ToTable("MovieSession");
                });

            modelBuilder.Entity("CineplexWebsite.Models.CineplexMovie", b =>
                {
                    b.HasOne("CineplexWebsite.Models.Cineplex", "Cineplex")
                        .WithMany("CineplexMovie")
                        .HasForeignKey("CineplexId")
                        .HasConstraintName("FK__CineplexM__Cinep__2B3F6F97");

                    b.HasOne("CineplexWebsite.Models.Movie", "Movie")
                        .WithMany("CineplexMovie")
                        .HasForeignKey("MovieId")
                        .HasConstraintName("FK__CineplexM__Movie__2C3393D0");
                });

            modelBuilder.Entity("CineplexWebsite.Models.MovieSession", b =>
                {
                    b.HasOne("CineplexWebsite.Models.Cineplex", "Cineplex")
                        .WithMany("MovieSession")
                        .HasForeignKey("CineplexId")
                        .HasConstraintName("FK__MovieSess__Cinep__5165187F");

                    b.HasOne("CineplexWebsite.Models.Movie", "Movie")
                        .WithMany("MovieSession")
                        .HasForeignKey("MovieId")
                        .HasConstraintName("FK__MovieSess__Movie__52593CB8");
                });
        }
    }
}
