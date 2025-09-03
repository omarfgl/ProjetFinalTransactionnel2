using ProjetFinalTrans2.Data;
using ProjetFinalTrans2.Data.Services;
using ProjetFinalTrans2.Data.Cart;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using ProjetFinalTrans2.Data; //seed

namespace ProjetFinalTrans2
{
    public class Program
    {
        public static async Task Main(string[] args) 
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configuration base de données
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>() 
                .AddEntityFrameworkStores<AppDbContext>();

            // Services de l'application
            builder.Services.AddScoped<IRealisationService, RealisationService>();
            builder.Services.AddScoped<IOrdersService, OrdersService>();

            // Gestion du panier et session
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddSession();
            builder.Services.AddScoped(sc => ShoppingCart.GetShoppingCart(sc));

            // Ajout des contrôleurs et des vues
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Middleware
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            // Seed l'admin au démarrage
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                await SeedData.InitializeAsync(services);
            }

            app.Run();
        }
    }
}
