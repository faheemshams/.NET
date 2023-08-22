using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using mvc17Aug.Models;

namespace mvc17Aug
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<IRepository<Student>, Repository<Student>>();
            builder.Services.AddScoped<IRepository<Course>, Repository<Course>>();
            builder.Services.AddScoped<IRepository<CourseStudent>, Repository<CourseStudent>>();
            

            builder.Services.AddAuthentication("MyCookieAuth").AddCookie("MyCookieAuth", option =>
            {
                option.Cookie.Name = "MyCookieAuth";
                option.LoginPath = "/User/Login";
                option.AccessDeniedPath = "/User/AccessDenied";
                option.ExpireTimeSpan = TimeSpan.FromSeconds(20);
            });

            builder.Services.AddAuthorization(option =>
            {
                 option.AddPolicy("AdminOnly", policy => policy
                .RequireRole("admin"));

                option.AddPolicy("ProbationOver", policy => policy
                .Requirements.Add(new ProbationChecker(1)));
            });


            builder.Services.AddScoped<IAuthorizationHandler, EmployeementDateAuthorizationHandler>();
            builder.Services.AddDbContext<DatabaseContext>(options =>
            options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=User}/{action=Login}/{id?}");

            app.Run();
        }
    }
}