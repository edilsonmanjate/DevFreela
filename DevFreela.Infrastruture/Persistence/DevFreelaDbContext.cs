using DevFreela.Core.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Infrastruture.Persistence
{
    public class DevFreelaDbContext
    {
        public DevFreelaDbContext()
        {
            Projects = new List<Projects>()
            {
                new Projects("Project 1", "Description 1", 1, 2,1000, DateTime.Now),
                new Projects("Project 2", "Description 2", 2, 3,2000,DateTime.Now),
                new Projects("Project 3", "Description 3", 3, 1, 3000, DateTime.Now),

            };

            Users = new List<User>()
            {
                new User("User 1", "user1@mail.com", new DateTime(1991, 10, 1)),
                new User("User 1", "user1@mail.com", new DateTime(1994, 09, 4)),
                new User("User 1", "user1@mail.com", new DateTime(2019, 06, 1))

            };

            Skills = new List<Skills>()
            {
                new Skills(".NET core"),
                new Skills("C#"),
                new Skills("SQL")
            };
        }
        public List<Projects> Projects { get; set; }
        public List<User> Users { get; set; }
        public List<Skills> Skills { get; set; }
    }
}
