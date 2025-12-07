using GymTracker.Components;
using GymTracker.Services;
using GymTracker.Data;
using Microsoft.EntityFrameworkCore;
using Blazored.LocalStorage;

var builder = WebApplication.CreateBuilder(args);

// Configure for Railway deployment
var port = Environment.GetEnvironmentVariable("PORT") ?? "5000";
builder.WebHost.UseUrls($"http://0.0.0.0:{port}");

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

//  Required for login persistence
builder.Services.AddScoped<UserSessionService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddAuthorizationCore();

<<<<<<< HEAD
// ✅ Ensure database uses correct absolute path
var dbPath = Path.Combine(Directory.GetCurrentDirectory(), "GymTracker.db");
Console.WriteLine($"💾 Using DB at: {dbPath}");
=======
// Configure SQLite DB
var dbPath = Path.Combine(Directory.GetCurrentDirectory(), "GymTracker.db");
Console.WriteLine($"Using DB at: {dbPath}");
>>>>>>> 0fa0dd2b285130b473c32ccd67831a5cf3e7fc39

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite($"Data Source={dbPath}"));

// Add user service for data operations
builder.Services.AddScoped<UserService>();
builder.Services.AddAuthorizationCore();

// Add local storage
builder.Services.AddBlazoredLocalStorage();

var app = builder.Build();

// Configure HTTP Pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // app.UseHsts(); // Commented out for Railway
}

// app.UseHttpsRedirection(); // Commented out for Railway (Railway handles HTTPS)

app.UseStaticFiles(); // Add this for Railway
app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
