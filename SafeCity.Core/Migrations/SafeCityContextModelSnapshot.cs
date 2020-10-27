﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SafeCity.Core;

namespace SafeCity.Core.Migrations
{
    [DbContext(typeof(SafeCityContext))]
    partial class SafeCityContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("SafeCity.Core.Entities.Donation", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("Action")
                        .HasColumnType("integer");

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric");

                    b.Property<int>("Currency")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Ip")
                        .HasColumnType("text");

                    b.Property<int>("ProjectId")
                        .HasColumnType("integer");

                    b.Property<decimal>("ReceiverCommission")
                        .HasColumnType("numeric");

                    b.Property<string>("Source")
                        .HasColumnType("text");

                    b.Property<string>("Status")
                        .HasColumnType("text");

                    b.Property<string>("TransactionId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("Donations");

                    b.HasData(
                        new
                        {
                            Id = "637393849118004257-kirilenko.pavlo@gmail.com--2",
                            Action = 1,
                            Amount = 200m,
                            Currency = 980,
                            DateTime = new DateTime(2020, 10, 27, 14, 9, 9, 852, DateTimeKind.Local).AddTicks(520),
                            Description = "Project: Платан на Чорновола",
                            Email = "kirilenko.pavlo@gmail.com",
                            Ip = "92.253.252.0",
                            ProjectId = -2,
                            ReceiverCommission = 0m,
                            Source = "liqpay",
                            Status = "success",
                            TransactionId = "1460920565"
                        },
                        new
                        {
                            Id = "637393849118001254-emma.kyrylenko@gmail.com--2",
                            Action = 1,
                            Amount = 140m,
                            Currency = 980,
                            DateTime = new DateTime(2020, 10, 26, 14, 9, 9, 852, DateTimeKind.Local).AddTicks(3172),
                            Description = "Project: Платан на Чорновола",
                            Email = "emma.kyrylenko@gmail.com",
                            Ip = "92.253.252.0",
                            ProjectId = -2,
                            ReceiverCommission = 0m,
                            Source = "liqpay",
                            Status = "success",
                            TransactionId = "1460908734"
                        });
                });

            modelBuilder.Entity("SafeCity.Core.Entities.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("AddressName")
                        .HasColumnType("character varying(1024)")
                        .HasMaxLength(1024);

                    b.Property<string>("Attachments")
                        .HasColumnType("text");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Images")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<double>("Lat")
                        .HasColumnType("double precision");

                    b.Property<string>("Logo")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<double>("Lon")
                        .HasColumnType("double precision");

                    b.Property<string>("LongDescription")
                        .HasColumnType("character varying(8192)")
                        .HasMaxLength(8192);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying(64)")
                        .HasMaxLength(64);

                    b.Property<decimal>("RequiredAmount")
                        .HasColumnType("numeric");

                    b.Property<string>("ShortDescription")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<int>("State")
                        .HasColumnType("integer");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("Projects");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            AddressName = "Lviv, Kopernyka",
                            Attachments = "",
                            CreatedBy = "chuck.norris@gmail.com",
                            CreatedDate = new DateTime(2020, 10, 25, 14, 9, 9, 848, DateTimeKind.Local).AddTicks(6693),
                            Images = "https://lviv.depo.ua/uploads/posts/20190424/754x/nQBX5BSgx0VcY49gVyZyBQz8p7SuwCZlyL2yGusa.jpeg,https://img.depo.ua/745xX/Dec2018/466290.jpg",
                            IsDeleted = false,
                            Lat = 49.836319000000003,
                            Logo = "https://city-adm.lviv.ua/img/843x500/7/-40d71b48.jpg",
                            Lon = 24.023026000000002,
                            LongDescription = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy",
                            Name = "Doors renovation",
                            RequiredAmount = 1200m,
                            ShortDescription = "Doors renovation in the old building",
                            State = 0
                        },
                        new
                        {
                            Id = -2,
                            AddressName = "Lviv, Zamarstynivska 79",
                            Attachments = "",
                            CreatedBy = "pavlo.kyrylenko@gmail.com",
                            CreatedDate = new DateTime(2020, 10, 25, 14, 9, 9, 850, DateTimeKind.Local).AddTicks(7542),
                            Images = "https://i.imgur.com/3QtX0ea.jpg,https://i.imgur.com/xrwczlk.png,https://i.imgur.com/a66KMDd.png",
                            IsDeleted = false,
                            Lat = 49.857537999999998,
                            Logo = "https://i.imgur.com/3QtX0ea.jpg",
                            Lon = 24.026658000000001,
                            LongDescription = "Думаю, ви пам'ятаєте прекрасні платани, яки ми завдяки спільнокошту посадили на проспекті Чорновола. Торік крайнє від залізничного мосту дерево хтось надломив (скоріш за все - машиною при маневруванні), ми намагалися зафіксувати його брусками, воно зрослося і так прожило ще рік, але одного з літніх буревіїв таки не витримало. Тепер там порожня лунка і на це місце проситься нове дерево.",
                            Name = "Платан на Чорновола",
                            RequiredAmount = 5000m,
                            ShortDescription = "Заміна платану на чочноаола",
                            State = 1
                        });
                });

            modelBuilder.Entity("SafeCity.Core.Entities.Donation", b =>
                {
                    b.HasOne("SafeCity.Core.Entities.Project", "Project")
                        .WithMany("Donations")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
