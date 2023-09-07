using NutritionApi.Models;

namespace NutritionApi.Services;

public interface INutritionService
{
    public Task<IEnumerable<Food>> Get();
    public Task<Food> Get(string id);
    public Task<ICollection<Food>> SearchFoodsByName(string name, int pageNumber = 1, int pageSize = 10);
    public Task Create(Food food);
}