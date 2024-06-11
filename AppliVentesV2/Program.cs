using Microsoft.EntityFrameworkCore;
using AppliVentes.Models.Repository;
using GestionArticles.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add DbContext via injection
        builder.Services.AddDbContext<AppliVentesDbContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("AppliVentesDbContext"));
        });

        // Add ArticleService as an injection
        builder.Services.AddScoped<ArticleService>();

        builder.Services.AddHttpClient();

        // Add services to the container.
        builder.Services.AddControllersWithViews();

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

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}