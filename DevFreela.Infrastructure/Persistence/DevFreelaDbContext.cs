using DevFreela.Core.Entities;

namespace DevFreela.Infrastructure.Persistence
{
    public class DevFreelaDbContext
    {
        public DevFreelaDbContext()
        {
            Projects = new List<Project>
            {
                new Project("Projeto .NET Core", "API NET", 1, 1, 1000),
                new Project("Projeto Node JS", "API NODE", 1, 1, 2000),
                new Project("Projeto Python", " API PYTHON", 1, 1, 3000),
            };

            Users = new List<User>
            {
                new User("Joao Gomes", "joao.gomes@email.com", new DateTime(1985, 5, 15)),
                new User("Roberto Augusto", "roberto.augusto@email.com", new DateTime(1982, 1, 22)),
                new User("Neymar Jr", "neymar.jr@email.com", new DateTime(1995, 8, 12))
            };

            Skills = new List<Skill>
            {
                new Skill(".NET Core"),
                new Skill("C#"),
                new Skill("JavaScript"),
                new Skill("TypeScript")
            };
        }

        public List<Project> Projects { get; set; }
        public List<ProjectComment> ProjectComments { get; set; }
        public List<User> Users { get; set; }
        public List<Skill> Skills { get; set; }
    }
}
