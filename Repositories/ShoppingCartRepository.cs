using log4net;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
public class ShoppingCartRepository : IShoppingCartRepository
{
    private readonly AppDbContext appDbContext;
    private static readonly ILog log = LogHelper.Logger;
    public ShoppingCartRepository(AppDbContext appDbContext)
    {
        this.appDbContext = appDbContext;
    }

    public List<ShoppingCart> GetShoppingCarts()
    {
          log.Info("Getting all the ShoppingCart data");
        return appDbContext.ShoppingCarts.ToList();
    }

    // public void Create(ShoppingCart shoppingCart)
    // {
    //     appDbContext.ShoppingCarts.Add(shoppingCart);
    //     appDbContext.SaveChanges();

    // }

    public void Update(int id, ShoppingCart shoppingCart)
    {
        var productToUpdate = appDbContext.ShoppingCarts.Find(id);
        if (productToUpdate != null)
        {
            log.Info("Updating data of cart");
            productToUpdate.Quantity = shoppingCart.Quantity;
            productToUpdate.TotalPrice = shoppingCart.TotalPrice;
            appDbContext.SaveChanges();
        }
        else
        {
            log.Error("Cart not Updated!..");

        }
    }
    public void Delete(int productid)
    {
        var nproduct = appDbContext.ShoppingCarts.Find(productid);
        if (nproduct != null)
        {
            log.Warn("Deleting Cart data");
            appDbContext.Remove(nproduct);
            appDbContext.SaveChanges();
            log.Info("Delete CartItems data");
        }
        else
        {
         log.Error("Unsuccessfully Deletion of CartItems!!..");
       }
    }

    public void AddToCart(int productId)
    {
        var product = appDbContext.Products.Find(productId);
        if (product == null) throw new Exception("Product not found");
        var existingCartItem = appDbContext.ShoppingCarts.FirstOrDefault(x => x.ProductId == productId);
        if (existingCartItem != null)
        {
            existingCartItem.Quantity += 1;
            existingCartItem.TotalPrice = existingCartItem.Quantity * product.Price;
        }
        else
        {
            var newCartItem = new ShoppingCart
            {
                ProductId = productId,
                Quantity = 1,
                TotalPrice = product.Price
            };
            appDbContext.ShoppingCarts.Add(newCartItem);
        }
        appDbContext.SaveChanges();
    }
    
   
  
}