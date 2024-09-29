using AutoMapper;
using CitasMicroservice.Application.Mappings;
using CitasMicroservice.Application.Services;
using CitasMicroservice.Infrastructure.DbContexts;
using CitasMicroservice.Infrastructure.Repository;
using CitasMicroservice.SharedKernel;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using System.Web.Http;

namespace CitasMicroservice
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            // Registrar AutoMapper
            RegisterAutoMapper(container);

            // Registro de dependencias
            RegisterDependencies(container);

            // Registrar controladores
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            // Verificar la configuración
            container.Verify();

            // Configurar Web API
            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);

            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

        private void RegisterDependencies(Container container)
        {
            container.Register<CitasContext>(Lifestyle.Scoped);
            container.Register<ICitaService, CitaService>(Lifestyle.Scoped);
            container.Register<ICitaRepository, CitaRepository>(Lifestyle.Scoped);
            container.Register<IPersonaService, PersonaService>(Lifestyle.Scoped);

        }

        private void RegisterAutoMapper(Container container)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CitaProfile>();
            });

            container.RegisterInstance(config.CreateMapper());
        }
    }
}
