﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WarOfHeroesGameAPI.Data;

namespace WarOfHeroesGameAPI.Migrations
{
    [DbContext(typeof(HeroContext))]
    partial class HeroContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WarOfHeroesGameAPI.Data.Entities.Hero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AttackDamage")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UltimateAttackDamage")
                        .HasColumnType("int");

                    b.Property<string>("UltimateAttackName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Heroes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AttackDamage = 3,
                            Description = "A basic hero with a basic description. His friendly manner will lure enemies into a false sense of security, stopping their attacks",
                            Name = "Taron",
                            UltimateAttackDamage = 15,
                            UltimateAttackName = "Hammer Smash"
                        },
                        new
                        {
                            Id = 2,
                            AttackDamage = 5,
                            Description = "A basic hero with a basic description.",
                            Name = "Groth Nightmore",
                            UltimateAttackDamage = 10,
                            UltimateAttackName = "Headbutt"
                        },
                        new
                        {
                            Id = 3,
                            AttackDamage = 3,
                            Description = "A basic hero with a basic description.",
                            Name = "Sin Deruv",
                            UltimateAttackDamage = 25,
                            UltimateAttackName = "Back Stab"
                        },
                        new
                        {
                            Id = 4,
                            AttackDamage = 7,
                            Description = "A basic hero with a basic description.",
                            Name = "Tegril",
                            UltimateAttackDamage = 30,
                            UltimateAttackName = "Lightning Strike"
                        },
                        new
                        {
                            Id = 5,
                            AttackDamage = 10,
                            Description = "A basic hero with a basic description.",
                            Name = "Warsa",
                            UltimateAttackDamage = 40,
                            UltimateAttackName = "War Cry"
                        },
                        new
                        {
                            Id = 6,
                            AttackDamage = 5,
                            Description = "A basic hero with a basic description.",
                            Name = "Edam",
                            UltimateAttackDamage = 18,
                            UltimateAttackName = "Poison Strike"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
