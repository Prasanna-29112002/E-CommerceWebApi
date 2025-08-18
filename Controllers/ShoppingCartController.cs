using System;
using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("[controller]")]
public class ShoppingCartController : ControllerBase
{
  private IShoppingCartRepository ShoppingCartRepository;
  // private readonly AppDbContext appDbContext;
  public ShoppingCartController(IShoppingCartRepository ShoppingCartRepository)
  {
    this.ShoppingCartRepository = ShoppingCartRepository;
  }
  [HttpGet]
  public List<ShoppingCart> GetShoppingCarts()
  {
    return ShoppingCartRepository.GetShoppingCarts();
  }
  // [HttpPost]
  // public void Create(ShoppingCart shoppingCart)
  // {
  //   ShoppingCartRepository.Create(shoppingCart);
  // }
  [HttpPut("UpdateCart")]
  public void Update(int id, ShoppingCart shoppingCart)
  {
    ShoppingCartRepository.Update(id, shoppingCart);
  }
  [HttpDelete("DeleteCart")]
  public void Delete(int id)
  {
    ShoppingCartRepository.Delete(id);
  }
  [HttpPost("AddToCart")]

  public void AddToCart(int productId)
  {
    ShoppingCartRepository.AddToCart(productId);
  }
}