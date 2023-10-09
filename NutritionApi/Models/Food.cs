using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace NutritionApi.Models;

public class Food
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    public string? ExternalId { get; set; }

    [BsonElement("Name")]
    public string Name { get; set; } = null!;

    public string Creator { get; set; }

    public int Amount { get; set; } = 100;

    public double Calories { get; set; }

    public double Protein { get; set; }

    public double Carbohydrate { get; set; }

    public double Fiber { get; set; }

    public double Sugar { get; set; }

    public double Starch { get; set; }

    public double TotalFat { get; set; }

    public double TotalSaturatedFat { get; set; }

    public double TotalTransFat { get; set; }

    public double TotalMonounsaturated { get; set; }

    public double TotalPolyunsaturated { get; set; }

    public double Cholesterol { get; set; }


    //Vitamins
    public double VitaminA { get; set; }

    public double Thiamin { get; set; }

    public double Riboflavin { get; set; }

    public double Niacin { get; set; }

    public double PantothenicAcid { get; set; }

    public double VitaminB6 { get; set; }

    public double Biotin { get; set; }

    public double Folate { get; set; }

    public double VitaminB12 { get; set; }

    public double VitaminC { get; set; }

    public double Choline { get; set; }

    public double VitaminD { get; set; }

    public double VitaminE { get; set; }

    public double VitaminK1 { get; set; }

    public double VitaminK2 { get; set; }

    //Minerals
    public double Calcium { get; set; }

    public double Chromium { get; set; }

    public double Copper { get; set; }

    public double Fluoride { get; set; }

    public double Iodine { get; set; }

    public double Iron { get; set; }

    public double Magnesium { get; set; }

    public double Manganese { get; set; }

    public double Molybdenum { get; set; }

    public double Nickel { get; set; }

    public double Phosphorus { get; set; }

    public double Potassium { get; set; }

    public double Selenium { get; set; }

    public double Sodium { get; set; }

    public double Zinc { get; set; }

    //Amino Acids
    public double Alanine { get; set; }

    public double Arginine { get; set; }

    public double Asparagine { get; set; }

    public double AsparticAcid { get; set; }

    public double Cystine { get; set; }

    public double GlutamicAcid { get; set; }

    public double Glutamine { get; set; }

    public double Glycine { get; set; }

    public double Histidine { get; set; }

    public double Isoleucine { get; set; }

    public double Leucine { get; set; }

    public double Lysine { get; set; }

    public double Methionine { get; set; }

    public double Phenylalanine { get; set; }

    public double Proline { get; set; }

    public double Serine { get; set; }

    public double Threonine { get; set; }

    public double Tryptophan { get; set; }

    public double Tyrosine { get; set; }

    public double Valine { get; set; }

    //Other
    public double CaroteneAlpha { get; set; }

    public double CaroteneBeta { get; set; }

    public double CryptoxanthinBeta { get; set; }

    public double LuteinZeaxanthin { get; set; }

    public double Lycopene { get; set; }

    public double Theobromine { get; set; }
}
