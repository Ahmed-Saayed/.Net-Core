using APILearn.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

var constring= builder.Configuration.GetConnectionString("DefaultConnection");  // Connection strings
builder.Services.AddDbContext<DataCon>(op => op.UseSqlServer(constring));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddCors();         // Edited

builder.Services.AddSwaggerGen(op =>        //Edited
{
    op.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "My First Api",
        Description ="Learn For Future",
        TermsOfService = new Uri("https://codeforces.com/profile/Ahmed_Sayed-"),
        Contact = new OpenApiContact
        {
            Name = "LeetCode",
            Email = "https://leetcode.com/u/AhmedSayed1/"
        },

        License = new OpenApiLicense
        {
            Name = "PATO",
            Url = new Uri("https://leetcode.com/u/AhmedSayed1/")
        }
    });

    op.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme              //Edited   
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        In=ParameterLocation.Header,
        Description="Enter Ur Key"
    });

    op.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
        new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
            },
            Name = "Bearer"
        },
       new List<string>()
        }
       });
});

builder.Services.AddTransient<IGenre_Services,Genre_Services>();   // Dependency injection for clas of interface we put all implements or extended class with it

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(op=>op.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());       //Edited

app.UseAuthorization();

app.MapControllers();

app.Run();
