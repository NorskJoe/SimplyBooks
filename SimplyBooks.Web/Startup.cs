using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimplyBooks.Models;
using SimplyBooks.Repository.Commands.Authors;
using SimplyBooks.Repository.Commands.Books;
using SimplyBooks.Repository.Commands.Genres;
using SimplyBooks.Repository.Commands.Nationalities;
using SimplyBooks.Repository.Queries.Books;
using SimplyBooks.Services.Authors;
using SimplyBooks.Services.Books;
using SimplyBooks.Services.Genres;
using SimplyBooks.Services.Nationalities;

namespace SimplyBooksApi
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);


            // Connection string
            var connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<SimplyBooksContext>
                (options => options.UseSqlServer(connection));

            
            RegisterServices(services);
            RegisterCommands(services);
            RegisterQueries(services);
        }

        private void RegisterQueries(IServiceCollection services)
        {
            // Authors

            // Books
            services.AddTransient<IGetBookQuery, GetBookQuery>();
            services.AddTransient<IListAllBooksQuery, ListAllBooksQuery>();
            services.AddTransient<IListBooksByAuthorNationalityQuery, ListBooksByAuthorNationalityQuery>();
            services.AddTransient<IListBooksByAuthorQuery, ListBooksByAuthorQuery>();
            services.AddTransient<IListBooksByGenreQuery, ListBooksByGenreQuery>();
            services.AddTransient<IListBooksByYearPublishedQuery, ListBooksByYearPublishedQuery>();
            services.AddTransient<IListBooksByYearReadQuery, ListBooksByYearReadQuery>();

            // Genres

            //Nationalities
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
            services.AddTransient<IListBooksByCriteriaService, ListBooksByCriteriaService>();

            // Genres
            services.AddTransient<IGenresService, GenresService>();

            // Nationalities
            services.AddTransient<INationalityService, NationalityService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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
            app.UseMvc();
        }
    }
}
