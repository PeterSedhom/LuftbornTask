using LuftbornTask.Repositories;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Read MongoDB connection string from configuration
string mongoConnectionString = builder.Configuration.GetConnectionString("MongoDb");
// MongoDB
builder.Services.AddSingleton<IMongoClient>(s =>
    new MongoClient(mongoConnectionString));


// Repository
builder.Services.AddScoped<IVikingRepository, VikingRepository>();

// Add services to the container.
builder.Services.AddControllers();

// Add Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "LuftbornTask API", Version = "v1" });
});

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors(MyAllowSpecificOrigins);
app.UseHttpsRedirection();
app.MapControllers();




app.Run();

