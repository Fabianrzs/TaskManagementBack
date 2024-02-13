using Domain.Entities;
using Domain.Exceptions;
using Infrastruture.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace Infrastruture.Seeders
{
    public class Start
    {
        private AppDbContext _context { get; set; }
        public Start(DbContext context)
        {
            _context = (AppDbContext)context;
        }

        public async Task Seed()
        {
            try
            {
                if (!_context.Users.Any()) await SeedUsers();
                if (!_context.Projects.Any()) await SeedProyects();
                if (!_context.Tasks.Any()) await SeedTasks();
            }
            catch (AppException e)
            {
                throw;
            }
        }

        private async Task SeedUsers()
        {
            var users = new List<User>
            {
                new User
                {
                    Name = "Fabian",
                    UserName = "Fabianrz",
                    Password = "10033315428",
                    Role = "User",
                },
                new User
                {
                    Name = "Eduardo",
                    UserName = "rrEdu",
                    Password = "10334283015",
                    Role = "User",
                }
            };

            foreach(var i in Enumerable.Range(1, 10))
            {
                _context.Add(
                    new User {
                    Name = $"User {i}",
                    UserName = $"Alsas1{i}",
                    Password = "10333150428",
                    Role = "User",
                });
            }

            await _context.AddRangeAsync(users);
            await _context.SaveChangesAsync();
        }

        private async Task SeedProyects()
        {
            var users = await _context.Users.ToListAsync();
            var projects = new List<Project>();

            var random = new Random();

            foreach (var i in Enumerable.Range(1, 10))
            {
                var project = new Project
                {
                    Name = $"Project {i}",
                    Descriptions = $"Descripción del Project {i}",
                    Start = DateTime.Now,
                    End = DateTime.Now,
                    IdUser = users[random.Next(users.Count)].Id
                };
                projects.Add(project);
            }

            await _context.AddRangeAsync(projects);
            await _context.SaveChangesAsync();

        }

        private async Task SeedTasks()
        {
            var proyects = await _context.Projects.ToListAsync();

            var random = new Random();

            var tasks = new List<TaskEntity>();
            foreach (var i in Enumerable.Range(1, 50))
            {
                var tarea = new TaskEntity
                {
                    Name = $"Tarea {i}",
                    Description = $"Descripción de la Tarea {i}",
                    Complete = random.Next(10)%2 == 0,
                    IdProject = proyects[random.Next(proyects.Count)].Id 
                };
                tasks.Add(tarea);
            }

            await _context.AddRangeAsync(tasks);
            await _context.SaveChangesAsync();

        }
    }
}
