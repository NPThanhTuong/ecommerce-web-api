using EcommerceWebApi.Data;
using EcommerceWebApi.Services.Email;
using EcommerceWebApi.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient(); //KHA AI THEM VAO

// Add services to the container.
builder.Services.AddDbContext<EcommerceDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        // Serialize enums as strings
        options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Description = "Bearer Authentication with JWT Token",
        Type = SecuritySchemeType.Http
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            },
            new List<string>()
        }
    });

    options.EnableAnnotations();
});

// Add CORS
builder.Services.AddCors(options =>
{
    //options.AddPolicy(ConstConfig.AllowSpecificOrigins,
    //policy =>
    //{
    //    policy.WithOrigins($"http://localhost:{ConstConfig.ClientPort}") // Allow requests from this origin
    //          .AllowAnyHeader()
    //          .AllowAnyMethod()
    //          .AllowCredentials();
    //});

    options.AddPolicy(ConstConfig.AllowAllOrigins,
    policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// add Automapper
builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateActor = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
    };

    options.Events = new JwtBearerEvents
    {
        OnChallenge = context =>
        {
            // Customize the response when unauthorized access occurs
            context.HandleResponse();
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            context.Response.ContentType = "application/json";
            return context.Response.WriteAsync("{\"message\": \"You are not authorized to access this resource.\"}");
        }
    };
});

builder.Services.AddAuthorizationBuilder()
     .AddPolicy(ConstConfig.AdminPolicy, policy =>
        policy.RequireRole(ConstConfig.AdminRoleName)
     )
     .AddPolicy(ConstConfig.ShopPolicy, policy =>
         policy.RequireRole(ConstConfig.AdminRoleName, ConstConfig.ShopRoleName)
     )
     .AddPolicy(ConstConfig.UserPolicy, policy =>
          policy.RequireRole(ConstConfig.AdminRoleName, ConstConfig.ShopRoleName, ConstConfig.UserRoleName)
     );

// Add email service
builder.Services.AddScoped<IEmailService, EmailService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(ConstConfig.AllowAllOrigins);

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();


app.Run();
