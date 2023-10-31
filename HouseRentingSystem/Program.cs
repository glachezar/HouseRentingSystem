namespace HouseRentingSystem
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;

    using Data.Services.Interfaces;
    using Data.Services;
    using HouseRentingSystem.Data;
    using HouseRentingSystem.Data.Models;
    using HouseRentingSystem.Web.Infrastructure.Extentions;

    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            string connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            builder.Services.AddDbContext<HouseRentingDbContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = 
                builder.Configuration.GetValue<bool>("Identity:SignIn:RequireConfirmedAccount");

                options.Password.RequireNonAlphanumeric = 
                builder.Configuration.GetValue<bool>("Identity:Password:RequireNonAlphanumeric");

                options.Password.RequireDigit = 
                builder.Configuration.GetValue<bool>("Identity:Password:RequireDigit");

                options.Password.RequireLowercase = 
                builder.Configuration.GetValue<bool>("Identity:Password:RequireLowercase");

                options.Password.RequireUppercase = 
                builder.Configuration.GetValue<bool>("Identity:Password:RequireUppercase");

                options.Password.RequiredLength = 
                builder.Configuration.GetValue<int>("Identity:Password:RequiredLength");

            })
               .AddEntityFrameworkStores<HouseRentingDbContext>();

            builder.Services.AddApplicationServices(typeof(IHouseService));

            builder.Services.AddControllersWithViews();



            WebApplication app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
                app.UseDeveloperExceptionPage();
            }
            else
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

            //app.MapControllerRoute(
            //    name: "default",
            //    pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapDefaultControllerRoute();
            app.MapRazorPages();

            app.Run();
        }
    }
}