using eCommerce.Core;
using eCommerce.Core.Mappers;
using eCommerce.Infrastructure;
using Ecommerce.API.Middlewares;
using FluentValidation.AspNetCore;
using System.Text.Json;
using System.Text.Json.Serialization;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;


var builder = WebApplication.CreateBuilder(args);

//Add Infrastructure services
builder.Services.AddInfrastructure();
builder.Services.AddCore();

//Add controller to the service collection
builder.Services.AddControllers().AddJsonOptions(
    options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

builder.Services.AddAutoMapper(typeof(ApplicationUserMappingProfile).Assembly);

builder.Services.AddFluentValidationAutoValidation();

//add the swagger 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add cors services
/*builder.Services.AddCors(options=>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyMethod();
    });
});*/
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyMethod()
              .WithHeaders("Content-Type", "Authorization") // add any other custom headers here
              .AllowCredentials();
    });
});


var app = builder.Build();

app.UseExceptionHandlingMiddlware();

//Routing
app.UseRouting();
app.UseSwagger(); //Adds endpoint that can serve the swagger json files
app.UseSwaggerUI();

app.UseCors("AllowAngular");

//Auth
app.UseAuthentication();
app.UseAuthorization();

//Controller routes
app.MapControllers();

app.Run();
