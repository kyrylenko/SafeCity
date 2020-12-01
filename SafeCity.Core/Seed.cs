using System;
using System.Collections.Generic;
using System.Text;
using SafeCity.Core.Entities;

namespace SafeCity.Core
{
    class Seed
    {
        public static Project[] Projects { get; } =
        {
            new Project()
            {
                Id = -1,
                Name = "Реконструкція брами",
                ShortDescription = "Doors renovation in the old building",
                LongDescription =
                    "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy",
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
                CreatedDate = DateTime.Now.AddDays(-6),
            },
            new Project()
            {
                Id = -2,
                Name = "Платан на Чорновола",
                ShortDescription = "Заміна платану на Чорновола",
                LongDescription =
                    "Думаю, ви пам'ятаєте прекрасні платани, яки ми завдяки спільнокошту посадили на проспекті Чорновола. Торік крайнє від залізничного мосту дерево хтось надломив (скоріш за все - машиною при маневруванні), ми намагалися зафіксувати його брусками, воно зрослося і так прожило ще рік, але одного з літніх буревіїв таки не витримало. Тепер там порожня лунка і на це місце проситься нове дерево.",
                AddressName = "Львів, вул. Чорновола",
                Lat = 49.857538,
                Lon = 24.026658,
                Logo = "https://i.imgur.com/3QtX0ea.jpg",
                Images = new[]
                {
                    "https://i.imgur.com/3QtX0ea.jpg",
                    "https://i.imgur.com/xrwczlk.png",
                    "https://i.imgur.com/a66KMDd.png"
                },
                RequiredAmount = 5000,
                CreatedBy = "pavlo.kyrylenko@gmail.com",
                CreatedDate = DateTime.Now.AddDays(-7),
                State = ProjectState.Completed
            },
            new Project()
            {
                Id = -3,
                Name = "Громадський простір",
                ShortDescription = "Невеликий громадський простір з озелененням",
                LongDescription =
                    "Думаю, ви пам'ятаєте прекрасні платани, яки ми завдяки спільнокошту посадили на проспекті Чорновола. Торік крайнє від залізничного мосту дерево хтось надломив (скоріш за все - машиною при маневруванні), ми намагалися зафіксувати його брусками, воно зрослося і так прожило ще рік, але одного з літніх буревіїв таки не витримало. Тепер там порожня лунка і на це місце проситься нове дерево.",
                AddressName = "Львів, вул. Чорновола",
                Lat = 49.865538,
                Lon = 24.013658,
                Logo = "https://s.pb.org.ua/lviv.pb.org.ua/project/5346/photos/15369646275328_0001-06ddf978b983f9b066acf1d0ea440cfd.jpg?s=9aa4d9417b53ba49793a7c42396ce54e",
                Images = new[]
                {
                    "https://rubryka.com/wp-content/uploads/2018/08/MEDIACITY-Gillespies-Landscape-architecture-02-840x480-c-1.jpg",
                    "https://inspired.com.ua/wp-content/uploads/2015/07/parklet-3.jpg",
                },
                RequiredAmount = 8500,
                CreatedBy = "pavlo.kyrylenko@gmail.com",
                CreatedDate = DateTime.Now.AddDays(-13),
                State = ProjectState.FundRaising
            }
        };

        public static Donation[] Donations { get; } =
        {
            new Donation()
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
            }
        };

        public static User[] Users { get; } =
        {
            new User()
            {
                Id = Guid.NewGuid(),
                Email = "kirilenko.pavlo@gmail.com",
                FamilyName = "Pavlo",
                GivenName = "Kyrylenko",
                Picture = "https://lh3.googleusercontent.com/a-/AOh14GhhOenSg9NkV2y8V170GpLKP-8Hzn5wncPxGqvkkg=s96-c",
                Role = Role.Admin
            }
        };
    }
}
