using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using TasksTrackingApp.API.Extensions;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.AddServices();
builder.AddSwaggerDoc();
builder.AddDatabase();
builder.AddMediator();
builder.AddValidations();
builder.AddMapper();
builder.AddRepositories();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHealthChecks("/health", new HealthCheckOptions()
{
    Predicate = _ => true,
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.UseHealthChecksUI(options =>
{
    options.UIPath = "/dashboard";
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
