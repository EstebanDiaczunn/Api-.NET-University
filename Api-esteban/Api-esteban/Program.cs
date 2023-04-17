// 1. Usings to work with entityframework

using Microsoft.EntityFrameworkCore;
using Api_esteban.DataAccess;
using Microsoft.Extensions.DependencyInjection;


var builder = WebApplication.CreateBuilder(args);
// 1. Usings to work with entityframework

builder.Services.AddDbContext<UnivesityDBContext>(options =>
// 1. Usings to work with entityframework

    options.UseSqlServer(builder.Configuration.GetConnectionString("UnivesityDBContext") ?? throw new InvalidOperationException("Connection string 'UnivesityDBContext' not found.")));
// 1. Usings to work with entityframework

builder.Services.AddDbContext<UniversityDBContext>(options =>
// 1. Usings to work with entityframework

    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.")));

// 2. Connection with SQL Server Express
var connection = builder.Configuration.GetConnectionString("DefaultConnection")!;

// 3. Add context to services of builder
builder.Services.AddDbContext<UniversityDBContext>(options => options.UseSqlServer(connection));

// Add services to the container.

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();