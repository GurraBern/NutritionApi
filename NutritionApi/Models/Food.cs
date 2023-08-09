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

    public decimal Kcal { get; set; }

    public string Carbs { get; set; } = null!;

    public string Protein { get; set; } = null!;

    public string Fat { get; set; } = null!;
}