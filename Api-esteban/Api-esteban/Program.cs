// 1. Usings to work with entityframework

using Microsoft.EntityFrameworkCore;
using Api_esteban.DataAccess;
using Api_esteban.Models.DataModels;
using Api_esteban.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;


var builder = WebApplication.CreateBuilder(args);



builder.Services.AddDbContext<UniversityDBContext>(options =>

    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'UniversityDBContext' not found.")));

builder.Services.AddDbContext<UniversityDBContext>(options =>

    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.")));

var connection = builder.Configuration.GetConnectionString("DefaultConnection")!;

// 3. Add context to services of builder
builder.Services.AddDbContext<UniversityDBContext>(options => options.UseSqlServer(connection));

// Add services to the container.


// ADD service of JWT Auth
//builder.Services.AddJwtTokenServices(builder.Configuration);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer();

builder.Services.AddControllers();

// 4. Add Custom Services (folder services)

builder.Services.AddScoped<IStudentsServices, StudentsServices>();
// TODO: add rest of services

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
    


//5. CORS Configuration

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "CorsPolicy", builder =>
    {
        builder.AllowAnyOrigin();
        builder.AllowAnyMethod();
        builder.AllowAnyHeader();
    });
});

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

//6. Tell app to use CORS
app.UseCors("CorsPolicy");

app.Run();