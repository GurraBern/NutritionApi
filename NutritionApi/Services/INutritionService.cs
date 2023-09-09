using NutritionApi.Models;

namespace NutritionApi.Services;

public interface INutritionService
{
    public Task<IEnumerable<Food>> Get(int pageNumber, int pageSize);
    public Task<Food> Get(string id);
    public Task<ICollection<Food>> SearchFoodsByName(string name, int pageNumber, int pageSize);
    public Task Create(Food food);
}