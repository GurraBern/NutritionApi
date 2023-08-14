﻿using Microsoft.AspNetCore.Mvc;
using NutritionApi.Models;
using NutritionApi.Services;

namespace NutritionApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FoodController : ControllerBase
{
    private readonly INutritionService nutritionService;

    public FoodController(INutritionService nutritionService)
    {
        this.nutritionService = nutritionService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Food>>> GetFood()
    {
        var testFoods = new List<Food>();
        testFoods.Add(new Food()
        {
            FoodName = "Test",
            Kcal = 123
        });
        //var foods = await nutritionService.Get();
        return testFoods.ToList();
    }

    [HttpGet("id/{id}")]
    public async Task<ActionResult<Food>> GetFood(string id)
    {
        var food = await nutritionService.Get(id);

        if (food is null)
            return NotFound();

        return food;
    }

    [HttpGet("name/{foodName}")]
    public async Task<ActionResult<ICollection<Food>>> GetFoodByName(string foodName)
    {
        var foods = await nutritionService.SearchFoodsByName(foodName);

        if (foods is null)
            return NotFound();

        return foods.ToList();
    }

    [HttpPost]
    public async Task CreateFood(Food food)
    {
        await nutritionService.Create(food);
    }
}
