using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductRepository productRepository;

    public ProductController(IProductRepository productRepository)
    {
        this.productRepository = productRepository;
    }

    [HttpGet]
    public List<Product> GetProducts()
    {
        return productRepository.GetProducts();
    }

    // ✅ Updated to use repository method
    [HttpGet("category/{categoryName}")]
    public ActionResult<List<Product>> GetProductsByCategory(string categoryName)
    {
        var products = productRepository.GetProductsByCategory(categoryName);

        if (products == null || products.Count == 0)
        {
            return NotFound("No products found for this category.");
        }

        return Ok(products);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public IActionResult Create(Product product)
    {
        productRepository.Create(product);
        return Ok("Product added.");
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult Update(int id, Product product)
    {
        productRepository.Update(id, product);
        return Ok("Product updated.");
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult Delete(int id)
    {
        productRepository.Delete(id);
        return Ok("Product deleted.");
    }
}
