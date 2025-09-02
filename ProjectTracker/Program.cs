using Microsoft.EntityFrameworkCore;
using ProjectTracker.DAL.Context;
using ProjectTracker.Data;
using ProjectTracker.Infrastructure.Interfaces;
using ProjectTracker.Infrastructure.Services;

namespace ProjectTracker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<ProjectTrackerDataBase>(opt =>
                opt.UseSqlServer(connectionString)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors());

            builder.Services.AddTransient<ProjectTrackerDbInitializer>();

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<ITaskService, TaskService>();
            builder.Services.AddScoped<IProjectService, ProjectService>();
            builder.Services.AddScoped<IProjectData, SqlProjectData>();

            builder.Services.AddSession();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseSession();
            app.UseRouting();

            app.UseStaticFiles();
            app.UseStatusCodePages();
            app.UseDeveloperExceptionPage();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapRazorPages()
                .WithStaticAssets();

            using (var scope = app.Services.CreateScope())
            {
                var serviceInitializer = scope.ServiceProvider.GetRequiredService<ProjectTrackerDbInitializer>();
                serviceInitializer.Initialize();
            }


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Project}/{action=Index}/{id?}");
            });

            app.Run();
        }
    }
}

