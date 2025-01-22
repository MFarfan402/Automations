using APIAutomation.Config;
using APIAutomation.Interfaces;
using APIAutomation.Repository;

var builder = WebApplication.CreateBuilder(args);

Console.WriteLine("Hello from Martha");

// Add services to the container.

builder.Services.AddControllers();

// DataSource: File
builder.Services.AddSingleton<IRoleSoundConsole, RoleSoundConsoleRepository>();

// DataSource: MongoDB
builder.Services.AddSingleton<IMongoDbContext, MongoDbContext>();
builder.Services.AddScoped<IReports, ReportsRepository>();

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

