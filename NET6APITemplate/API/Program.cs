using Application;
using Infrastructure;

var builder = WebApplication.CreateBuilder(args);

ConfigureServices(builder.Services);

var app = builder.Build();

Configure(app);


void ConfigureServices(IServiceCollection services)
{
    //Add Application and Infrastructure layers to dependency injection
    services.AddApplication();
    services.AddInfrastructure();

    // Add services to the container.  
    services.AddControllers();

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();
}

void Configure(WebApplication app)
{
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