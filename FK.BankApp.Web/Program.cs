using FK.BankApp.Web.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<BankContext>(
    opt=> 
    {
        opt.UseSqlServer("Data Source =.;database=BankDb;integrated security = true;");
    });
var app = builder.Build();
app.UseDeveloperExceptionPage();
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
