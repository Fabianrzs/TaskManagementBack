using Infrastruture.Helppers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastruture.Extensions
{
    public static class BuildAppSetting
    {
        public static IServiceCollection BuilderAppSetting(this IServiceCollection svc, IConfiguration confg)
        {
            svc.Configure<CommentsDataBase>(confg.GetSection("CommentsDataBase"));

            return svc;
        }
    }
}
