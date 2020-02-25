using System;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SimplyBooks.Models;
using SimplyBooks.Repository.Commands.Authors;
using SimplyBooks.Repository.Commands.Books;
using SimplyBooks.Repository.Commands.Genres;
using SimplyBooks.Repository.Commands.Nationalities;
using SimplyBooks.Repository.Queries.Authors;
using SimplyBooks.Repository.Queries.Books;
using SimplyBooks.Repository.Queries.Genres;
using SimplyBooks.Repository.Queries.Home;
using SimplyBooks.Repository.Queries.Nationalities;
using SimplyBooks.Services.Authors;
using SimplyBooks.Services.Books;
using SimplyBooks.Services.Genres;
using SimplyBooks.Services.Home;
using SimplyBooks.Services.Nationalities;

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
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies())
                .AddControllers();

            // Connection string
            var connection = Configuration.GetConnectionString("DefaultConnection");
            services
                .AddDbContext<SimplyBooksContext>(options => options.UseSqlServer(connection));

            

            // Register dependencies
            RegisterServices(services);
            RegisterCommands(services);
            RegisterQueries(services);
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

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            // I will handle any info / error logs manually.  Auto log critical crashes
            loggerFactory.AddFile("Logs/logs.txt", LogLevel.Critical);
        }

        private void RegisterQueries(IServiceCollection services)
        {
            // Authors
            services.AddTransient<IListAllAuthorsQuery, ListAllAuthorsQuery>();

            // Books
            services.AddTransient<IGetBookQuery, GetBookQuery>();
            services.AddTransient<IListAllBooksQuery, ListBooksQuery>();

            // Genres
            services.AddTransient<IListAllGenresQuery, ListAllGenresQuery>();

            // Nationalities
            services.AddTransient<IListAllNationalitiesQuery, ListAllNationalitiesQuery>();

            // Home
            services.AddTransient<IListRecentBooksQuery, ListRecentBooksQuery>();
        }

        private void RegisterCommands(IServiceCollection services)
        {
            //Authors
            services.AddTransient<IAddAuthorCommand, AddAuthorCommand>();
            services.AddTransient<IUpdateAuthorCommand, UpdateAuthorCommand>();

            // Books
            services.AddTransient<IAddBookCommand, AddBookCommand>();
            services.AddTransient<IDeleteBookCommand, DeleteBookCommand>();
            services.AddTransient<IUpdateBookCommand, UpdateBookCommand>();

            //Genres
            services.AddTransient<IAddGenreCommand, AddGenreCommand>();
            services.AddTransient<IUpdateGenreCommand, UpdateGenreCommand>();

            // Nationalities
            services.AddTransient<IAddNationalityCommand, AddNationalityCommand>();
            services.AddTransient<IUpdateNationalityCommand, UpdateNationalityCommand>();
        }

        private void RegisterServices(IServiceCollection services)
        {
            // Authors
            services.AddTransient<IAuthorsService, AuthorsService>();

            // Books
            services.AddTransient<IBasicBooksService, BasicBooksService>();

            // Genres
            services.AddTransient<IGenresService, GenresService>();

            // Nationalities
            services.AddTransient<INationalityService, NationalityService>();

            // Home
            services.AddTransient<IHomeService, HomeService>();
        }
    }
}
