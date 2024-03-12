var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();   //activate MVC

var app = builder.Build();

app.UseStaticFiles();     //wwwroot
app.UseRouting();       //routing

//Routing
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

