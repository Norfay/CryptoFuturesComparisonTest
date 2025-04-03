using DataCollectorAPI.Application;
using DataCollectorAPI.Infra;
using DataCollectorAPI.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient<HttpService>();
builder.Services.AddScoped<IFuturesGetter, FuturesGetter>();
builder.Services.AddScoped<IHttpService, HttpService>();
builder.Services.AddScoped<IKlineDataProcessor, KlineDataProcessor>();
builder.Services.AddScoped<IFuturesDataService, FuturesDataService>();

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
