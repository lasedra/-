using GreatBritain.Models;

var builder = WebApplication.CreateBuilder(args);
    builder.Services.AddControllersWithViews();
    builder.Services.AddDbContext<SchoolDbContext>();
    builder.Services.AddMvc(options => options.EnableEndpointRouting = false);

var app = builder.Build();

app.UseDeveloperExceptionPage();
app.UseStaticFiles();
app.UseStatusCodePages();
app.UseMvcWithDefaultRoute();

app.MapControllerRoute(
name: "default",
pattern: "{controller=Products}/{action=Index}");

app.Run();
