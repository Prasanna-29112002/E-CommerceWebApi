public interface ICategoryRepository
{
    List<Category> GetCategories();
    Category GetCategory(int id);
    void Create(Category category);
    void Update(int id, Category category);
    void Delete(int id);
}
