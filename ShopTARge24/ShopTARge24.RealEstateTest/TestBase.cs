using Microsoft.ApplicationInsights.WorkerService;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.Internal;
using Shop.ApplicationServices.Services;
using Shop.Core.ServiceInterface;
using Shop.Data;
using ShopTARge24.RealEstateTest.Macros;
using ShopTARge24.RealEstateTest.Mock;

namespace ShopTARge24.RealEstateTest
{
    public abstract class TestBase
    {
        protected IServiceProvider serviceProvider { get; set; }
       // protected IHostEnvironment hostEnvironment { get; set; }
        protected TestBase()
        {
            var services = new ServiceCollection();
            SetupServices(services);
            serviceProvider = services.BuildServiceProvider();
           // hostEnvironment = services.BuildServiceProvider();
        }

        public virtual void SetupServices(IServiceCollection services)
        {
            services.AddScoped<IRealEstateServices, RealEstateServices>();
            services.AddScoped<IFileServices, FileServices>();
            services.AddScoped<IHostEnvironment, MockIHostEnvironment>();

            // services.AddScoped<IHostEnvironment, HostEnvironment>();

            //var mockHostEnvironment = new Moq.Mock<IHostEnvironment>();
            //mockHostEnvironment.Setup(m => m.ContentRootPath).Returns(Path.GetTempPath());
            //services.AddSingleton(mockHostEnvironment.Object);

            services.AddDbContext<ShopContext>(x =>
            {
                x.UseInMemoryDatabase("TEST");
                x.ConfigureWarnings(b=> b.Ignore(InMemoryEventId.TransactionIgnoredWarning));
            });

            RegisterMacros(services);

        }

        public void Dispose()
        {
          
        }

        protected T Svc<T>()
        {
            //Resolve service from the service provider
            return serviceProvider.GetService<T>();
        }

        private void RegisterMacros(IServiceCollection services)
        {
            var macroBaseType = typeof(IMacros);

            var macros = macroBaseType.Assembly.GetTypes()
                .Where(t => macroBaseType.IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);

            foreach (var macro in macros)
            {
                services.AddSingleton(macro);
            }
        }
    }
}
