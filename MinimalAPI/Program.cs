using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<ToDoDb>(opt => opt.UseInMemoryDatabase("ToDos"));

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new() { Title = "Minimal API", Version = "v1" });
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<ToDoDb>();
    dbContext.Database.EnsureCreated();
}

app.AddToDoModule();

app.UseSwagger();
app.UseSwaggerUI();

await app.RunAsync();
