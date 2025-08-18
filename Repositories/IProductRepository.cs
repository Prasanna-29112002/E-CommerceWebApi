public interface IProductRepository
{
    List<Product> GetProducts();
    List<Product> GetProductsByCategory(string categoryName); // ✅ NEW
    void Create(Product product);
    void Update(int id, Product product);
    void Delete(int id);
}
