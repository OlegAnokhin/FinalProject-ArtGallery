namespace ArtGallery.Web
{
    using ArtGallery.Data;
    using Infrastucture.Extensions;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Services.Data.Interfaces;

    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
            //var connectionString = builder.Configuration.GetConnectionString("ArtGalleryDbContextConnection") ?? throw new InvalidOperationException("Connection string 'ArtGalleryDbContextConnection' not found.");

            // Add services to the container.
            var connectionString = builder.Configuration
                .GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            builder.Services.AddDbContext<ArtGalleryDbContext>(options =>
                options.UseSqlServer(connectionString));

            //builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddEntityFrameworkStores<ArtGalleryDbContext>();

            builder.Services
                .AddDefaultIdentity<IdentityUser>(options =>
                {
                    options.SignIn.RequireConfirmedAccount =
                        builder.Configuration.GetValue<bool>("Identity:SignIn:RequireConfirmedAccount");
                    options.Password.RequireLowercase =
                        builder.Configuration.GetValue<bool>("Identity:Password:RequireLowercase");
                    options.Password.RequireUppercase =
                        builder.Configuration.GetValue<bool>("Identity:Password:RequireUppercase");
                    options.Password.RequireNonAlphanumeric =
                        builder.Configuration.GetValue<bool>("Identity:Password:RequireNonAlphanumeric");
                    options.Password.RequiredLength =
                        builder.Configuration.GetValue<int>("Identity:Password:RequiredLength");
                })
                .AddEntityFrameworkStores<ArtGalleryDbContext>();

            builder.Services.AddApplicationServices(typeof(IPictureService));

            builder.Services.AddControllersWithViews();

            WebApplication app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error/500");
                app.UseStatusCodePagesWithRedirects("/Home/Error?statusCode={0}");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapDefaultControllerRoute();
            app.MapRazorPages();

            app.Run();
        }
    }
}