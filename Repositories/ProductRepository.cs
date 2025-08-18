using log4net;
using System.Linq;

public class ProductRepository : IProductRepository
{
    private AppDbContext appDbContext;
    private static readonly ILog log = LogHelper.Logger;

    public ProductRepository(AppDbContext appDbContext)
    {
        this.appDbContext = appDbContext;
    }

    public List<Product> GetProducts()
    {
        log.Info("Getting all the Products data..");
        return appDbContext.Products.ToList();
    }

    public List<Product> GetProductsByCategory(string categoryName) // ? NEW
    {
        log.Info($"Fetching products for category: {categoryName}");
        return appDbContext.Products
            .Where(p => p.Category.ToLower() == categoryName.ToLower())
            .ToList();
    }

    public void Create(Product product)
    {
        log.Warn("Adding the New Products!..");
        appDbContext.Products.Add(product);
        appDbContext.SaveChanges();
        log.Info("New Product is added.");
    }

    public void Update(int id, Product product)
    {
        var productToUpdate = appDbContext.Products.Find(id);
        if (productToUpdate != null)
        {
            log.Warn("Updating data of Products");
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.Description = product.Description;
            appDbContext.SaveChanges();
            log.Info("Updated Products data.");
        }
        else
        {
            log.Error("User product is not found");
        }
    }

    public void Delete(int id)
    {
        var product = appDbContext.Products.Find(id);
        if (product != null)
        {
            log.Warn("Deleting Product data");
            appDbContext.Remove(product);
            appDbContext.SaveChanges();
            log.Info("Deleted Product data");
        }
        else
        {
            log.Error("Unsuccessful Deletion of Product!!!!");
        }
    }
}
