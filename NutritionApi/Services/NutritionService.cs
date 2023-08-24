using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using NutritionApi.Models;

namespace NutritionApi.Services;

public class NutritionService : INutritionService
{
    private readonly IMongoCollection<Food>? _foodCollection;

    public NutritionService(IOptions<NutritionDatabaseSettings> nutritionDatabaseSettings)
    {
        var mongoClient = new MongoClient(nutritionDatabaseSettings.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(nutritionDatabaseSettings.Value.DatabaseName);
        _foodCollection = mongoDatabase.GetCollection<Food>(nutritionDatabaseSettings.Value.NutritionCollectionName);
    }

    public async Task<IEnumerable<Food>> Get() =>
        await _foodCollection.Find(_ => true).ToListAsync();

    public async Task<Food> Get(string id) =>
       await _foodCollection.Find(food => food.Id == id).FirstOrDefaultAsync();

    public async Task<ICollection<Food>> SearchFoodsByName(string foodName)
    {
        var filter = Builders<Food>.Filter.Regex("FoodName", new BsonRegularExpression(foodName, "i"));
        var foods = await _foodCollection.Find(filter).ToListAsync();
        return foods;
    }

    public async Task Create(Food food) =>
        await _foodCollection.InsertOneAsync(food);
}
