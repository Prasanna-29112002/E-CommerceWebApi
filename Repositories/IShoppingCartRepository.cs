using System.Collections.Generic;
public interface IShoppingCartRepository
{
    List<ShoppingCart> GetShoppingCarts();
    void AddToCart(int productid);
    // void Create(ShoppingCart shoppingCart);
    void Update(int id, ShoppingCart shoppingCart);
    void Delete(int id);
}