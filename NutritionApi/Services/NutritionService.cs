using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using NutritionApi.Models;

namespace NutritionApi.Services;

public class NutritionService : INutritionService
{
    private readonly IMongoCollection<Food>? _foodCollection;
    private const int maxFoodsPageSize = 10;

    public NutritionService(IOptions<NutritionDatabaseSettings> nutritionDatabaseSettings)
    {
        var mongoClient = new MongoClient(nutritionDatabaseSettings.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(nutritionDatabaseSettings.Value.DatabaseName);
        _foodCollection = mongoDatabase.GetCollection<Food>(nutritionDatabaseSettings.Value.NutritionCollectionName);
    }

    public async Task<IEnumerable<Food>> Get(int pageNumber, int pageSize)
    {
        var foods = await _foodCollection.Find(_ => true)
            .Skip(pageSize * (pageNumber - 1))
            .Limit(pageSize)
            .ToListAsync();

        return foods;
    }

    public async Task<Food> Get(string id) =>
       await _foodCollection.Find(food => food.Id == id).FirstOrDefaultAsync();

    public async Task<ICollection<Food>> SearchFoodsByName(string name, int pageNumber = 1, int pageSize = 10)
    {
        if (pageSize > maxFoodsPageSize)
            pageSize = maxFoodsPageSize;

        var filter = Builders<Food>.Filter.Regex("Name", new BsonRegularExpression(name, "i"));
        var foods = await _foodCollection.Find(filter)
            .Skip(pageSize * (pageNumber - 1))
            .Limit(pageSize)
            .ToListAsync();

        return foods;
    }

    public async Task Create(Food food) =>
        await _foodCollection.InsertOneAsync(food);
}
