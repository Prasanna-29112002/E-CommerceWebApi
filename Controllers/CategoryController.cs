using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryController(ICategoryRepository categoryRepository)
    {
        this._categoryRepository = categoryRepository;
    }

    [HttpGet]
    public List<Category> GetCategories()
    {
        return _categoryRepository.GetCategories();
    }
    [Authorize]
  [Authorize(Roles = "Admin")]
    [HttpGet("{id}")]
    public Category GetCategory(int id)
    {
        return _categoryRepository.GetCategory(id);
    }
     [Authorize]
  [Authorize(Roles = "Admin")]
    [HttpPost("AddingNewCategory")]
    public void Create(Category category)
    {
        _categoryRepository.Create(category);
    }
     [Authorize]
     [Authorize(Roles = "Admin")]
    [HttpPut("UpdateCategory")]
    public void Update(int id, Category category)
    {
        _categoryRepository.Update(id, category);
    }
     [Authorize]
  [Authorize(Roles = "Admin")]
    [HttpDelete("DeleteCategory")]
    public void Delete(int id)
    {
        _categoryRepository.Delete(id);
    }
}
