using PriceAnalyzerAPI.Application;
using PriceAnalyzerAPI.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddHttpClient<DataCollectorService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IFuturesDataProcessor, FuturesDataProcessor>();
builder.Services.AddScoped<IFuturesDeltaCalculator, FuturesDeltaCalculator>();
builder.Services.AddScoped<IDataCollectorService, DataCollectorService>();

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
