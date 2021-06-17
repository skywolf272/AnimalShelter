using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DogShelter.Data;
using DogShelter.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.HttpOverrides;

namespace DogShelter
{
    public class Startup
    {
        //Startup - ответсвтенен за настройку всего приложения при записук
        //Он настраивает сервисы, библиотеки которые мы использовали
        public Startup(IConfiguration configuration) 
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("ShelterDatabase"))); //Настройка подключения к БД

            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<AppDbContext>(); //Настройка Asp Identity

            services.AddControllersWithViews(); //Настраивает работу паттерна MVC

            services.Configure<IdentityOptions>(options =>
           {
               options.Password.RequireDigit = false;
               options.Password.RequireLowercase = true;
               options.Password.RequireUppercase = true;
               options.Password.RequiredLength = 6;

               options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
               options.Lockout.AllowedForNewUsers = true;

               options.User.RequireUniqueEmail = false;
           }); //Настройка для входа пользоателя в аккаунт
           }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });
            
            //Настройка приложения и конечных точек
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("Admin", "{area:exists}/{controller=Admin}/{action=Index}/{id?}");
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
