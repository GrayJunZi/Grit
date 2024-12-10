using MiddlewareExample.CustomMiddleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<MyCustomMiddleware>();

var app = builder.Build();

// middleware 1
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("Middleware 1\n");
    await next(context);
});

// middleware 2
app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("Middleware 2\n");
    await next(context);
});

// Custom Middleware
app.UseMiddleware<MyCustomMiddleware>();


// middleware 3
app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("Middleware 3\n");
});

app.Run();
