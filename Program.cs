var builder = WebApplication.CreateBuilder(args);
//Add Services to constainer
builder.Services.AddControllersWithViews();
//Add Request Pipelines
var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.MapDefaultControllerRoute();
app.Run();

