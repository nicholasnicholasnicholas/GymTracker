using GymTracker.Components;
using GymTracker.Services;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using GymTracker.Data;
using Microsoft.EntityFrameworkCore;
using Blazored.LocalStorage;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Allow API controllers for server-side endpoints (Google Places proxy etc.)
builder.Services.AddControllers();

// Register Google Places service and an HttpClient used for calling Google's web APIs.
builder.Services.AddHttpClient<GooglePlacesService>();
builder.Services.AddScoped<GooglePlacesService>();

// Add in-memory cache for Places responses (used by GooglePlacesService)
builder.Services.AddMemoryCache();



//  Register EF core with a SQLite database
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add user service for data operations
builder.Services.AddScoped<UserService>();

// Add local storage
builder.Services.AddBlazoredLocalStorage();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Map API controllers (e.g., /api/places/nearby)
app.MapControllers();

app.Run();
