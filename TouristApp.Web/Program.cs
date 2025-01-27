using Microsoft.OpenApi.Models;
using TouristApp.Application;
using TouristApp.Application.Interfaces;
using TouristApp.Persistance;
using TouristApp.Web.Components;
using TouristApp.Domain.MappingProfiles;
using TouristApp.Web.Services.GeoLocationBroker;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(TouristAppMappingProfile));
builder.Services.AddPersistance(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddTransient<IGeoLocationBroker, GeoLocationBroker>();
builder.Services.AddScoped<ITouristApplicationDbContext>(provider => 
    provider.GetRequiredService<TouristApplicationDbContext>());
builder.Services.AddSwaggerGen(options =>
{ 
    options.SwaggerDoc("v1", new OpenApiInfo {Title = "Test", Version = "v1"});
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter JWT token",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement {
    {
        new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
            }
        }, 
        new string[] {}
    }});
});

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("./v1/swagger.json", "Test v1"));
app.UseAntiforgery();

app.MapControllers();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();