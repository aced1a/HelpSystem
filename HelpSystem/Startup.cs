using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using HelpSystem.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;

namespace HelpSystem
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration) =>
            Configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            services.AddMvc(options => options.EnableEndpointRouting = false);

            services.AddDbContext<HelpSystem.Infrastructure.ApplicationDbContext>(options =>
                options.UseSqlServer("Data Source=DESKTOP-767L0O2\\SQLEXPRESS;initial catalog=help_system;integrated security=True;MultipleActiveResultSets=True;"));
                    //Configuration.GetConnectionString("default")));

            services.AddTransient<IRequestSender, RequestSender>();
            //services.AddSingleton<IRequestSender, RequestSender>();
            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddSession();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
            } else
            {
                //app.UseExceptionHandler("");
            }

            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            }); 

            
        }
    }
}
