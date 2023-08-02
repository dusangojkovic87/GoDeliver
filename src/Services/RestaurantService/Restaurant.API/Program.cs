
using System.Reflection;
using Authentication.API.ExceptionMiddlewares;
using Microsoft.Extensions.DependencyInjection;
using RestaurantService.Infrastracture.Extensions;



{
    var builder = WebApplication.CreateBuilder(args);




    // Add services to the container.
    builder.Services.AddRestaurantDbContext(builder.Configuration.GetConnectionString("RestaurantService"));

    //Mediatr
    builder.Services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));



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
