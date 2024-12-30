using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using AppVote01.Data;
using AppVote01.Services;
using AppVote01.Models;
using Microsoft.AspNetCore.Builder;


var builder = WebApplication.CreateBuilder(args); 

//var builder = AppVote01.CreateBuilder(args);
//-------------CONECTAR COM SECRETS-------------------//
// Obter a string de conex�o do secrets
var connectionString = builder.Configuration["ConnectionStrings:OracleConnection"];

// Configurar o DbContext com a string de conex�o
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseOracle(connectionString));


//OracleConnection
//builder.Services.AddDbContext<AppDbContext>(options =>
//    options.UseOracle(builder.Configuration.GetConnectionString("OracleConnection")));


builder.Services
    .AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

;

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme =
        JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["SymmetricSecurityKey"])),
        ValidateAudience = false,
        ValidateIssuer = false,
        ClockSkew = TimeSpan.Zero
    };
});



builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<TokenService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();