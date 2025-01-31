//MiddleWares Like a class the system uses it when a client make request and if its didnt meet the condition didnt execute the request
// Middle ware like a (boab sa3edy)  take the Url and didnt know any thing about it but filter the same but know the url details
// Get request didnt have body in request 
// Basic Authentication is not secure  

using APIILearn;
using APIILearn.Authentication;
using APIILearn.Filter;
using APIILearn.MiddleWares;
using APIILearn.Model;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataCon>(op => op.UseSqlServer("Server=localhost;Database=ApiiData;Trusted_Connection=True; TrustServerCertificate=True"));

builder.Services.AddControllers();

/*builder.Services.AddControllers(op=>{       
    op.Filters.Add<Log_Activity_Filter>();          // Added filter (this way to add global filter works on any action)
});*/                                               // when use it delete the up method

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//===================================================================
// Authentication

/*
var jwtoptions = builder.Configuration.GetSection("Jwt").Get<JwtOptions>();
builder.Services.AddSingleton(jwtoptions);
*/

builder.Services.AddAuthentication()
        .AddScheme<AuthenticationSchemeOptions, Basic_Authentication_Handler>("Basic", null);

/*.AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, op => {
    op.SaveToken = true;
    op.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = jwtoptions.Issuer,
        ValidateAudience = true,
        ValidAudience = jwtoptions.Audience,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtoptions.SigningKey))
    };
});*/



//===================================================================
// Dependance injection
builder.Services.AddTransient<WeatherForecast>();     //send many new instance from this class
builder.Services.AddScoped<WeatherForecast>();        //send just one instance over request  and ots Default
builder.Services.AddSingleton<WeatherForecast>();     // send just one instance over application 
//================================================================================================================

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//===================================================================
//MiddleWares           
//app.UseMiddleware<Rate_Limited_MiddleWares_Requests>();         // Added the MiddleWare
//===================================================================
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
