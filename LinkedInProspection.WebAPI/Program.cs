using LinkedInProspection.WebAPI.Application;
using LinkedInProspection.WebAPI.Application.GenerateIceBreakers;
using LinkedInProspection.WebAPI.Infrastructure;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddApplicationDependencies();
builder.Services.AddInfrastructureDependencies();

var app = builder.Build();

app.MapGet("/icebreakers", async (
    [FromQuery] string username,
    [FromQuery] string postedAfter,
    [FromServices] IGenerateIceBreakerQueryHandler handler) =>
{
    var query = GenerateIceBreakerQuery.Create(username, postedAfter);
    var result = await handler.Handle(query);
    return Results.Ok(result.IceBreakers);
});

app.Run();

public partial class Program;