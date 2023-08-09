using NutritionApi.Models;

namespace NutritionApi.Services;

public interface INutritionService
{
    public Task<IEnumerable<Food>> Get();
    public Task<Food> Get(string id);
    public Task Create(Food food);
}