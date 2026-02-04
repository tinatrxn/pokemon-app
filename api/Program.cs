using api.DbContexts;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using api.Profiles;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<PokemonBinderContext>(dbContextOptions
    => dbContextOptions.UseSqlite(
        builder.Configuration["ConnectionStrings:PokemonBinderDBConnectionString"]));

// Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowVueApp",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<PokemonCardProfile>();
}, AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Use CORS
app.UseCors("AllowVueApp");

app.UseAuthorization();

app.MapControllers();

app.Run();
