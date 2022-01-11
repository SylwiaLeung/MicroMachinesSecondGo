using MicroMachines;
using MicroMachines.HttpClients;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddNewtonsoftJson(s =>
    {
        s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        s.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
    });

builder.Services.AddHttpClient<IHttpOrdersClient, HttpOrdersClient>();
builder.Services.AddHttpClient<IHttpStockClient, HttpStockClient>();
builder.Services.AddHttpClient<IHttpUserClient, HttpUserClient>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
