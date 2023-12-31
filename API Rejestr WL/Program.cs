using API_Rejestr_WL.Services;
using DatabaseProvider;

namespace API_Rejestr_WL;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllersWithViews();
        builder.Services.AddSingleton<IDatabaseService, DatabaseService>();
        builder.Services.AddSingleton<IHttpClientService, HttpClientService>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UsePathBase(new PathString("/api"));
        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        app.MapFallbackToFile("index.html");

        app.Run();
    }
}