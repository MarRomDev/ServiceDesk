using Serilog;
using ServiceDesk.Infrastructure.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Logging
builder.Host.UseSerilog(((ctx, cfg) => cfg.ReadFrom.Configuration(ctx.Configuration)));

// Services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructure(builder.Configuration);


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
