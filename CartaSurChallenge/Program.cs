
using CartaSurChallenge.Data;
using CartaSurChallenge.Repository;
using CartaSurChallenge.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

var connectionString = configuration.GetSection("ConnectionStrings")["Sql"];
builder.Services.AddDbContext<CartaSurChallengeDbContext>(
                c => c.UseSqlServer(connectionString));

builder.Services.AddTransient<IEmpleadoService, EmpleadoService>();
builder.Services.AddTransient<IVentaService, VentaService>();
builder.Services.AddTransient<IApiService, ApiService>();
builder.Services.AddScoped(typeof(IAsyncRepository<>), typeof(EfRepository<>));
// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient<IApiService, ApiService>(client =>
{
    client.BaseAddress = new Uri("https://svct.cartasur.com.ar/");
});

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
