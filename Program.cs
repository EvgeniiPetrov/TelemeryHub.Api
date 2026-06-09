var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/health", () => Results.Ok(new
{
    Status = "Healthy",
    Time = DateTimeOffset.UtcNow
}));

app.MapGet("/ping", () => Results.Ok(new 
{
    Message = "pong"
}));

app.Run();
