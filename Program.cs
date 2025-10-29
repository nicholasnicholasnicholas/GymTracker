using GymTracker.Components;
using GymTracker.Services;
using GymTracker.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Add user session service for managing login state
builder.Services.AddScoped<UserSessionService>();

// ✅ Ensure database uses correct absolute path
var dbPath = Path.Combine(Directory.GetCurrentDirectory(), "GymTracker.db");
Console.WriteLine($"💾 Using DB at: {dbPath}");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite($"Data Source={dbPath}"));

// Add user service for data operations
builder.Services.AddScoped<UserService>();
builder.Services.AddAuthorizationCore();

var app = builder.Build();

// Configure the HTTP request pipeline.
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
