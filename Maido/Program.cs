using Maido.Data;
using Maido.Data.Interfaces;
using Maido.Data.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Repositorios
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IMesaRepository, MesaRepository>();

builder.Services.AddDbContext<AppDBContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"));
    
    });

//sesion
builder.Services.AddDistributedMemoryCache(); // Cache en memoria (para dev)
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Expira en 30 min de inactividad
    options.Cookie.HttpOnly = true; // Solo accesible via HTTP (no JavaScript)
    options.Cookie.IsEssential = true; // Obligatoria aunque no se acepten cookies
    options.Cookie.Name = ".MiApp.Session";
});

var app = builder.Build();

app.UseSession();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Login}/{id?}")
    .WithStaticAssets();


app.Run();
