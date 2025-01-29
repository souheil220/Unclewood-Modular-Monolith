using Unclewood.Common.Application;
using Unclewood.Modules.Ingredients.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication([Unclewood.Modules.Ingredients.Application.AssemblyReference.Assembly]);
builder.Services.AddInfrastructure(builder.Configuration.GetSection("DefaultConnection")!);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

DependencyInjectionIngredientModule.MapEndPoints(app);

app.Run();
