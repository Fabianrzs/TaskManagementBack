using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infrastruture.Extensions
{
    public static class MappingExtensions
    {
        public static IServiceCollection AddAplicationMapper(this IServiceCollection svc)
        {
            var assemblyName = "Aplication.dll";
            string baseDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string assemblyPath = Path.Combine(baseDirectory, assemblyName);
            Assembly assembly = Assembly.LoadFrom(assemblyPath);
            svc.AddAutoMapper(assembly);

            return svc;
        }
    }
}
