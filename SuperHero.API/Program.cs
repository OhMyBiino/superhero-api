using SuperHero.API.DBContext;
using Microsoft.EntityFrameworkCore;
using SuperHero.API.Repositories.SuperHeroRepo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//register repository dependencies
builder.Services.AddScoped<ISuperHeroRepository, SuperHeroRepository>();

//Add Database Context
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Add Cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("AngularPolicy", builder =>
    {
        builder.WithOrigins("http://localhost:4200")
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AngularPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
