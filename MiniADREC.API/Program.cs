using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using MiniADREC.Caching.DependencyInjection;
using MiniADREC.Common.Extensions;
using MiniADREC.Context.DependencyInjection;
using MiniADREC.Repositories.DependencyInjection;
using MiniADREC.Services.DependencyInjection;
using Scalar.AspNetCore;
using System.Text;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Registring MY services here 

builder.Services.AddServiceLayer();
builder.Services.AddContextLayer(builder.Configuration);
builder.Services.AddRepositoryLayer();
builder.Services.AddRedisCaching(builder.Configuration);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:key"]!))
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseGlobalErrorHandling();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
