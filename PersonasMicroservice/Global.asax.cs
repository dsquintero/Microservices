using AutoMapper;
using PersonasMicroservice.Application.Mappings;
using PersonasMicroservice.Application.Services;
using PersonasMicroservice.Infrastructure.DbContexts;
using PersonasMicroservice.Infrastructure.Repository;
using PersonasMicroservice.SharedKernel;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using System.Web.Http;

namespace PersonasMicroservice
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
            container.Register<PersonasContext>(Lifestyle.Scoped);
            container.Register<IPersonaService, PersonaService>(Lifestyle.Scoped);
            container.Register<IPersonaRepository, PersonaRepository>(Lifestyle.Scoped);
        }

        private void RegisterAutoMapper(Container container)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<PersonaProfile>();
            });

            container.RegisterInstance(config.CreateMapper());
        }
    }
}
