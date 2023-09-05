using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace NutritionApi.Models;

public class Food
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("Name")]
    public string Name { get; set; } = null!;

    public string ServingSize { get; set; }

    public double Calories { get; set; }

    public double Protein { get; set; }

    public Carbohydrates Carbohydrates { get; set; }

    public Fats Fats { get; set; }

    public Vitamins Vitamins { get; set; }

    public Minerals Minerals { get; set; }

    public FattyAcids FattyAcids { get; set; }

    public AminoAcids AminoAcids { get; set; }

    public OtherNutrients OtherNutrients { get; set; }
}