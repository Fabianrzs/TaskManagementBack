using Aplication.Contracts;
using Aplication.Interfaces;
using Domain.Repositories;
using Infrastruture.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Infrastruture.Extensions
{
    public static class RepositoryExtensions
    {
        public static IServiceCollection AddAplicationRepositories(this IServiceCollection svc)
        {
            svc.AddScoped<IUnitOfWork, UnitOfWork>();
            svc.AddTransient<ISampleRepository, SampleRepository>();
            svc.AddTransient<ICollaboratorRepository, CollaboratorRepository>();
            svc.AddTransient<IProjectRepository, ProjectRepository>();
            svc.AddTransient<ITaskRepository, TaskRepository>();
            svc.AddTransient<IUserRepository, UserRepository>();

            return svc;
        }
    }
}
