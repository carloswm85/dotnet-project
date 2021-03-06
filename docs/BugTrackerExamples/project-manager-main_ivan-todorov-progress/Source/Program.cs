using ElectronNET.API;
using Telerik.Project.Management;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.WebHost.UseElectron(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDataServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

if (HybridSupport.IsElectronActive)
{
    CreateElectronWindow();
}

app.Run();

async void CreateElectronWindow()
{
    var window = await Electron.WindowManager.CreateWindowAsync();

    window.OnClosed += () => Electron.App.Quit();
}
