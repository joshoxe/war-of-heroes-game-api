// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WarOfHeroesGameAPI.Data;

namespace WarOfHeroesGameAPI.Migrations
{
    [DbContext(typeof(HeroContext))]
    [Migration("20210819135635_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WarOfHeroesGameAPI.Data.Entities.Ability", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Ability");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amount = 5,
                            Type = "Attack"
                        },
                        new
                        {
                            Id = 2,
                            Amount = 15,
                            Type = "Attack"
                        },
                        new
                        {
                            Id = 3,
                            Amount = 2,
                            Type = "Attack"
                        },
                        new
                        {
                            Id = 4,
                            Amount = 30,
                            Type = "Attack"
                        },
                        new
                        {
                            Id = 5,
                            Amount = 30,
                            Type = "Attack"
                        },
                        new
                        {
                            Id = 6,
                            Amount = 30,
                            Type = "Attack"
                        },
                        new
                        {
                            Id = 7,
                            Amount = 30,
                            Type = "Attack"
                        });
                });

            modelBuilder.Entity("WarOfHeroesGameAPI.Data.Entities.Hero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AbilityId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AbilityId");

                    b.ToTable("Heroes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AbilityId = 1,
                            Description = "A basic hero with a basic description.",
                            Name = "Taron"
                        },
                        new
                        {
                            Id = 2,
                            AbilityId = 2,
                            Description = "A basic hero with a basic description.",
                            Name = "Groth Nightmore"
                        },
                        new
                        {
                            Id = 3,
                            AbilityId = 3,
                            Description = "A basic hero with a basic description.",
                            Name = "Sin Deruv"
                        },
                        new
                        {
                            Id = 4,
                            AbilityId = 4,
                            Description = "A basic hero with a basic description.",
                            Name = "Tegril"
                        },
                        new
                        {
                            Id = 5,
                            AbilityId = 1,
                            Description = "A basic hero with a basic description.",
                            Name = "Warsa"
                        },
                        new
                        {
                            Id = 6,
                            AbilityId = 1,
                            Description = "A basic hero with a basic description.",
                            Name = "Edam"
                        },
                        new
                        {
                            Id = 7,
                            AbilityId = 1,
                            Description = "A basic hero with a basic description.",
                            Name = "esf"
                        });
                });

            modelBuilder.Entity("WarOfHeroesGameAPI.Data.Entities.Hero", b =>
                {
                    b.HasOne("WarOfHeroesGameAPI.Data.Entities.Ability", "Ability")
                        .WithMany()
                        .HasForeignKey("AbilityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ability");
                });
#pragma warning restore 612, 618
        }
    }
}
