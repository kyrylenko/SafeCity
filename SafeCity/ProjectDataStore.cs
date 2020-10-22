using System.Collections.Generic;
using SafeCity.Core.Entities;
using SafeCity.DTOs;

namespace SafeCity
{
    public class ProjectDataStore
    {
        public static ProjectDataStore Current { get; } = new ProjectDataStore();
        public List<ProjectDto> Projects { get; set; }

        public ProjectDataStore()
        {
            Projects = new List<ProjectDto>()
            {
                new ProjectDto()
                {
                    Id = 1,
                    Name = "Bench in the yard",
                    ShortDescription = "My first project",
                    LongDescription = "Set up the bench in the yard of the novobudova",
                    AddressName = "Lviv, Zamarstynivska 79",
                    Lat = 49.857538,
                    Lon = 24.026658,
                    Logo = "https://tvoemisto.tv/media/gallery/full/p/i/pidzamche_9_doors_ready.jpg",
                    Images = new [] {"https://tvoemisto.tv/media/gallery/full/p/i/pidzamche_9_doors_ready.jpg"},
                    RequiredAmount = 5000,
                    Raised = 3195,
                    State = ProjectState.FundRaising,
                },
                new ProjectDto()
                {
                    Id = 2,
                    Name = "Платан на Чорновола",
                    ShortDescription = "Заміна платану на чочноаола",
                    LongDescription = "Думаю, ви пам'ятаєте прекрасні платани, яки ми завдяки спільнокошту посадили на проспекті Чорновола. Торік крайнє від залізничного мосту дерево хтось надломив (скоріш за все - машиною при маневруванні), ми намагалися зафіксувати його брусками, воно зрослося і так прожило ще рік, але одного з літніх буревіїв таки не витримало. Тепер там порожня лунка і на це місце проситься нове дерево.",
                    AddressName = "Lviv, Zamarstynivska 79",
                    Lat = 49.857538,
                    Lon = 24.026658,
                    Logo = "https://i.imgur.com/3QtX0ea.jpg",
                    Images = new []{ "https://i.imgur.com/3QtX0ea.jpg", "https://i.imgur.com/xrwczlk.png", "https://i.imgur.com/a66KMDd.png"},
                    RequiredAmount = 5000,
                    Raised = 8313,
                    State = ProjectState.InProgress,
                },
                new ProjectDto()
                {
                    Id = 3,
                    Name = "Fix bicycle path",
                    ShortDescription = "My second project",
                    LongDescription = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy",
                    AddressName = "Lviv, Kopernyka",
                    Lat = 49.836319,
                    Lon = 24.023026,
                    Logo = "https://upload.wikimedia.org/wikipedia/commons/thumb/f/f2/Nikolaus_Kopernikus.jpg/230px-Nikolaus_Kopernikus.jpg",
                    Images = new [] {"https://upload.wikimedia.org/wikipedia/commons/thumb/f/f2/Nikolaus_Kopernikus.jpg/230px-Nikolaus_Kopernikus.jpg"},
                    RequiredAmount = 1200,
                    Raised = 256,
                    State = ProjectState.FundRaising
                },
                new ProjectDto()
                {
                    Id = 4,
                    Name = "Project three",
                    ShortDescription = "My third project",
                    LongDescription = "",
                    AddressName = "Bibirka, center",
                    Lat = 49.636147,
                    Lon = 24.294717,
                    Logo = "https://lh5.googleusercontent.com/p/AF1QipNELtQI1o4I6_s5xkthSCpcj4NGjpo2lJHUCft7=w408-h306-k-no",
                    Images = new [] {"https://lh5.googleusercontent.com/p/AF1QipNELtQI1o4I6_s5xkthSCpcj4NGjpo2lJHUCft7=w408-h306-k-no"},
                    RequiredAmount = 400,
                    Raised = 0,
                    State = ProjectState.Suggested,
                },
            };
        }
    }
}
