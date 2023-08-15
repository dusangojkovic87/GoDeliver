using System.Reflection;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Authentication.API.ExceptionMiddlewares;
using Infrastructure.Configuration;

using Authentication.API.Extensions;
{

    var builder = WebApplication.CreateBuilder(args);
    var configuration = builder.Configuration;

    // Add services to the container.

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    //jwt configuration
    var jwtConfig = new JwtConfig
    {
        SecretKey = configuration["JwtConfig:SecretKey"],
        Issuer = configuration["JwtConfig:Issuer"],
        Audience = configuration["JwtConfig:Audience"]
    };

    builder.Services.AddJwtConfiguration(jwtConfig);

    //AuthDbContext
    builder.Services.AddAuthenticationDbContext(builder.Configuration.GetConnectionString("Authentication"));
    //Mediatr
    builder.Services.AddMediatR(config =>
    {
        config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
    });

    //fluent validation
    builder.Services.AddValidators();

    // CQRS handlers registration
    builder.Services.AddCqrsHandlers();



    //adds repositories to DI
    builder.Services.AddRepositories();

    //adds application services to DI
    builder.Services.AddApplicationServices();


    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    //Error middlewares

    app.UseMiddleware<GlobalErrorMiddleware>();
    app.UseMiddleware<ValidationExceptionMiddleware>();


    //app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();

}



