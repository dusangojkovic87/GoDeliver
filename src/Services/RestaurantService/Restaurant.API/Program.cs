
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
using RestaurantService.Infrastracture.Extensions;



{
    var builder = WebApplication.CreateBuilder(args);




    // Add services to the container.
    builder.Services.AddRestaurantDbContext(builder.Configuration.GetConnectionString("RestaurantService"));

    //Mediatr
    builder.Services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

    //repositories
    builder.Services.AddScoped<IRestaurantCategoryRepository, RestaurantCategoryRepository>();

    //services
    builder.Services.AddScoped<IRestaurantCategoryService, RestaurantCategoryService>();

    //validators
    builder.Services.AddScoped<IValidator<AddCategoryCommand>, RestaurantCategoryValidator>();

    //handlers
    builder.Services.AddScoped<IRequestHandler<AddCategoryCommand, Category>, AddCategoryCommandHandler>();
    builder.Services.AddScoped<IRequestHandler<DeleteCategoryCommand, bool>, DeleteCategoryCommandHandler>();
    builder.Services.AddScoped<IRequestHandler<GetAllCategoriesQuery, IEnumerable<Category>>, GetAllCategoriesQueryHandler>();
    builder.Services.AddScoped<IRequestHandler<UpdateCategoryCommand, bool>, UpdateCategoryCommandHandler>();

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
