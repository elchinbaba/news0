using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace News0.Web
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
            //services.AddAutoMapper(typeof(Application.Mapping.MappingProfile)); // Register AutoMapper and specify the assembly containing the mapping profiles
            //services.AddAutoMapper(typeof(Data.Mapping.MappingProfile));
            //services.AddAutoMapper(typeof(MappingProfile));
            //services.AddAutoMapper(typeof(Application.Mapping.MappingProfile), typeof(Data.Mapping.MappingProfile));

            //services.AddAutoMapper(typeof(Startup));

            services.AddDbContext<Application.NewsContextApplication>(options =>
                options.UseSqlServer(@"Server=WIN-D6GRQOTSRKP\SQLEXPRESS;Database=News0;Trusted_Connection=True"));

            //services.AddScoped<Infrastructure.NewsContext>();

            services.AddControllersWithViews();

            services.AddDistributedMemoryCache(); // Required for session storage
            services.AddSession(options =>
            {
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.AddScoped<Application.Services.DbOperations.Services>();
            services.AddScoped<Application.Services.DbOperations.PostService>();
            services.AddScoped<Application.Services.DbOperations.CategoryService>();
            services.AddScoped<Application.Services.DbOperations.LanguageService>();

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<Application.Mapping.MappingProfile>(); // Add your mapping profile here
                cfg.AddProfile<Data.Mapping.MappingProfile>();
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                /*  endpoints.MapControllerRoute(
                    name: "admin-news",
                    pattern: "Admin/News/{id}",
                    defaults: new { controller = "Admin", action = "NewsDetails" }
                );*/

                //endpoints.MapControllerRoute(
                //    name: "news",
                //    pattern: "News/{id}",
                //    defaults: new { controller = "News", action = "Details" }
                //);

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
