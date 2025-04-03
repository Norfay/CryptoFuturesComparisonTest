using BTCFuturesTest;
using Hangfire;
using Hangfire.PostgreSql;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddHangfire(config => config.UsePostgreSqlStorage(c => 
c.UseNpgsqlConnection(builder.Configuration.GetConnectionString("ConnectionStrings:HangfireConnectionString"))));
builder.Services.AddHangfireServer();

var app = builder.Build();

app.UseHangfireDashboard();

//RecurringJob.AddOrUpdate<IBTCFuturesGetter>(
//    "fetch-futures-data-current",
//    getter => getter.GetFuturesData("BTCUSDT_250627"),
//    Cron.Daily
//    );
//RecurringJob.AddOrUpdate<IBTCFuturesGetter>(
//    "fetch-futures-data-next",
//    getter => getter.GetFuturesData("BTCUSDT_250926"),
//    Cron.Daily
//    );

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
