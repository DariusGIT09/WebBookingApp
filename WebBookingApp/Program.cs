using Microsoft.EntityFrameworkCore;
using WebBookingApp.Data;

var builder = WebApplication.CreateBuilder(args);

var adminUsername = "admin";
var adminPassword = "admin123"; // 🔹 Parola hardcodată (NU recomandată în producție)


// Adăugăm serviciile MVC și Entity Framework Core cu SQLite
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddSession(); // 🔹 Activează suportul pentru sesiuni

var app = builder.Build();

// Configurare pipeline middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession(); // 🔹 Activează sesiunile în aplicație

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();