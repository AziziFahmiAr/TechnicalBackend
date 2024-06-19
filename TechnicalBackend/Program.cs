using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TechnicalBackend.DBEntities;
using TechnicalBackend.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Donot forgot to add ConnectionStrings as "dbConnection" to the appsetting.json file
builder.Services.AddDbContext<DBContext>(options =>
{
    var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
    string connStr;

    if (env == "Development")
    {
        connStr = builder.Configuration.GetConnectionString("dbConnection");


    }
    else
    {
        // Use connection string provided at runtime by Heroku.
        var connUrl = Environment.GetEnvironmentVariable("JAWSDB_MARIA_URL");

        connUrl = connUrl.Replace("mysql://", string.Empty);
        var userPassSide = connUrl.Split("@")[0];
        var hostSide = connUrl.Split("@")[1];

        var connUser = userPassSide.Split(":")[0];
        var connPass = userPassSide.Split(":")[1];
        var connHost = hostSide.Split("/")[0];
        var connPort = connHost.Split(":")[1];
        connHost = connHost.Split(":")[0];
        var connDb = hostSide.Split("/")[1].Split("?")[0];


        connStr = $"server={connHost};Port={connPort};Uid={connUser};Pwd={connPass};Database={connDb}";



    }

    options.UseMySql(connStr, ServerVersion.AutoDetect(connStr));

});
//options.UseMySql(builder.Configuration.GetConnectionString("dbConnection"), ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("dbConnection")))

builder.Services.AddTransient<ITTDeveloperService, TTDeveloperService>();
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();