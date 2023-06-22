using Backend.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//allows use of controllers for handling incoming HTTP requests and generating answers
builder.Services.AddControllers();

// registers the DataRepository class as a scoped service in the dependency injection container.
builder.Services.AddScoped<DataRepository>(provider =>
{
    var assetsFilePath = "/Users/elenagraf/Desktop/axpo-hiring-challenges/trainee-se-time-series-challenge/Backend/data/assets.json";
    var signalsFilePath = "/Users/elenagraf/Desktop/axpo-hiring-challenges/trainee-se-time-series-challenge/Backend/data/signal.json";
    var measurementsFilePath = "/Users/elenagraf/Desktop/axpo-hiring-challenges/trainee-se-time-series-challenge/Backend/data/measurements.csv";

    return new DataRepository(assetsFilePath, signalsFilePath, measurementsFilePath);
});

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

//maps the controllers and their actions as endpoints for handling incoming HTTP requests.
app.MapControllers();

app.Run();
