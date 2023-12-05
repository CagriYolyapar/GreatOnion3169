using GreatOnion.InnerInfrastructure.Mappings;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreatOnion.InnerInfrastructure.DependencyResolvers
{
    public static class InnerServiceInjection
    {
        public static void AddInnerInfraServiceInjections(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(DTOMapProfile));
        }
    }
}
