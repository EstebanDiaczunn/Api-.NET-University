// 1. Usings to work with entityframework

using System.Text;
using Microsoft.EntityFrameworkCore;
using Api_esteban.DataAccess;
using Api_esteban.Models.DataModels;
using Api_esteban.Services;
using Api_esteban;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;


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
builder.Services.AddJwtServices(builder.Configuration);


builder.Services.AddControllers();

// 4. Add Custom Services (folder services)

builder.Services.AddScoped<IStudentsServices, StudentsServices>();
// TODO: add rest of services

//8. Add authorization 

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("UserOnlyPolicy", policy => policy.RequireClaim("UserOnly", "User1"));
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    //Define security
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization Header using Bearer Scheme"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            { 
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
}
);



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