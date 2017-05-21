using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CineplexWebsite.Migrations
{
    public partial class NameOfMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cineplex",
                columns: table => new
                {
                    CineplexID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ImageUrl = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: false),
                    LongDescription = table.Column<string>(nullable: false),
                    ShortDescription = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cineplex", x => x.CineplexID);
                });

            migrationBuilder.CreateTable(
                name: "Enquiry",
                columns: table => new
                {
                    EnquiryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: false),
                    Message = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enquiry", x => x.EnquiryID);
                });

            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    MovieID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ImageUrl = table.Column<string>(nullable: true),
                    LongDescription = table.Column<string>(nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    ShortDescription = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.MovieID);
                });

            migrationBuilder.CreateTable(
                name: "MovieComingSoon",
                columns: table => new
                {
                    MovieComingSoonID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ImageUrl = table.Column<string>(nullable: true),
                    LongDescription = table.Column<string>(nullable: false),
                    ShortDescription = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieComingSoon", x => x.MovieComingSoonID);
                });

            migrationBuilder.CreateTable(
                name: "CineplexMovie",
                columns: table => new
                {
                    CineplexID = table.Column<int>(nullable: false),
                    MovieID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Cineplex__CB419E6D5670BC38", x => new { x.CineplexID, x.MovieID });
                    table.ForeignKey(
                        name: "FK__CineplexM__Cinep__2B3F6F97",
                        column: x => x.CineplexID,
                        principalTable: "Cineplex",
                        principalColumn: "CineplexID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__CineplexM__Movie__2C3393D0",
                        column: x => x.MovieID,
                        principalTable: "Movie",
                        principalColumn: "MovieID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MovieSession",
                columns: table => new
                {
                    MovieSessionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CineplexID = table.Column<int>(nullable: false),
                    MovieID = table.Column<int>(nullable: false),
                    SessionTime = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieSession", x => x.MovieSessionID);
                    table.ForeignKey(
                        name: "FK__MovieSess__Cinep__5165187F",
                        column: x => x.CineplexID,
                        principalTable: "Cineplex",
                        principalColumn: "CineplexID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__MovieSess__Movie__52593CB8",
                        column: x => x.MovieID,
                        principalTable: "Movie",
                        principalColumn: "MovieID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CineplexMovie_CineplexID",
                table: "CineplexMovie",
                column: "CineplexID");

            migrationBuilder.CreateIndex(
                name: "IX_CineplexMovie_MovieID",
                table: "CineplexMovie",
                column: "MovieID");

            migrationBuilder.CreateIndex(
                name: "IX_MovieSession_CineplexID",
                table: "MovieSession",
                column: "CineplexID");

            migrationBuilder.CreateIndex(
                name: "IX_MovieSession_MovieID",
                table: "MovieSession",
                column: "MovieID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CineplexMovie");

            migrationBuilder.DropTable(
                name: "Enquiry");

            migrationBuilder.DropTable(
                name: "MovieComingSoon");

            migrationBuilder.DropTable(
                name: "MovieSession");

            migrationBuilder.DropTable(
                name: "Cineplex");

            migrationBuilder.DropTable(
                name: "Movie");
        }
    }
}
