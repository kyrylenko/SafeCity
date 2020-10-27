using System;
using Microsoft.EntityFrameworkCore;
using SafeCity.Core.Entities;

namespace SafeCity.Core
{
    public class SafeCityContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<Donation> Donations { get; set; }

        public SafeCityContext(DbContextOptions<SafeCityContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>()
                .HasData(new Project()
                {
                    Id = -1,
                    Name = "Doors renovation",
                    ShortDescription = "Doors renovation in the old building",
                    LongDescription = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy",
                    AddressName = "Lviv, Kopernyka",
                    Lat = 49.836319,
                    Lon = 24.023026,
                    Logo = "https://city-adm.lviv.ua/img/843x500/7/-40d71b48.jpg",
                    Images = new[]
                    {
                        "https://lviv.depo.ua/uploads/posts/20190424/754x/nQBX5BSgx0VcY49gVyZyBQz8p7SuwCZlyL2yGusa.jpeg",
                        "https://img.depo.ua/745xX/Dec2018/466290.jpg"
                    },
                    RequiredAmount = 1200,
                    CreatedBy = "chuck.norris@gmail.com",
                    CreatedDate = DateTime.Now.AddDays(-2),
                }, new Project()
                {
                    Id = -2,
                    Name = "Платан на Чорновола",
                    ShortDescription = "Заміна платану на чочноаола",
                    LongDescription = "Думаю, ви пам'ятаєте прекрасні платани, яки ми завдяки спільнокошту посадили на проспекті Чорновола. Торік крайнє від залізничного мосту дерево хтось надломив (скоріш за все - машиною при маневруванні), ми намагалися зафіксувати його брусками, воно зрослося і так прожило ще рік, але одного з літніх буревіїв таки не витримало. Тепер там порожня лунка і на це місце проситься нове дерево.",
                    AddressName = "Lviv, Zamarstynivska 79",
                    Lat = 49.857538,
                    Lon = 24.026658,
                    Logo = "https://i.imgur.com/3QtX0ea.jpg",
                    Images = new[]{
                        "https://i.imgur.com/3QtX0ea.jpg",
                        "https://i.imgur.com/xrwczlk.png",
                        "https://i.imgur.com/a66KMDd.png"},
                    RequiredAmount = 5000,
                    CreatedBy = "pavlo.kyrylenko@gmail.com",
                    CreatedDate = DateTime.Now.AddDays(-2),
                    State = ProjectState.FundRaising
                });

            modelBuilder.Entity<Donation>()
                .HasData(new Donation()
                {
                    Id = "637393849118004257-kirilenko.pavlo@gmail.com--2",
                    Description = "Project: Платан на Чорновола",
                    Amount = 200,
                    Currency = Currency.Uah,
                    DateTime = DateTime.Now,
                    Email = "kirilenko.pavlo@gmail.com",
                    ProjectId = -2,
                    Status = "success",
                    TransactionId = "1460920565",
                    Action = PaymentAction.Pay,
                    Ip = "92.253.252.0"
                }, new Donation()
                {
                    Id = "637393849118001254-emma.kyrylenko@gmail.com--2",
                    Description = "Project: Платан на Чорновола",
                    Amount = 140,
                    Currency = Currency.Uah,
                    DateTime = DateTime.Now.AddDays(-1),
                    Email = "emma.kyrylenko@gmail.com",
                    ProjectId = -2,
                    Status = "success",
                    TransactionId = "1460908734",
                    Action = PaymentAction.Pay,
                    Ip = "92.253.252.0"
                });

            modelBuilder.Entity<Project>()
                .Property(e => e.Images)
                .HasConversion(
                    v => string.Join(',', v),
                    v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));

            modelBuilder.Entity<Project>()
                .Property(e => e.Attachments)
                .HasConversion(
                    v => string.Join(',', v),
                    v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));

            base.OnModelCreating(modelBuilder);
        }
    }
}
