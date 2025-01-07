using API.Configuration;
using API.Middlewares;
using Infrastructure.Persistence.Helpers;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.ConfigureDatabase(builder.Configuration);
builder.Services.ConfigureDependencyInjection();
builder.Services.ConfigureJwtAuthentication(builder.Configuration);
builder.Services.ConfigureSwagger(builder.Environment);
builder.Services.ConfigureCorsPolicy(builder.Configuration);
builder.Services.ConfigureRateLimiting(builder.Configuration);

builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseMiddleware<RequestLoggingMiddleware>();
app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseMiddleware<TokenMiddleware>();

app.UseCors("AllowSpecificOrigins");

app.UseAuthentication();
app.UseAuthorization();

 app.UseRateLimiter();

app.MapControllers();

DatabaseMigrationHelper.ApplyMigrations(app.Services);

app.Run();
