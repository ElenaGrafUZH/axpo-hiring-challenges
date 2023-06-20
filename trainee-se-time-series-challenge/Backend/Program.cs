using Backend.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<DataRepository>(provider =>
{
    var assetsFilePath = "/Users/elenagraf/Desktop/axpo-hiring-challenges/trainee-se-time-series-challenge/Backend/data/assets.json";
    var signalsFilePath = "/Users/elenagraf/Desktop/axpo-hiring-challenges/trainee-se-time-series-challenge/Backend/data/signal.json";
    var measurementsFilePath = "/Users/elenagraf/Desktop/axpo-hiring-challenges/trainee-se-time-series-challenge/Backend/data/measurements.csv";

    return new DataRepository(assetsFilePath, signalsFilePath, measurementsFilePath);
});

var app = builder.Build();

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
