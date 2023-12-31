﻿namespace NutritionApi.Models;

public class NutritionDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string NutritionCollectionName { get; set; } = null!;
}