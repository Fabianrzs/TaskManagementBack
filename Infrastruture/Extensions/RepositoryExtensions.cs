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
            //svc.AddTransient(typeof(GenericRepository<>), typeof(IGenericRepository<>));
            //string baseDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            //var assemblyName = "Infrastruture.dll";
            //string assemblyPath = Path.Combine(baseDirectory, assemblyName);
            //Assembly assembly = Assembly.LoadFrom(assemblyPath);
            //var repositoryTypes = assembly.GetTypes()
            //    .Where(t => typeof(IGenericRepository<>).IsAssignableFrom(t)
            //                    && t.IsClass && !t.IsAbstract)
            //        .Select(t => new
            //        {
            //            Service = t.GetInterfaces().FirstOrDefault(),
            //            Implementation = t
            //        })
            //.Where(t => t.Service != null
            //                    && typeof(IGenericRepository<>).IsAssignableFrom(t.Service)).ToList();

            //repositoryTypes.ForEach(repositoryType => {
            //    Type genericArgument = repositoryType.Implementation.BaseType?.GenericTypeArguments[0];

            //    if (genericArgument != null)
            //    {
            //        var dalType = typeof(IGenericRepository<>).MakeGenericType(genericArgument);
            //        var implementationType = repositoryType.Implementation;
            //        svc.AddTransient(dalType, implementationType);
            //    }
            //});

            return svc;
        }
    }
}
