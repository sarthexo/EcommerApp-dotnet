
using AutoMapper;
using ECommerceApp.Application.Common.MappingProfile;
using ECommerceApp.Infrastructure;
using ECommerceApp.Infrastructure.Middleware;
using ECommerceApp.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;


namespace ECommerceApp.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            //adding services
            builder.Services.AddPersistenceServices(builder.Configuration);
            builder.Services.AddInfrastructureServices(builder.Configuration);

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //for swagger Jwt support
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo 
                { 
                    Title = "ECommerceApp API",
                    Version = "v1" 
                
                });

                //Add JWT Bearer Authorization to Swagger
                c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                    Description = @"JWT Authorization header using the Bearer Scheme.
                                  Enter 'Bearer' [space] and then your token in the text input below.
                                  Example: Bearer abc123xyz456",
  
                });

                c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
                {
                    {
                        new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                        {
                            Reference=new Microsoft.OpenApi.Models.OpenApiReference
                            {
                                Type=Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                                Id="Bearer"
                            },
                            Scheme="bearer",
                            Name="Authorization",
                            In=Microsoft.OpenApi.Models.ParameterLocation.Header
                        },
                        Array.Empty<string>()
                    }
                });
            });

            //Adding profile here
            builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

            var jwtSection = builder.Configuration.GetSection("Jwt");
            //configuring authentication
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    var key = jwtSection["Key"]!;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = bool.Parse(jwtSection["ValidateIssuer"] ?? "true" ),
                        ValidateAudience = bool.Parse(jwtSection["ValidateAudience"] ?? "true"),
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtSection["Issuer"],
                        ValidAudience = jwtSection["Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
                    };
                });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //exception handling
            app.UseMiddleware<ExceptionHandlingMiddleware>();

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
