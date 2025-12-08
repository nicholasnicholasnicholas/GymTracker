using GymTracker.Components;
using GymTracker.Services;
using GymTracker.Data;
using Microsoft.EntityFrameworkCore;
using Blazored.LocalStorage;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

//  Required for login persistence
builder.Services.AddScoped<UserSessionService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddAuthorizationCore();

// Configure SQLite DB
var dbPath = Path.Combine(Directory.GetCurrentDirectory(), "GymTracker.db");
Console.WriteLine($"Using DB at: {dbPath}");

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
