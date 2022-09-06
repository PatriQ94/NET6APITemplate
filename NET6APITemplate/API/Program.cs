using API.Middleware;
using Application;
using Infrastructure;

var builder = WebApplication.CreateBuilder(args);

ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();

Configure(app);


void ConfigureServices(IServiceCollection services, ConfigurationManager configuration)
{
    //Add Application and Infrastructure layers to dependency injection
    services.AddApplication();
    services.AddInfrastructure(configuration);

    // Add services to the container.  
    services.AddControllers();

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();
}

void Configure(WebApplication app)
{
    app.UseMiddleware<ErrorHandlingMiddleware>();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}