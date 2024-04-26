using FunnyLittleWebsite.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Configure the application to listen on HTTPS port specified by an environment variable
var port = Environment.GetEnvironmentVariable("PORT") ?? "443"; // Default to 443 if PORT env variable is not set
builder.WebHost.UseUrls($"https://*:{port}");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();  // Enforce HTTPS by using HSTS (ensure your deployment environment supports HTTPS)
}

app.UseHttpsRedirection(); // Redirect HTTP to HTTPS

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();