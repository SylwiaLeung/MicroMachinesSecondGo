using MicroMachines;
using MicroMachines.Data;
using MicroMachines.HttpClients;
using MicroMachines.Services;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddNewtonsoftJson(s =>
    {
        s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        s.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
    });

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddDbContext<UserDbContext>(options => options.UseInMemoryDatabase(databaseName: "UserDb"));
builder.Services.AddHttpClient<IHttpOrdersClient, HttpOrdersClient>();
builder.Services.AddHttpClient<IHttpStockClient, HttpStockClient>();

var app = builder.Build();

PrepUserDatabase.Initialize();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
