using API.Middlewares;
using API.Setup;
using Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.ConfigureSwagger();

builder.Services.AddDbContext<DxContext>();

builder.ConfigureAuthentication();

builder.ConfigureDependencies();

builder.Services.AddAuthorization(options =>
{
    options.DefaultPolicy = new AuthorizationPolicyBuilder()
        .AddRequirements(new AssertionRequirement(context =>
            context.User.Identity != null && context.User.Identity.IsAuthenticated
            || context.Resource is Microsoft.AspNetCore.Mvc.Filters.AuthorizationFilterContext filterContext
                && filterContext.HttpContext.Request.Path.Value.EndsWith("/login", StringComparison.OrdinalIgnoreCase)
        ))
        .Build();
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    {
        builder.WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseMiddleware<JwtTokenValidationMiddleware>();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
