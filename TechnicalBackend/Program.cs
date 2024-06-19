using Microsoft.EntityFrameworkCore;
using TechnicalBackend.DBEntities;
using TechnicalBackend.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Donot forgot to add ConnectionStrings as "dbConnection" to the appsetting.json file
builder.Services.AddDbContext<DBContext>
    (options => options.UseMySql(builder.Configuration.GetConnectionString("dbConnection"), ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("dbConnection"))));
builder.Services.AddTransient<ITTDeveloperService, TTDeveloperService>();
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

app.MapControllers();

app.Run();