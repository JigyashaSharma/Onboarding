using Onboarding.Server.ApplicationTier.Classes;
using Microsoft.EntityFrameworkCore;
using Onboarding.Server.ApplicationTier.Interfaces;
using Onboarding.Server.Models;

var builder = WebApplication.CreateBuilder(args);

//Add congiguration settings
var configuration = new ConfigurationBuilder()
   .SetBasePath(AppContext.BaseDirectory)
   .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
   .AddEnvironmentVariables()
   .Build();

//get connection string to database
var constring = configuration.GetConnectionString("DefaultConnection");
var dbName = Environment.GetEnvironmentVariable("DB_NAME");
var dbServer = Environment.GetEnvironmentVariable("DB_SERVER");

if (dbName != null)
{
    constring = constring?.Replace("${DB_NAME}", dbName);
}
else
{
    throw new InvalidOperationException("DB_NAME environment variable is not set.");
}

if (dbServer != null)
{
    constring = constring?.Replace("${DB_SERVER}", dbServer);
}
else
{
    throw new InvalidOperationException("DB_SERVER environment variable is not set.");
}

// Add services to the container.
//Add dbcontexxt
builder.Services.AddDbContext<IndustryConnectWeek2Context>(options => options.UseSqlServer(constring));

builder.Services.AddScoped<ICustomerMethods, CustomerMethods>();
builder.Services.AddScoped<IProductMethods, ProductMethods>();
builder.Services.AddScoped<ISaleMethods, SaleMethods>();
builder.Services.AddScoped<IStoreMethods, StoreMethods>();

builder.Services.AddControllers().AddNewtonsoftJson(); ;
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
