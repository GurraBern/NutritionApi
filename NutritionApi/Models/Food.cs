using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace NutritionApi.Models;

public class Food
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("Name")]
    public string FoodName { get; set; } = null!;

    public int Kcal { get; set; }

    public int Carbs { get; set; }

    public int Protein { get; set; }

    public int Fat { get; set; }
}