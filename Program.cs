using APIAutomation.Interfaces;
using APIAutomation.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// DataSource: File
builder.Services.AddSingleton<IRoleSoundConsole, RoleSoundConsoleRepository>();
builder.Services.AddSingleton<IAllRoles, AllRolesRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

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

