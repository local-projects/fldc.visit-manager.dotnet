using FLDCVisitManagerBackend.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AutoMapper;
using FLDCVisitManager.CMSDataLayar;
using DBManager;
using FLDCVisitManagerBackend.BL;

namespace FLDCVisitManager
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            var dom = new ConfigurationBuilder()
                    .SetBasePath(env.ContentRootPath)
                    .AddJsonFile("appsettings.json", optional: true)
                    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                    .Build(); ;
            Configuration = dom;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            IConfigurationSection cmsSettings = Configuration.GetSection("CMSOptions");
            services.Configure<AppOptionsConfiguration>(cmsSettings);
            services.Configure<DataBaseOptions>(Configuration.GetSection("ConnectionStrings"));
            services.AddAutoMapper(typeof(Startup));
            services.AddSingleton<ICMSDataHelper, SquidexHelper>();
            services.AddScoped<IDBManager, SQLHelper>();
            services.AddScoped<IBusinessLogic, BusinessLogic>();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
