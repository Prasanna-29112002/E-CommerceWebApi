using log4net;
public class CategoryRepository : ICategoryRepository
{
    private AppDbContext appDbContext;
    private static readonly ILog Log = LogHelper.Logger;
    public CategoryRepository(AppDbContext appDbContext)
    {
        this.appDbContext = appDbContext;
    }

    public List<Category> GetCategories()
    {
        return appDbContext.Categories.ToList();
    }

    public Category GetCategory(int id)
    {
        Log.Info("Getting all the Category.");
        return appDbContext.Categories.Find(id);
    }

    public void Create(Category category)
    {
        Log.Warn("Adding the New Category!..");
        appDbContext.Categories.Add(category);
        appDbContext.SaveChanges();
        Log.Info("New Category is added.");

    }

    public void Update(int id, Category category)
    {
        var catToUpdate = appDbContext.Categories.Find(id);
        if (catToUpdate != null)
        {
            Log.Warn("Updating data of Category!..");
            catToUpdate.Name = category.Name;
            appDbContext.SaveChanges();
            Log.Info("Updated data successfully.");
        }
        else
        {
             Log.Error("User Category not found");
        }
    }

    public void Delete(int id)
    {
        var cat = appDbContext.Categories.Find(id);
        if (cat != null)
        {
            Log.Warn("Deleting Category data!..");
            appDbContext.Categories.Remove(cat);
            appDbContext.SaveChanges();
            Log.Info("Deleted Category data");
        }
        else
        {
             Log.Error("Unsuccessfull Deletion of Category!!!!");
        }
    }
}
