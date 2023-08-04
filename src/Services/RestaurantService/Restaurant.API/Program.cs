
using System.Reflection;
using Application.Commands;
using Application.Handlers;
using Application.Interfaces;
using Application.Queries;
using Application.Services;
using Application.Validators;
using Authentication.API.ExceptionMiddlewares;
using Domain.Entities;
using Domain.Repositories;
using FluentValidation;
using Infrastracture.Data.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Restaurant.API.Extensions;
using RestaurantService.Infrastracture.Extensions;



{
    var builder = WebApplication.CreateBuilder(args);




    // Add services to the container.
    builder.Services.AddRestaurantDbContext(builder.Configuration.GetConnectionString("RestaurantService"));

    //Mediatr
    builder.Services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

    //ADDS repositories to DI
    builder.Services.AddRepositories();

    //adds application services to DI
    builder.Services.AddApplicationServices();

    //adds validators to DI
    builder.Services.AddValidators();


    //CQRS handlers registration
    builder.Services.AddCqrsHandlers();

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();




    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    //app.UseHttpsRedirection();

    //exception middlewares
    app.UseMiddleware<GlobalErrorMiddleware>();
    app.UseMiddleware<ValidationExceptionMiddleware>();




    app.UseAuthorization();

    app.MapControllers();

    app.Run();

}
