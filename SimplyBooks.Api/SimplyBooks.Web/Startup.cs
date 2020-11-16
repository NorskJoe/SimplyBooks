using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SimplyBooks.Domain;
using SimplyBooks.Repository.Commands;
using SimplyBooks.Repository.Queries;
using SimplyBooks.Services;
using SimplyBooks.Services.DependencyResolver;
using SimplyBooks.Services.ExceptionHandling;

namespace SimplyBooks.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddControllers();

            services
                .AddDbContext<SimplyBooksContext>(options => options.UseSqlServer(connection))

                .AddLocalization(options =>
                {
                    options.ResourcesPath = "Resources";
                });

            // Register all implementations of my interfaces using custom dependency resolver
            services.RegisterAssemblies(DependancyLifetime.Transient,
                new[] { "SimplyBooks.Services" },
                typeof(IService));

            services.RegisterAssemblies(DependancyLifetime.Transient,
                new[] { "SimplyBooks.Repository" },
                typeof(IQuery),
                typeof(ICommand));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, 
            IWebHostEnvironment env, 
            ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            loggerFactory.AddFile("Logs/logs.txt", LogLevel.Error);
            app.ConfigureExceptionHandler(loggerFactory.CreateLogger<SimplyBooksExceptionHandler>());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            app.UseAuthentication();
        }
    }
}
