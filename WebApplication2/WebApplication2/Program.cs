using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;


using WebApplication2.Services;

namespace WebApplication2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddHttpClient("Weather", x =>
            {
                x.BaseAddress = new Uri("https://api.openweathermap.org/data/2.5/forecast");
            });
            builder.Services.AddHttpClient("StormyDaniels", x =>
            {
                x.BaseAddress = new Uri("https://api.stormglass.io/v2");
                x.DefaultRequestHeaders.Add("Authorization", "b96cdc14-e5ea-11ee-be1e-0242ac130002-b96cdcb4-e5ea-11ee-be1e-0242ac130002");
                
            });
            builder.Services.AddScoped<IMyWeatherService, MyWeatherService>();
            builder.Services.AddScoped<IStormGlassService, StormGlassService>();
            builder.Services.AddEndpointsApiExplorer();

            var apiVersioningBuilder = builder.Services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
                options.DefaultApiVersion = new Asp.Versioning.ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                // Use whatever reader you want
                options.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader(),
                                                new HeaderApiVersionReader("x-api-version"),
                                                new MediaTypeApiVersionReader("x-api-version"));
            }); // Nuget Package: Asp.Versioning.Mvc

            apiVersioningBuilder.AddApiExplorer(options =>
            {
                // add the versioned api explorer, which also adds IApiVersionDescriptionProvider service
                // note: the specified format code will format the version as "'v'major[.minor][-status]"
                options.GroupNameFormat = "'v'VVV";

                // note: this option is only necessary when versioning by url segment. the SubstitutionFormat
                // can also be used to control the format of the API version in route templates
                options.SubstituteApiVersionInUrl = true;
            }); // Nuget Package: Asp.Versioning.Mvc.ApiExplorer


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

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
