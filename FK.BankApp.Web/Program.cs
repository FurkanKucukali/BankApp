using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
var app = builder.Build();
app.UseStaticFiles();
app.UseStaticFiles(
    new StaticFileOptions { FileProvider = new PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory(),"node_modules")),
        RequestPath = "/node_modules"
    });
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
});

app.Run();
