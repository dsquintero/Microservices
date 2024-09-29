using System.Web.Http;
using AutoMapper;
using RecetasMicroservice.Application.Mappings;
using RecetasMicroservice.Application.Services;
using RecetasMicroservice.Infrastructure.DbContexts;
using RecetasMicroservice.Infrastructure.Repository;
using RecetasMicroservice.SharedKernel;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;

namespace RecetasMicroservice
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
            container.Register<RecetasContext>(Lifestyle.Scoped);
            container.Register<IRecetaService, RecetaService>(Lifestyle.Scoped);
            container.Register<IRecetaRepository, RecetaRepository>(Lifestyle.Scoped);
        }

        private void RegisterAutoMapper(Container container)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<RecetaProfile>();
            });

            container.RegisterInstance(config.CreateMapper());
        }
    }
}
