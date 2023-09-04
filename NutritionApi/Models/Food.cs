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

    public string? Category { get; set; }

    public string? NutrientDataBankNumber { get; set; }

    public double AlphaCarotene { get; set; }

    public double Ash { get; set; }

    public double BetaCarotene { get; set; }

    public double BetaCryptoxanthin { get; set; }

    public double Carbohydrate { get; set; }

    public double Cholesterol { get; set; }

    public double Choline { get; set; }

    public double Fiber { get; set; }

    public double Kilocalories { get; set; }

    public double LuteinAndZeaxanthin { get; set; }

    public double Lycopene { get; set; }

    public double Manganese { get; set; }

    public double Niacin { get; set; }

    public double PantothenicAcid { get; set; }

    public double Protein { get; set; }

    public double RefusePercentage { get; set; }

    public double Retinol { get; set; }

    public double Riboflavin { get; set; }

    public double Selenium { get; set; }

    public double SugarTotal { get; set; }

    public double Thiamin { get; set; }

    public double Water { get; set; }

    public double MonosaturatedFat { get; set; }

    public double SaturatedFat { get; set }

    public double TotalLipid { get; set; }

    public double FirstHouseholdWeight { get; set; }

    public double FirstHouseholdWeightDescription { get; set; }

    public double SecondHouseholdWeight { get; set; }

    public double SecondHouseholdWeightDescription { get; set; }


    public Minerals Minerals { get; set; } = new Minerals();

    public Vitamins Vitamins { get; set; } = new Vitamins();
}