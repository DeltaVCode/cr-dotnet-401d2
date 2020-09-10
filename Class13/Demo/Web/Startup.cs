using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Web.Data;
using Web.Services;

namespace Web
{
    public class Startup
    {
        // 1. Property to hold our configuration
        public IConfiguration Configuration { get; }

        // 2. Add a constructor to receive our configuration (via magic)
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // 3. Register our DbContext with the app
            services.AddDbContext<SchoolDbContext>(options =>
            {
                // Equivalent to DATABASE_URL
                string connectionString = Configuration.GetConnectionString("DefaultConnection");
                options.UseSqlServer(connectionString);
            });

            // services.AddTransient<IStudentRepository, MemoryStudentRepository>();
            services.AddTransient<IStudentRepository, DatabaseStudentRepository>();

            services.AddTransient<ITechnologyRepository, DatabaseTechnologyRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });

                endpoints.MapGet("/boom", context =>
                {
                    throw new InvalidOperationException("boom");
                });
            });
        }
    }
}