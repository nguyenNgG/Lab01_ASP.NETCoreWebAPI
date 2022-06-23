using CoreWCF;
using CoreWCF.Configuration;
using CoreWCF.Description;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repositories;

namespace CoreWCFAppServer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddServiceModelServices().AddServiceModelMetadata();
            services.AddSingleton<IServiceBehavior, UseRequestHeadersForMetadataAddressBehavior>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseServiceModel(builder =>
                {
                    builder.AddService<ProductService>(options => { options.DebugBehavior.IncludeExceptionDetailInFaults = true; })
                    .AddServiceEndpoint<ProductService, IProductService>(new BasicHttpBinding(), "/ProductService/basichttp")
                    .AddServiceEndpoint<ProductService, IProductService>(new WSHttpBinding(SecurityMode.Transport), "/ProductService/WSHttps");
                });

            var serviceMetadataBehavior = app.ApplicationServices.GetRequiredService<ServiceMetadataBehavior>();
            serviceMetadataBehavior.HttpGetEnabled = true;
        }
    }
}
