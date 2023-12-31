﻿// <auto-generated />
using AcortadorURL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AcortadorURL.Migrations
{
    [DbContext(typeof(UrlContext))]
    [Migration("20231031215345_Nueva db")]
    partial class Nuevadb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.9");

            modelBuilder.Entity("AcortadorURL.Entities.Url", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("LongUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ShortUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Urls");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            LongUrl = "https://google.com",
                            ShortUrl = "ad3Er5",
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            LongUrl = "https://youtube.com",
                            ShortUrl = "Lo25Te",
                            UserId = 2
                        });
                });

            modelBuilder.Entity("AcortadorURL.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "pepe@email.com",
                            Password = "pepe"
                        },
                        new
                        {
                            Id = 2,
                            Email = "joaco@email.com",
                            Password = "Joaco"
                        });
                });

            modelBuilder.Entity("AcortadorURL.Entities.Url", b =>
                {
                    b.HasOne("AcortadorURL.Entities.User", "user")
                        .WithMany("Urls")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("AcortadorURL.Entities.User", b =>
                {
                    b.Navigation("Urls");
                });
#pragma warning restore 612, 618
        }
    }
}
