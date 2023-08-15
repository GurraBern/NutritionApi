using BookStoreApi.Models;
using NutritionApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<NutritionDatabaseSettings>(options =>
{
    builder.Configuration.GetSection("NutritionDatabaseSettings");
    options.ConnectionString = builder.Configuration.GetConnectionString("NUTRITIONDB_CONNECTIONSTRING");
});

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
