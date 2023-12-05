using Autofac;
using GreatOnion.Domain.Repositories;
using GreatOnion.Persistence.ContextClasses;
using GreatOnion.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Module = Autofac.Module;

namespace GreatOnion.Persistence.DependencyResolvers
{
    public class AutofacPersistanceModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(BaseRepository<>))
                .As(typeof(IRepository<>)).InstancePerLifetimeScope();

            Assembly executingAssembly = Assembly.GetExecutingAssembly();
            Assembly repoAssembly = Assembly.GetAssembly(typeof(AppDbContext));

            builder.RegisterAssemblyTypes(executingAssembly, repoAssembly)
                .Where(x=>x.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.Register(c =>
            {
                IConfiguration config = c.Resolve<IConfiguration>();
                DbContextOptionsBuilder<AppDbContext> opt = new DbContextOptionsBuilder<AppDbContext>();
                opt.UseSqlServer(config.GetSection("ConnectionStrings:MyConnection").Value);
                return new AppDbContext(opt.Options);
            }).AsSelf().InstancePerLifetimeScope();

            
        }
    }
}
