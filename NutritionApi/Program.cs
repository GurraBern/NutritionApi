using BookStoreApi.Models;
using NutritionApi.Services;

var builder = WebApplication.CreateBuilder(args);

var dbUrl = Environment.GetEnvironmentVariable("NUTRITIONDB_CONNECTIONSTRING", EnvironmentVariableTarget.Process);
if (dbUrl != null)
{
    builder.Services.Configure<NutritionDatabaseSettings>(options =>
    {
        builder.Configuration.GetSection("NutritionDatabaseSettings");
        options.ConnectionString = dbUrl;
    });
}
else
{
    builder.Services.Configure<NutritionDatabaseSettings>(builder.Configuration.GetSection("NutritionDatabaseSettings"));
}

builder.Services.AddSingleton<INutritionService, NutritionService>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
