using Microsoft.AspNet.Builder;
using Microsoft.Framework.ConfigurationModel;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Framework.Logging;
using Microsoft.AspNet.Hosting;
using nexTwitter.Infrastructure.Data;
using Microsoft.Data.Entity;
using nexTwitter.Domain.IRepositories;
using nexTwitter.Infrastructure.Data.Repositories;
using nexTwitter.Business.ApplicationServices.Services;
using nexTwitter.Business.ApplicationServices.Services.Implementation;
using nexTwitter.Business.ApplicationServices;

namespace nexTwitter
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            // Setup configuration sources.
            Configuration = new Configuration()
                .AddJsonFile("config.json")
                .AddEnvironmentVariables();
            Mappings.DefineMappings();
        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime.
        public void ConfigureServices(IServiceCollection services)
        {


            // Add MVC services to the services container.
            services.AddMvc();

            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<DataContext>(options =>
               {
                   options.UseSqlServer(Configuration.Get("Data:DefaultConnection:ConnectionString"));
               });

            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<ICommonRepository, CommonRepository>();

        }

        // Configure is called after ConfigureServices is called.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerfactory)
        {
            // Configure the HTTP request pipeline.
            // Add the console logger.
            loggerfactory.AddConsole();

            // Add MVC to the request pipeline.
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Home", action = "Index" });
            });

            app.UseIdentity();
        }
        
    }
}
