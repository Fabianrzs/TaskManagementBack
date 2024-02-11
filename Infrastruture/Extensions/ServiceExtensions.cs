using Aplication.Contracts;
using Aplication.Interfaces;
using Domain.Repositories;
using Infrastruture.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastruture.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddAplicationServices(this IServiceCollection svc)
        {
            svc.AddTransient<ISampleService,SampleService>();
            svc.AddTransient<ICollaboratorService, CollaboratorService>();
            svc.AddTransient<IProjectService, ProjectService>();
            svc.AddTransient<ITaskEntityService, TaskEntityService>();
            svc.AddTransient<IUserService, UserService>();

            return svc;
        }
    }
}
