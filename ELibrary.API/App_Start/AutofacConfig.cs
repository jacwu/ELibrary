using Autofac;
using Autofac.Integration.WebApi;
using ELibrary.API.Factories;
using ELibrary.Data.Infra;
using ELibrary.Data.Repositories;
using ELibrary.Service;
using System.Linq;
using System.Reflection;
using System.Web.Http;

namespace ELibrary.API
{
    public static class AutofacConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());


            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();
            builder.RegisterType<ModelFactory>().As<IModelFactory>().InstancePerRequest();

            // Repositories
            builder.RegisterAssemblyTypes(typeof(BookRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();

            // Services
            builder.RegisterAssemblyTypes(typeof(BookService).Assembly)
               .Where(t => t.Name.EndsWith("Service"))
               .AsImplementedInterfaces().InstancePerRequest();


            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}