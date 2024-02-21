using DollarSenseUI.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using DollarSenseDB;

namespace DollarSenseUI
{
    public class Program
    {
        // DO NOT MODIFY unless necessary.
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Below are services to add to the container. This gets called by the runtime.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            // "AddSingleton" means create one object and use that object throughout the application
            builder.Services.AddSingleton<WeatherForecastService>();
            // "AddTransient" means create an object every time it is asked for
            builder.Services.AddTransient<ISQLDataAccess, SQLDataAccess>();
            builder.Services.AddTransient<ICountryData, CountryData>();
            builder.Services.AddTransient<IUSStateData, USStateData>();
            builder.Services.AddTransient<IUSCityData, USCityData>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.Run();
        }
    }
}