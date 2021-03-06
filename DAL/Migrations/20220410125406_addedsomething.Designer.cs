// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SoproWA.Entities;

namespace SoproWA.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20220410125406_addedsomething")]
    partial class addedsomething
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("GenreMovie", b =>
                {
                    b.Property<int>("Genresid")
                        .HasColumnType("int");

                    b.Property<int>("Moviesid")
                        .HasColumnType("int");

                    b.HasKey("Genresid", "Moviesid");

                    b.HasIndex("Moviesid");

                    b.ToTable("GenreMovie");
                });

            modelBuilder.Entity("MoviePerson", b =>
                {
                    b.Property<int>("Moviesid")
                        .HasColumnType("int");

                    b.Property<int>("Peopleid")
                        .HasColumnType("int");

                    b.HasKey("Moviesid", "Peopleid");

                    b.HasIndex("Peopleid");

                    b.ToTable("MoviePerson");
                });

            modelBuilder.Entity("SoproWA.Entities.Genre", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("SoproWA.Entities.Movie", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImgUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("SoproWA.Entities.Person", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonRole")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("GenreMovie", b =>
                {
                    b.HasOne("SoproWA.Entities.Genre", null)
                        .WithMany()
                        .HasForeignKey("Genresid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SoproWA.Entities.Movie", null)
                        .WithMany()
                        .HasForeignKey("Moviesid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MoviePerson", b =>
                {
                    b.HasOne("SoproWA.Entities.Movie", null)
                        .WithMany()
                        .HasForeignKey("Moviesid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SoproWA.Entities.Person", null)
                        .WithMany()
                        .HasForeignKey("Peopleid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
