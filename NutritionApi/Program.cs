using FirebaseAdmin;
using FirebaseAdminAuthentication.DependencyInjection.Extensions;
using Google.Apis.Auth.OAuth2;
using NutritionApi.Models;
using NutritionApi.Services;

var builder = WebApplication.CreateBuilder(args);

var dbUrl = Environment.GetEnvironmentVariable("NUTRITIONDB_CONNECTIONSTRING", EnvironmentVariableTarget.Process);
if (dbUrl != null)
{
    builder.Services.Configure<NutritionDatabaseSettings>(options =>
    {
        builder.Configuration.GetSection("NutritionDatabaseSettings").Bind(options);
        options.ConnectionString = dbUrl;
    });
}
else
{
    builder.Services.Configure<NutritionDatabaseSettings>(builder.Configuration.GetSection("NutritionDatabaseSettings"));
}

builder.Logging
    .ClearProviders()
    .AddConsole();

builder.Services.AddSingleton<INutritionService, NutritionService>();

builder.Services
    .AddControllers()
    .AddXmlDataContractSerializerFormatters();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddFirebaseAuthentication();
builder.Services.AddAuthorization();

builder.Services.AddSingleton(FirebaseApp.Create(new AppOptions()
{
    Credential = GoogleCredential.GetApplicationDefault(),
}));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();