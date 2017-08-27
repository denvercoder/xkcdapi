using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using xkcdapi.Dtos;
using xkcdapi.Entities;
using xkcdapi.Middlewares;
using xkcdapi.Repositories;
using xkcdapi.Services;

namespace xkcdapi
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();

            Configuration = builder.Build();

        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();

            services.AddDbContext<XkcdDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IComicRepository, ComicRepository>();
            services.AddScoped<ISeedDataService, SeedDataService>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();
        
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            if (env.IsEnvironment("MyEnvironment"))
            {
                app.UseCustomMiddleware();
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();

            
            AutoMapper.Mapper.Initialize(mapper =>
            {
                mapper.CreateMap<Comic, ComicDto>().ReverseMap();
            });

//            //Uncomment this line to reseed the database
//            //for example if it gets corrupted or lost.
//            app.AddSeedData();

            app.UseMvc();

        }
    }
}
