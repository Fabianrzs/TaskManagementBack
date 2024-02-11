using Aplication.Contracts;
using Aplication.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Infrastruture.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddAplicationServices(this IServiceCollection svc)
        {
            svc.AddTransient<ISampleService,SampleService>();

            //var assemblyNames = new List<string> { "Aplication.dll" };
            //var _services = new List<Type>();
            //string baseDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            //var serviceType = typeof(IGenericService<>);

            //assemblyNames.ForEach(assemblyName =>
            //{
            //    string assemblyPath = Path.Combine(baseDirectory, assemblyName);
            //    Assembly assembly = Assembly.LoadFrom(assemblyPath);
            //    var r = assembly.GetTypes()
            //        .Where(p => p.CustomAttributes.Any(x => x.AttributeType == serviceType));
            //    _services.AddRange(assembly.GetTypes()
            //        .Where(p => p.CustomAttributes.Any(x => x.AttributeType == serviceType))
            //    );
            //});

            //_services.ForEach(serviceType => svc.AddTransient(serviceType));

            return svc;
        }
    }
}
