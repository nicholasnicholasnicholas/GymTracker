using GymTracker.Components;
using GymTracker.Services;
using GymTracker.Data;
using Microsoft.EntityFrameworkCore;

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

var app = builder.Build();

// Configure HTTP Pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
