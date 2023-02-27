using MovieApp.DAL;

var builder = WebApplication.CreateBuilder(args);
//Add Services to constainer
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<MovieDataAccess>();
//Add Request Pipelines
var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.MapDefaultControllerRoute();
app.Run();

