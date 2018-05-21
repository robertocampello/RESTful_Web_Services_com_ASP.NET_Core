using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ProductAPI.Models;

namespace ProductAPI
{
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            // Add framework services.
            services.AddDbContext<ProductContext>(opt => opt.UseInMemoryDatabase("ProductList"));
            services.AddMvc(options =>
            {
                // Add XML Serializer formatters ao MVC. Permite ao MVC serializar objeto usando o formato XML
                // tanto na solicitação quanto na resposta, caso a representação seja solicitada pelo cliente através do param Accept do header
                options.InputFormatters.Add(new XmlSerializerInputFormatter());   // input
                options.OutputFormatters.Add(new XmlSerializerOutputFormatter()); // output
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory) {
            loggerFactory.AddConsole(LogLevel.Information);
            app.UseMvc();
        }
    }
}
