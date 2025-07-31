using eCommerce.Core;
using eCommerce.Core.Mappers;
using eCommerce.Infrastructure;
using Ecommerce.API.Middlewares;
using FluentValidation.AspNetCore;
using System.Text.Json;
using System.Text.Json.Serialization;

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

var app = builder.Build();

app.UseExceptionHandlingMiddlware();

//Routing
app.UseRouting();

//Auth
app.UseAuthentication();
app.UseAuthorization();

//Controller routes
app.MapControllers();

app.Run();
